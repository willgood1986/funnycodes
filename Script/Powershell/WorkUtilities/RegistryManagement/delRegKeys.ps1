function DelHKLMSoftwareClassID
{
   param([String[]] $arr)

   Write-Host "Print array content as followed:"

   $regBase = "HKLM:\SOFTWARE\Classes\CLSID\"

   Write-Host $regBase

   Foreach ($item in $arr)
   {

      Write-Host $item

      $key = $regBase + $item

      if (Test-Path $key)
      {
         Write-Host "Path exists, try to delete ...."

         Remove-Item $key -Recurse -Force

          Write-Host "Path was delete ..."

      }
      else
      {
         Write-Host "Path does not exist."
      }

   }
}
