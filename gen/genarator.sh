#!/bin/bash
set -e

clear
echo "Setting variables"

# Variáveis
ClientName="Moongy"
ProjectName="Seguradora"
ResourceName="FUNC"

# Framework Version: -f net5.0 | -f net6.0 | -f net7.0 | -f net8.0 | -f net9.0
FrameworkVersion="-f net9.0"

# Application Types: console | webapi | webapp | blazor | razor
ApplicationType="console"

# Tests Framework: mstest | xunit | nunit
TestsFramework="xunit"

# Flags
AddDatabaseFeatures=0
AddUnitTests=1
CodeCoverage=1
YamlGenerator=0
GitRepository=0

# Step 1 - Solution Preparation
echo "Step 1 - Solution Preparation"
SolutionName="${ClientName}_${ProjectName}_${ResourceName}"

rm -rf src
mkdir -p src
cd src
dotnet new sln -n "$SolutionName"

# Step 2 - Folder Creation
echo "Step 2 - Folder Creation"

DocumentationFolder="0 - Docs"
mkdir -p "$DocumentationFolder"
echo "boilerplate" > "$DocumentationFolder/.boilerplate"

# Application Layer
ApplicationFolder="1 - Application"
ApplicationFolderDescription="Application layer: responsible for the main project, because that is where the API drivers and Infrastructures will be developed. It has the function of receiving all requests and directing them to some Infrastructure to perform a certain action"
mkdir -p "$ApplicationFolder"
echo "$ApplicationFolderDescription" > "$ApplicationFolder/readme.md"

dotnet new "$ApplicationType" "$FrameworkVersion" -n "${ProjectName}.Application" -o "$ApplicationFolder/${ProjectName}.Application"
dotnet sln add "$ApplicationFolder/${ProjectName}.Application"

if [ "$AddUnitTests" -eq 1 ]; then
    dotnet new "$TestsFramework" "$FrameworkVersion" -n "${ProjectName}.Application.Tests" -o "$ApplicationFolder/${ProjectName}.Application.Tests"
    dotnet sln add "$ApplicationFolder/${ProjectName}.Application.Tests"
    dotnet add "$ApplicationFolder/${ProjectName}.Application.Tests" reference "$ApplicationFolder/${ProjectName}.Application"
fi

# Domain Layer
DomainFolder="2 - Domain"
DomainFolderDescription="Domain layer: responsible for implementing classes/models, which will be mapped to the database, in addition to obtaining the declarations of interfaces, constants, DTOs (Data Transfer Object) and enums"
mkdir -p "$DomainFolder"
echo "$DomainFolderDescription" > "$DomainFolder/readme.md"

dotnet new classlib "$FrameworkVersion" -n "${ProjectName}.Domain" -o "$DomainFolder/${ProjectName}.Domain"
dotnet sln add "$DomainFolder/${ProjectName}.Domain"

if [ "$AddUnitTests" -eq 1 ]; then
    dotnet new "$TestsFramework" "$FrameworkVersion" -n "${ProjectName}.Domain.Tests" -o "$DomainFolder/${ProjectName}.Domain.Tests"
    dotnet sln add "$DomainFolder/${ProjectName}.Domain.Tests"
    dotnet add "$DomainFolder/${ProjectName}.Domain.Tests" reference "$DomainFolder/${ProjectName}.Domain"
fi

# Infrastructure Layer
InfrastructureFolder="3 - Infrastructure"
InfrastructureFolderDescription="Infrastructure layer: it would be the 'heart' of the project, because it is in it that all business rules and validations are done, before the data persists in the database"
mkdir -p "$InfrastructureFolder"
echo "$InfrastructureFolderDescription" > "$InfrastructureFolder/readme.md"

dotnet new classlib "$FrameworkVersion" -n "${ProjectName}.Infrastructure" -o "$InfrastructureFolder/${ProjectName}.Infrastructure"
dotnet sln add "$InfrastructureFolder/${ProjectName}.Infrastructure"

if [ "$AddUnitTests" -eq 1 ]; then
    dotnet new "$TestsFramework" "$FrameworkVersion" -n "${ProjectName}.Infrastructure.Tests" -o "$InfrastructureFolder/${ProjectName}.Infrastructure.Tests"
    dotnet sln add "$InfrastructureFolder/${ProjectName}.Infrastructure.Tests"
    dotnet add "$InfrastructureFolder/${ProjectName}.Infrastructure.Tests" reference "$InfrastructureFolder/${ProjectName}.Infrastructure"
fi

# Project Referencing
dotnet add "$ApplicationFolder/${ProjectName}.Application" reference "$DomainFolder/${ProjectName}.Domain"
dotnet add "$ApplicationFolder/${ProjectName}.Application" reference "$InfrastructureFolder/${ProjectName}.Infrastructure"
dotnet add "$InfrastructureFolder/${ProjectName}.Infrastructure" reference "$DomainFolder/${ProjectName}.Domain"

# Code Coverage
if [ "$CodeCoverage" -eq 1 ]; then
    dotnet tool install --global coverlet.console
    dotnet test "$SolutionName.sln" --collect:"XPlat Code Coverage"
fi

# YAML Generator
if [ "$YamlGenerator" -eq 1 ]; then
    YamlDefinition="dotnet restore dotnet build dotnet test"
    echo "$YamlDefinition" > "${SolutionName}_CICD.yaml"
fi

echo "Solution Generated successfully"

# Git Repository
if [ "$GitRepository" -eq 1 ]; then
    git add -A && git commit -m "Solution Creation"
    git pull
    git push
    echo "Solution Committed"
fi

cd ../..
