CLS
rem リリースして qrum します。
PAUSE

CALL newcsrr

CALL ff
cx **
CD /D %~dp0.

	CD ..\HTT

	CALL qq
	cx **

	CD /D %~dp0.

CALL qq
cx **

CALL Release.bat /-P

MOVE out\* S:\リリース物\.

START "" /B /WAIT /DC:\home\bat syncRev

CALL qrumauto rel

rem **** AUTO RELEASE COMPLETED ****
