@ECHO OFF
pushd "%~dp0"
ECHO.
ECHO.
ECHO.
ECHO This script deletes all temporary build files in the .vs folder and the
ECHO BIN and OBJ folders contained in the following projects
ECHO.
ECHO TreeLibNugetDemo
ECHO TreeLibDemo
ECHO TreeLib
ECHO TreeLibNet
ECHO.
REM Ask the user if hes really sure to continue beyond this point XXXXXXXX
set /p choice=Are you sure to continue (Y/N)?
if not '%choice%'=='Y' Goto EndOfBatch
REM Script does not continue unless user types 'Y' in upper case letter
ECHO.
ECHO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
ECHO.
ECHO XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
ECHO.
ECHO Removing vs settings folder with *.sou file
ECHO.
RMDIR /S /Q .vs

ECHO.
ECHO Deleting BIN and OBJ Folders in TreeLibNugetDemo
ECHO.
RMDIR /S /Q "TreeLibNugetDemo\bin"
RMDIR /S /Q "TreeLibNugetDemo\obj"

ECHO.
ECHO Deleting BIN and OBJ Folders in TreeLibDemo
ECHO.
RMDIR /S /Q "TreeLibDemo\bin"
RMDIR /S /Q "TreeLibDemo\obj"

ECHO.
ECHO Deleting BIN and OBJ Folders in TreeLib
ECHO.
RMDIR /S /Q "TreeLib\bin"
RMDIR /S /Q "TreeLib\obj"

ECHO.
ECHO Deleting BIN and OBJ Folders in TreeLibNet
ECHO.
RMDIR /S /Q "TreeLibNet\bin"
RMDIR /S /Q "TreeLibNet\obj"

PAUSE

:EndOfBatch
