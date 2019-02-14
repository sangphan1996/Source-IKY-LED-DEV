ECHO OFF
echo Installing SQL Server 2008 R2
date/t
time /t
"%CD%\setup.exe" /ConfigurationFile="%CD%\ConfigurationFile.ini"
date/t
time /t

set PORT=1433
set RULE_NAME="Open Port %PORT%"

netsh advfirewall firewall show rule name=%RULE_NAME% >nul
if not ERRORLEVEL 1 (
    rem Rule %RULE_NAME% already exists.
    echo Hey, you already got a out rule by that name, you cannot put another one in!
) else (
    echo Rule %RULE_NAME% does not exist. Creating...
    netsh advfirewall firewall add rule name=%RULE_NAME% dir=in action=allow protocol=TCP localport=%PORT%
)