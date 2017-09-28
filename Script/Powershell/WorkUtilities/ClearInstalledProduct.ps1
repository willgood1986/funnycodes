# Get current ps directory
$utilityPath = $PSScriptRoot + "\utilities\"
$serviceManagementScript = $utilityPath + "ServiceManagement.ps1"
$commonHelper = $utilityPath + "CommonHelper.ps1"
# import ps
. $serviceManagementScript
. $commonHelper

Write-Host "Start to uninstall the product on the computer..."

$CustomBinaryPath = $null

# Stop on exception
try {
    $app = Get-WmiObject -Class Win32_Product | Where-Object {$_.Name -match "Actual Product Name"}
    if ($app) {
        $CustomBinaryPath  = GetBinaryPath
        $app.Uninstall()
    }
    Write-Host "The product is uninstalled from the computer..."
}
catch [Exception] {
    $ErrorActionPreference = "Stop"
    Write-Host "An error occurred during uninstalling the product...message:" + $_.Exception.Message
}

Start-Sleep -m 500

try {
    Write-Host "Start to clear product install directory..."

    Write-Host "Clear Common Files..."
    $dellCommonFiles = GetCommonFilePath
    if (Test-Path $dellCommonFiles) {
        Remove-Item $dellCommonFiles -Recurse -Force
    }

   Write-Host "Clear ProgramData..."
    $dellProgramData = "C:\ProgramData\rainy"
    if (Test-Path $dellProgramData) {
        Remove-Item $dellProgramData -Recurse -Force
    }

    Write-Host "Clear Roaming data..."
    $userRoamingPath = $env:USERPROFILE + "\AppData\Roaming\rainy"
    if (Test-Path $userRoamingPath) {
        Remove-Item $userRoamingPath -Recurse -Force
    }

    Write-Host "Clear product default folder ..."
    $productDirectory = GetProductDefaultPath
    if (Test-Path $productDirectory) {
        Remove-Item $productDirectory -Recurse -Force
     }

    if ($CustomBinaryPath -and (Test-Path $CustomBinaryPath)) {
        Write-Host "Custom Install Path:" + $customBinaryPath
        Remove-Item $CustomBinaryPath -Recurse -Force
    }

    Write-Host "The product install directory is cleared now..."
    Start-Sleep -m 500
}
catch [Exception] {
    $ErrorActionPreference = "Stop";
    Write-Host "An error occurred during clearing install directory...Message:" + $_.Exception.Message
}

Start-Sleep -m 500
try {

    Write-Host "Start to remove data on IIS for Product ..."
    Write-Host "Start to remove webreport application pool"

    # Important to import the webadministratiron
    import-module webadministration

    $reportAppPool = 'IIS:\AppPools\rainy Web Reports'
    if (Test-Path $reportAppPool) {
        Write-Host 'Enter remove web app pool'
        Remove-WebAppPool -Name "rainy Web Reports"
    }

    Write-Host "Start to remove web report application ..."
    $dellWebReport = 'IIS:\Sites\Default Web Site\UCDiagnostics'
    if (Test-Path $dellWebReport) {
        Write-Host 'Enter remove webapplication'
        Remove-WebApplication -Site "Default Web Site" -Name "UCDiagnostics"
    }

    Write-Host "Remov temporary data ..."
    $webReportDirectory = "C:\inetpub\wwwroot\UCDiagnostics"
    
    if (Test-Path $webReportDirectory) {    
        Remove-Item $webReportDirectory -Force -Recurse
    }
    
    $tempData = "C:\inetpub\temp\IIS Temporary Compressed Files\rainy Web Reports"
    if (Test-Path $tempData) {
        Remove-Item $tempData -Force -Recurse
    }
}
catch [Exception] {
    $ErrorActionPreference = "Stop";
    Write-Host "An error occurred during clearing IIS data...Message:" + $_.Exception.Message
}

try{
    Write-Host "Start to remove registry of product"
    $registryPath = "HKCU:\Software\rainy Signing"
    if (Test-Path $registryPath) {
        Remove-Item  -Recurse -Force
    }
    Write-Host "The registry of product is cleared now ..."
    Start-Sleep -m 500
}
catch [Exception]{
    $ErrorActionPreference = "Stop";
    Write-Host "An error occurred during removing registry of product...Message:" + $_.Exception.Message
}

Write-Host "The clear process exits successfully!"
PressAnyToContinue