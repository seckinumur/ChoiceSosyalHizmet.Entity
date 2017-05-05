; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "Choice SHM ETO V.1.8"
#define MyAppVersion "1.8"
#define MyAppPublisher "�2017 Choice Corp."
#define MyAppURL "http://www.seckinumur.com"
#define MyAppExeName "ChoiceSosyalHizmet.WinForm.exe"

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{9D741088-F0BB-471F-9640-1E70D2557BC2}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
;AppVerName={#MyAppName} {#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName=C:\Sosyal Hizmet
DisableDirPage=yes
DisableProgramGroupPage=yes
OutputDir=C:\Users\secki\Desktop
OutputBaseFilename=Choice SHM ETO V.1.8
SetupIconFile=C:\Users\secki\Documents\Visual Studio 2017\Projects\ChoiceSosyalHizmet.Entity\ChoiceSosyalHizmet.WinForm\shm.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "turkish"; MessagesFile: "compiler:Languages\Turkish.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "C:\Users\secki\Documents\Visual Studio 2017\Projects\ChoiceSosyalHizmet.Entity\ChoiceSosyalHizmet.WinForm\bin\Debug\ChoiceSosyalHizmet.WinForm.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "C:\Users\secki\Documents\Visual Studio 2017\Projects\ChoiceSosyalHizmet.Entity\ChoiceSosyalHizmet.WinForm\bin\Debug\*"; DestDir: "C:\Sosyal Hizmet\"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\secki\Documents\Visual Studio 2017\Projects\ChoiceSosyalHizmet.Entity\ChoiceSosyalHizmet.WinForm\bin\Debug\Recovery\DBChoice.db"; DestDir: "C:\Sosyal Hizmet\Data"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{commonprograms}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{commondesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#StringChange(MyAppName, '&', '&&')}}"; Flags: nowait postinstall skipifsilent

