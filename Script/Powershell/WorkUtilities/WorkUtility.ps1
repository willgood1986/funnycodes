# Get current ps directory
$scriptPath = $PSScriptRoot
$utilityPath = $scriptPath + "\utilities\"
$serviceManagementScript = $utilityPath + "ServiceManagement.ps1"
$commonHelper = $utilityPath + "CommonHelper.ps1"
$regManagementPath = $scriptPath + "\RegistryManagement\"
$regManagementUtil = $regManagementPath + "TurnOffUAC.ps1"
$delhklmSoftwareClassID = $regManagementPath + "delRegKeys.ps1"

# import ps
. $serviceManagementScript
. $commonHelper
. $regManagementUtil
. $delhklmSoftwareClassID

$start = 0
$stop = 1
$restart = 2
$shutdown = 3
$reboot = 4
$queryService = 5
$clearReg = 6
$shutUAC = 7
$clear = 8
$exit = 9

$loop = 1

$hklmsoftwareguids = @("{41BB4F41-3F3C-485B-A735-46652B533602}", "{47B36D05-4BF4-458E-9A7F-C5A26930A7F2}", "{560ECC59-BF67-40B1-B497-8346AA3107A9}", 
"{73071A8C-BA0B-482E-ADEF-AAC43D5C8916}","{7A7D289D-0EA7-49EC-9645-7B4C929F10FB}", "{7DE2C001-A859-44C1-A4E5-B387646B14C4}",
"{A526DB84-3766-4577-91C9-BEC434114895}", "{B3BE7BAE-94F3-4518-BC54-ED0F162E29E3}", "{B5778264-259C-4F18-A6E6-F9F53353D3DB}", 
"{BDF3E0C0-588C-4C45-B5B5-2728DFDD6069}", "{BE13D6D7-938E-4336-BB20-DC86C354D646}", "{E6A7DE2D-8E89-4776-BD00-42A0FD7EAD44}")


while ($loop -eq 1)
{
    Write-Host "****** Menu ****** `r`n 0 - Start services`r`n 1 - Stop services`r`n 2 - Restart services`r`n 3 - Shutdown Computer`r`n 4 - Restart Computer`r`n 5 - Query service status`r`n 6 - ClearRegForUD`r`n 7 - Turn off UAC`r`n 8 - Clear Screen`r`n 9 - Exit`r`n"

    $input = Read-Host "Please enter the number before each command`r`n "

    Write-Host  " "

    switch ($input)
    {
      $start        { StartALLServices }
      $stop         { StopALLServices }
      $restart      { StopUCDServices; StopALLServices }
      $shutdown     { Stop-Computer -Force }
      $reboot       { Restart-Computer -Force }
      $queryService { QueryServicesStatus }
      $clearReg     { DelHKLMSoftwareClassID($hklmsoftwareguids)}
      $shutUAC      { TurnOffUAC }
      $clear        { Clear-Host }
      $exit         { $loop = 0 }
    }   
    
    Write-Host  " "
}


#PressAnyToContinue