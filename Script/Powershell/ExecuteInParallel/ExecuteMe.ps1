if (test-path variable:\psise)
{
    throw 'It must be run from powershell.exe and NOT powershell_ise.exe!'
    break
}

#Script adapted from threading code by Osin Grehan
#http://www.nivot.org/2009/01/22/CTP3TheRunspaceFactoryAndPowerShellAccelerators.aspx


$MaxRunspaces = 25
$ConcurrentNumber = 20

# create a pool of runspaces
$pool = [runspacefactory]::CreateRunspacePool(1, $MaxRunspaces)
$pool.Open()

Write-Host "Available Runspaces: $($pool.GetAvailableRunspaces())" 
$jobs = @()  
$ps = @()  
$wait = @()   

for ($i = 0; $i -lt $ConcurrentNumber; $i++)
{
    # create a "powershell pipeline runner"
    $ps += [powershell]::create()

    # assign our pool of runspaces to use
    $ps[$i].runspacepool = $pool

    $msg10 = "amy test0123456789"
    $source = "Microsoft-Exchange-HighAvailability"
    $eventId = 1018
    $script = "Invoke-Expression -Command .\script.ps1" 

    #Write-Host $script

    # Assign Scripts to powershell object
    [void]$ps[$i].AddScript($script)
    
    # start job  
    $jobs += $ps[$i].BeginInvoke();  
      
    Write-Host "Available runspaces: $($pool.GetAvailableRunspaces())" 
      
    # store wait handles for WaitForAll call  
    $wait += $jobs[$i].AsyncWaitHandle   

}

 # wait 1 hour for all jobs to complete, else abort  

 Write-Host (Get-Date), Begin to write event log, please wait ...

 #$success = [System.Threading.WaitHandle]::WaitAll($wait, 600000)  
  
  ForEach ($handle in $wait)
  {
      $handle.WaitOne(36000000)
  }  

 Write-Host  (Get-Date), "All completed" 
  
 # end async call  
 for ($i = 0; $i -lt $connStrings.Count; $i++) {  
  
     Write-Verbose "Completing async pipeline job $i" 
  
     try {  
         # complete async job  
         $ps[$i].EndInvoke($jobs[$i])  
     } catch {  
         # oops-ee!  
         Write-Warning "error: $_" 
     }  
  
     # dump info about completed pipelines  
     $info = $ps[$i].InvocationStateInfo  
  
     Write-Verbose "State: $($info.state) ; Reason: $($info.reason)" 
 }  
  
 Write-Verbose "Available runspaces: $($pool.GetAvailableRunspaces())"  
