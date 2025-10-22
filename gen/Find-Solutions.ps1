param(
    [string]$Root = "."
)

# Get all .sln files recursively and normalize paths
$solutions = Get-ChildItem -Path $Root -Recurse -Filter *.sln |
    ForEach-Object {
        ($_ | Resolve-Path -Relative).Replace("\", "/")
    }

# Join the list into a single string, wrapped in parentheses to avoid precedence issues
$solutionList = ($solutions | ForEach-Object { "'$_'" }) -join ", "
$output = "solution: [${solutionList}]"

Write-Output $output
