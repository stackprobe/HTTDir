IF NOT EXIST HTTDir\. GOTO END
CLS
rem �����[�X���� qrum ���܂��B
PAUSE

CD /D ..\HTT

IF NOT EXIST HTT_is_here.sig GOTO END

CALL qq
cx **

CD /D %~dp0.

IF NOT EXIST HTTDir\. GOTO END

CALL qq
cx **

CALL _Release.bat /-P

MOVE out\HTTDir.zip S:\�����[�X��\.

START "" /B /WAIT /DC:\home\bat syncRev

CALL qrumauto rel

rem **** AUTO RELEASE COMPLETED ****

:END
