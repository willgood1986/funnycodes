
function TurnOffUAC()
{
    $registryPath = "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\policies\system"

    IF (Test-Path $registryPath)
    {
       $off = 0

       Write-Host Try to turn on UAC

       New-ItemProperty -Path $registryPath -Name EnableLUA -Value $off -PropertyType DWORD -Force | Out-Null

       $result = (Get-ItemProperty -Path $registryPath -Name EnableLUA).EnableLUA

       IF ($result -eq $off)
       {
          Write-Host Turn off UAC is done. You need to restart the computer to make it take effect ...

          $choice = Read-Host "Do you want to reboot now? (Y/N), default is No"
      
          if ($choice -match "['Y']")
          {
              Restart-Computer -ComputerName "."
          }
          else
          {
              Write-Host "It won't take effect till you restart the matchine."
          }
       }
       else
       {
          Write-Host The UAC is already turned off ...
       }
    }
    else
    {
       Write-Host The specified registry path is not found.
    }
}