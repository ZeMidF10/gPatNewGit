@ECHO OFF
CLS

REM Este script serve para eliminar ficheiros .vs/bin folders e obj folders em projetos xamarin que se tornam demasiado pesados para abrir

ECHO ###### LISTA DE PASTAS A ELIMINAR ###### 

for /d /r %%a in (.vs\) do if exist "%%a" echo "%%a"
for /d /r %%a in (bin\) do if exist "%%a" echo "%%a"
for /d /r %%a in (obj\) do if exist "%%a" echo "%%a"

ECHO.
ECHO Valide na lista acima se esta tudo correcto e prima Enter para continuar com o delete!
ECHO.

PAUSE

for /d /r %%a in (.vs\) do if exist "%%a" rmdir /s /q "%%a"
for /d /r %%a in (bin\) do if exist "%%a" rmdir /s /q "%%a"
for /d /r %%a in (obj\) do if exist "%%a" rmdir /s /q "%%a"

REM ELIMINAR POR EXTENSAO!
REM ECHO Enter the file extension you want to delete...
REM SET /p ext="> "

REM IF EXIST *.%ext% (           rem Check if there are any in the current folder :)
  REM DEL *.%ext%
REM )
REM FOR /D /R %%G IN ("*") DO (  rem Iterate through all subfolders
  REM IF EXIST %%G CD %%G
  REM IF EXIST *.%ext% (
    REM DEL *.%ext%
  REM )
REM )

ECHO.
ECHO ###### DONE ######
ECHO.


PAUSE
EXIT