C:\Factory\Tools\RDMD.exe /RC out

COPY /B ..\HTT\Get\Release\Get.exe out
COPY /B ..\HTT\HTT\Release\HTT.exe out
COPY /B ..\HTT\doc\HTT.conf out
COPY /B ..\HTT\doc\MimeType.tsv out
COPY /B ..\HTT\Tools\MimeType\MimeType\bin\Release\MimeType.exe out

COPY /B HTTDir\HTTDir\bin\Release\HTTDir.exe out
COPY /B HTTDir\HTTDir\httd_16_off.ico out\OffIcon.dat
COPY /B HTTDir\HTTDir\httd_16_on.ico  out\OnIcon.dat
COPY /B HTTDir\HTTDir\httd_16_access.ico out\AccessIcon.dat

C:\Factory\Tools\xcp.exe doc out

C:\Factory\SubTools\zip.exe /O out HTTDir

PAUSE
