# Get current ps directory
$utilityPath = $PSScriptRoot + "\utilities\"
$serviceManagementScript = $utilityPath + "ServiceManagement.ps1"
$commonHelper = $utilityPath + "CommonHelper.ps1"
# import ps
. $serviceManagementScript
. $commonHelper

Write-Host "-----Try to stop services ..."
StopUCDServices

$binaryPath = GetBinaryPath
if ($binaryPath -ne $null)
{
    $binaryPath = IncludePathDelimeter($binaryPath)

    Write-Host "------Copy configurations files to switch to Neutral mode"

    $fakeData = $binaryPath + "Neutral\*"
    Copy-Item $fakeData $binaryPath
}
else
{
    Write-Error "The desired binary directory is not found!"
}

Write-Host "------Try to start services ..."
StartUCDServices

Write-Host "------Switch to Neutral Mode Successfully-----"

PressAnyToContinue