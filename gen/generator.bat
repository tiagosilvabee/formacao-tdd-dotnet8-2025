cls

echo 'Setting variables'
SET ClientName=Moongy
SET ProjectName=Seguradora
SET ResourceName=FUNC

@REM |Blank for latest version |-f net5.0 |-f net6.0 |-f net7.0 |-f net8.0 |-f net9.0 
@REM SET FrameworkVersion=-f net5.0 
SET FrameworkVersion=-f net9.0 

@REM |console |webapi |webapp |blazor |razor 
SET ApplicationType=console  

@REM |Blank for mstest |mstest |xunit |nunit 
SET TestsFramework=xunit


SET AddDatabaseFeatures=0
SET AddUnitTests=1
SET CodeCoverage=1
SET YamlGenerator=0
SET GitRepository=0


rem Structure preparation
echo 'Step 1 - Solution Preparation'
SET SolutionName=%ClientName%_%ProjectName%_%ResourceName%
rmdir /s src
md src
cd src
dotnet new sln -n %SolutionName%

rem Structure preparation
echo 'Step 2 - Folder Creation'
SET DocumentationFolder="0 - Docs"
md %DocumentationFolder%
echo boilerplate >> %DocumentationFolder%\.boilerplate


SET ApplicationFolder="1 - Application"
SET ApplicationFolderDescription=Application layer: responsible for the main project, because that is where the API drivers and Infrastructures will be developed. It has the function of receiving all requests and directing them to some Infrastructure to perform a certain action
md %ApplicationFolder%
echo %ApplicationFolderDescription% >> %ApplicationFolder%\readme.md
dotnet new %ApplicationType% %FrameworkVersion% -n %ProjectName%.Application -o %ApplicationFolder%\%ProjectName%.Application
dotnet sln add %ApplicationFolder%\%ProjectName%.Application

IF %AddUnitTests% EQU 1 (
    dotnet new %TestsFramework% %FrameworkVersion% -n %ProjectName%.Application.Tests -o %ApplicationFolder%\%ProjectName%.Application.Tests
    dotnet sln add %ApplicationFolder%\%ProjectName%.Application.Tests
    dotnet add %ApplicationFolder%\%ProjectName%.Application.Tests reference %ApplicationFolder%\%ProjectName%.Application
)


@REM func init %ApplicationFolder%\%ProjectName%.Application --dotnet --force
@REM dotnet sln add %ApplicationFolder%\%ProjectName%.Application


SET DomainFolder="2 - Domain"
SET DomainFolderDescription=Domain layer: responsible for implementing classes/models, which will be mapped to the database, in addition to obtaining the declarations of interfaces, constants, DTOs (Data Transfer Object) and enums
md %DomainFolder%
echo %DomainFolderDescription% >> %DomainFolder%\readme.md
dotnet new classlib %FrameworkVersion% -n %ProjectName%.Domain -o %DomainFolder%\%ProjectName%.Domain
dotnet sln add %DomainFolder%\%ProjectName%.Domain

IF %AddUnitTests% EQU 1 (
    dotnet new %TestsFramework% %FrameworkVersion% -n %ProjectName%.Domain.Tests -o %DomainFolder%\%ProjectName%.Domain.Tests
    dotnet sln add %DomainFolder%\%ProjectName%.Domain.Tests
    dotnet add %DomainFolder%\%ProjectName%.Domain.Tests reference %DomainFolder%\%ProjectName%.Domain
)


SET InfrastructureFolder="3 - Infrastructure"
SET InfrastructureFolderDescription=Infrastructure layer: it would be the 'heart' of the project, because it is in it that all business rules and validations are done, before the data persists in the database
md %InfrastructureFolder%
echo %InfrastructureFolderDescription% >> %InfrastructureFolder%\readme.md
dotnet new classlib -n %ProjectName%.Infrastructure -o %InfrastructureFolder%\%ProjectName%.Infrastructure
dotnet sln add %InfrastructureFolder%\%ProjectName%.Infrastructure

IF %AddUnitTests% EQU 1 (
    dotnet new %TestsFramework% %FrameworkVersion% -n %ProjectName%.Infrastructure.Tests -o %InfrastructureFolder%\%ProjectName%.Infrastructure.Tests
    dotnet sln add %InfrastructureFolder%\%ProjectName%.Infrastructure.Tests
    dotnet add %InfrastructureFolder%\%ProjectName%.Infrastructure.Tests reference %InfrastructureFolder%\%ProjectName%.Infrastructure
)



rem Project Referencing
rem ApplicationLayer: Infrastructure and Domain
dotnet add %ApplicationFolder%\%ProjectName%.Application reference %DomainFolder%\%ProjectName%.Domain
dotnet add %ApplicationFolder%\%ProjectName%.Application reference %InfrastructureFolder%\%ProjectName%.Infrastructure
rem InfrastructureLayer: Domain and Infrastructure
dotnet add %InfrastructureFolder%\%ProjectName%.Infrastructure reference %DomainFolder%\%ProjectName%.Domain


IF %CodeCoverage% EQU 1 (
    dotnet tool install --global coverlet.console
    dotnet test %SolutionName%.sln --collect:"XPlat Code Coverage"
)

IF %YamlGenerator% EQU 1 (
    SET YamlDefinition=dotnet restore dotnet build dotnet test
    echo %YamlDefinition% >> %SolutionName%_CICD.yaml
)

echo 'Solution Generated successfully'

IF %GitRepository% EQU 1 (
    git add -A && git commit -m "Solution Creation"
    git pull
    git push
    echo 'Solution Commited'
)

cd ..\..