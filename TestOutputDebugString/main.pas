unit main;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, ExtCtrls;

type
  TForm1 = class(TForm)
    btn1: TButton;
    btn2: TButton;
    btn3: TButton;
    btn4: TButton;
    btn5: TButton;
    btn6: TButton;
    img: TImage;
    btn7: TButton;
    btn8: TButton;
    procedure btn1Click(Sender: TObject);
    procedure btn2Click(Sender: TObject);
    procedure btn3Click(Sender: TObject);
    procedure btn5Click(Sender: TObject);
    procedure btn6Click(Sender: TObject);
    procedure AssignBM;
    procedure btn7Click(Sender: TObject);
    procedure btn8Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

uses DebugLogger, TypInfo;

{$R *.dfm}

procedure DebugMsg(const msg: string);
begin
  OutputDebugString(PChar(msg));
end;

procedure TForm1.btn1Click(Sender: TObject);
begin
  PrintDebugLog('Btn1 Click', 'Main', 'TForm1.btn1Click', 39);
  ShowMessage(FormatDateTime('yyyy-mm-dd hh:mm:ss', Now));
end;


procedure TForm1.btn2Click(Sender: TObject);
begin
   PrintDebugLog('Btn2 Click', 'Main', 'TForm1.btn1Click', 39);
end;

procedure TForm1.btn3Click(Sender: TObject);
begin
  PrintDebugLog('Btn3 Click', 'Main', 'TForm1.btn1Click', 39);
end;

procedure TForm1.btn5Click(Sender: TObject);
var
  num: Int64;
begin
  num := High(Int64) - 1;
  ShowMessage(Format('Long int num:%d', [num]));
  ShowMessage(IntToStr(num));
end;

function GetBitmap: HBITMAP;
var
  m, n: Integer;
begin
  m := 3;
  n := 4;
  Result := HBitmap(m -n);
end;

procedure TForm1.AssignBM;
var
  bm: TBitmap;
begin
  bm := TBitmap.Create;
  try
    bm.Handle := GetBitmap;
    img.Picture.Bitmap := bm;
  finally
    bm.Free;
  end;
end;

procedure TForm1.btn6Click(Sender: TObject);
var
  i: Integer;
begin
  for i := 1 to 1000 do
  begin
    AssignBM;
    Sleep(500);
  end;
end;



procedure TForm1.btn7Click(Sender: TObject);
begin
  try
    GetBitmap;
  except
  end;
end;

procedure TForm1.btn8Click(Sender: TObject);
var
  cl: TColor;
begin
  cl := clNone;

  ShowMessage(GetEnumName(TypeInfo(TColor), Ord(cl)));
end;

end.
