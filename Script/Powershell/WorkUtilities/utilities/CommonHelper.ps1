function Is64bitArchitecture()
{
    $osArchitecture = (Get-WmiObject Win32_OperatingSystem).OSArchitecture
    if ($osArchitecture.StartsWith('64-'))
    {
        return $true
    }
    else
    {
        return $false
    }
}

function GetRegisterClassPath()
{
    $is64Architecture = Is64bitArchitecture
    if ($is64Architecture)
    {
        return "HKLM:\SOFTWARE\Classes\Wow6432Node\CLSID\{49ADDD43-FB5F-4406-9D57-B23D386E6BABE}\InprocServer32"
    }
    else
    {
        return "HKLM:\SOFTWARE\Classes\CLSID\{49ADDD43-FB5F-4406-9D57-B23D386E6ABE}\InprocServer32"
    }
}

function GetProductDefaultPath()
{
    $is64Architecture = Is64bitArchitecture
    if ($is64Architecture)
    {
        return "C:\Program Files (x86)\some folder"
    }
    else
    {
        return "C:\Program Files\some folder"
    }
}

function GetCommonFilePath()
{
    $is64Architecture = Is64bitArchitecture
    if ($is64Architecture)
    {
        return "C:\Program Files (x86)\Common Files\some folder"
    }
    else
    {
        return "C:\Program Files\Common Files\some folder"
    }    
}

function GetBinaryPath() {
    # Use the registry to get custom install directory
    $regPath = GetRegisterClassPath
    $binaryPath = $null
	if (Test-Path $regPath)
    {
        $path = (Get-ItemProperty  -Path $regPath).'(default)'
        if ($path -ne $null)
        {
            $binIndex = $path.IndexOf('Binaries')
            if ($binIndex -ge 0)
            {
                $binaryPath = $path.Substring(0, $binIndex + 'Binaries'.Length)
            }
        }
	}

    return $binaryPath
}


function IncludePathDelimeter(
  [parameter(Mandatory = $true)]
  [String] $directory
)
{
    if ($directory -ne $null)
    {
        if (!$directory.EndsWith('\'))
        {
            return $directory + "\"
        }
    }

    return $directory
}

$DEBUG = $true

function Log(
[String] $logMessage
)
{
    if ($DEBUG)
    {
        Write-Host $logMessage
    }
}

function PressAnyToContinue()
{
    Write-Host "Press any key to continue ..."
    $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}
