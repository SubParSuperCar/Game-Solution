@echo off
setlocal

echo Windows NT (CMD)

for %%G in (godot.exe godot4.exe) do (
    where %%G >nul 2>nul && (
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
