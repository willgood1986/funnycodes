$msg100 = "amy test0123456789"
for ($i = 1; $i -le 500; $i++)
{
    $message = "Tom Test: " + $i
New-WinEvent -ProviderName "Microsoft-Exchange-HighAvailability" -Id 1018 -Payload @($msg100,$message,$message,$message)
}