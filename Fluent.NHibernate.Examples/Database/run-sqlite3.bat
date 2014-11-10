@echo off

setlocal

set sqlite3_exe=..\..\tools\SQLite\3.8.7.1\sqlite-shell-win32-x86\sqlite3.exe

%sqlite3_exe% Example.db

endlocal
