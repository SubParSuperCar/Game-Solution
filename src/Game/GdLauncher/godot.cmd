@echo off
setlocal

for %%G in (godot.exe godot4.exe) do (
	where %%G >nul 2>nul
	if not errorlevel 1 (
		%%G %*
		exit /b
	)
)

set "SCRIPT_DIR=%~dp0"
if exist "%SCRIPT_DIR%bin\godot.exe" (
	"%SCRIPT_DIR%bin\godot.exe" %*
	exit /b
)

echo Godot not found.
exit /b 1
