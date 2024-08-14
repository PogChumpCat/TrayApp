#define MyAppName "TrayApp"
#define MyAppVersion "1.2.0"
#define MyAppURL ""
#define MyAppPublisher "Nesterak Oleksandr"
#define MyAppExeName "TrayApp.exe"

[Setup]
SignTool=signtool
Uninstallable=yes
AppId={{A4F52347-7CE4-49DF-A554-89FF3413D5AD}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={pf}\TrayApp
DefaultGroupName=TrayApp
UninstallDisplayIcon={app}\TrayApp.exe
CreateAppDir=yes
OutputDir=C:\Users\Oleksandr\Desktop
OutputBaseFilename=TrayApp Installer
Compression=lzma
SolidCompression=yes


[Icons]
Name: "{group}\TrayApp"; Filename: "{app}\TrayApp.exe"; WorkingDir: "{app}"; IconFilename: "{app}\TrayApp.exe"
Name: "{group}\TrayApp"; Filename: "{uninstallexe}"; IconFilename: "{app}\uninstall.ico"

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "C:\Users\Oleksandr\source\repos\TrayApp\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion recursesubdirs createallsubdirs
Source: "C:\Users\Oleksandr\Desktop\Resources\*"; DestDir: "{userappdata}\TrayApp";
Source: "C:\Users\Oleksandr\Desktop\Resources\Images\*"; DestDir: "{userappdata}\TrayApp\Images";

[InstallDelete]
Type: filesandordirs; Name: "{commoncf32}\TrayApp"