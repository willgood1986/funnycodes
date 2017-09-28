# Get current ps directory
$scriptPath = $PSScriptRoot
$utilityPath = $scriptPath + "\utilities\"
$serviceManagementScript = $utilityPath + "ServiceManagement.ps1"
$commonHelper = $utilityPath + "CommonHelper.ps1"
# import ps
. $serviceManagementScript
. $commonHelper

Write-Host "------Try to stop services ..."
StopRainyServicesServices
Write-Host "------Try to start services ..."
StartRainyServices
WRITE-Host "----Restart Services Successfully--------"

PressAnyToContinue