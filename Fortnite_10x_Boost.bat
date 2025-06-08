@echo off
color 0A

:: ███████╗██████╗ ██████╗  █████╗ ██╗██████╗ 
:: ██╔════╝██╔══██╗██╔══██╗██╔══██╗██║██╔══██╗
:: █████╗  ██████╔╝██████╔╝███████║██║██████╔╝
:: ██╔══╝  ██╔═══╝ ██╔═══╝ ██╔══██║██║██║     
:: ███████╗██║     ██║     ██║  ██║██║██║     
:: ╚══════╝╚═╝     ╚═╝     ╚═╝  ╚═╝╚═╝╚═╝     
::       Fortnite 10x Boost Script by 3baid

:: === Show progress bar ===
echo.
echo [----------] Initializing...
timeout /t 1 >nul
echo [##--------] Loading tweaks...
timeout /t 1 >nul
echo [#####-----] Applying system performance...
timeout /t 1 >nul
echo [#######---] Killing bloat processes...
timeout /t 1 >nul
echo [#########-] Applying registry optimizations...
timeout /t 1 >nul
echo [##########] Finalizing...
timeout /t 1 >nul

:: === 1. Activate Ultimate Power Plan ===
powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61 >nul 2>&1
powercfg /setactive e9a42b02-d5df-448d-aa00-03f14749eb61

:: === 2. Disable Bloat Services ===
for %%S in (SysMain DiagTrack WSearch Spooler TrkWks MapsBroker RetailDemo XblGameSave XboxGipSvc XboxNetApiSvc GamingServices) do (
    sc stop %%S >nul 2>&1
    sc config %%S start= disabled >nul 2>&1
)

:: === 3. Disable Windows Defender Real-Time Protection ===
powershell -command "Set-MpPreference -DisableRealtimeMonitoring $true" >nul 2>&1

:: === 4. Flush DNS, Reset Network Stack ===
ipconfig /flushdns >nul
netsh winsock reset >nul
netsh int ip reset >nul

:: === 5. Clear TEMP Files ===
del /s /f /q %temp%\* >nul 2>&1
del /s /f /q C:\Windows\Temp\* >nul 2>&1

:: === 6. Kill Background Tasks ===
powershell -command "
$killList = @(
  'brave','braveupdate','Microsoft.Photos','SkypeApp','msedge','MicrosoftEdgeUpdate','EpicWebHelper','RuntimeBroker',
  'StartMenuExperienceHost','ShellExperienceHost','lghub_agent','lghub_updater','lghub_system_tray','SearchIndexer',
  'CloudExperienceHostBroker','WMIRegistrationService','SecurityHealthService','TextInputHost','smartscreen','SgrmBroker',
  'TiWorker','MoUsoCoreWorker','dllhost','ApplicationFrameHost','CompPkgSrv','unsecapp','YourPhone','OneDrive'
)
foreach ($p in $killList) {
    Get-Process -Name $p -ErrorAction SilentlyContinue | Stop-Process -Force
    Write-Host \"❌ Killed: $p\"
}"
