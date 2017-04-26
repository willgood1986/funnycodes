Write-Host Stop Services on local server ...
Invoke-Expression -Command .\InvokeStopService.ps1

Write-Host Copy configuration files to binary directory
Copy-Item "C:\SourceFolder\*" "C:\DestFolder\"

Write-Host Start Services on local server ...
Invoke-Expression -Command .\InvokeStartService.ps1