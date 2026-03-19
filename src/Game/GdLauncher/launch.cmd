@echo off
setlocal

echo Runtime context: Windows NT (CMD)

set "PATH_CANDIDATES=godot.exe godot4.exe"

for %%G in (%PATH_CANDIDATES%) do (
    for /f "delims=" %%P in (`where %%G 2^>nul`) do (
        echo Found via PATH (%%G): %%P
        "%%P" %*
        exit /b
    )
)

set "SCRIPT_DIR=%~dp0"
set "GODOT_PATH=%SCRIPT_DIR%bin\godot.exe"

if exist "%GODOT_PATH%" (
    echo Found via local bin: "%GODOT_PATH%"
    "%GODOT_PATH%" %*
    exit /b
)

echo Godot not found via PATH or local bin.
exit /b 1
