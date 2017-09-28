# Get current ps directory
$scriptPath = $PSScriptRoot
$utilityPath = $scriptPath + "\utilities\"
$serviceManagementScript = $utilityPath + "ServiceManagement.ps1"
$commonHelper = $utilityPath + "CommonHelper.ps1"
# import ps
. $serviceManagementScript
. $commonHelper

Write-Host "------Try to stop services ..."
StopRainyServices
WRITE-Host "----Stop Services Successfully--------"

PressAnyToContinue