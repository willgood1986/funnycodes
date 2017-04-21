unit DebugLogger;

interface

procedure PrintDebugLog(ALogMessage: string; AUnitName: string; AFunctionName: string; ALineNumber: Integer);

implementation

uses SysUtils, Windows;

procedure PrintDebugLog(ALogMessage: string; AUnitName: string; AFunctionName: string; ALineNumber: Integer);
var
  log: string;
  dt: string;
begin
  dt := FormatDateTime('yyyy-mm-dd hh:mm:ss', Now);
  log := Format('%s:[%s].[%s] at [%d], msg:%s', [dt, AUnitName, AFunctionName, ALineNumber, ALogMessage]);
  OutputDebugString(PChar(log));
end;

end.


