[Setup]
AppName=IAmNotRobotAppAzure
AppVersion=1.0
DefaultDirName={pf}\IAmNotRobotAppAzure
DefaultGroupName=IAmNotRobotAppAzure
OutputDir=Output
OutputBaseFilename=IAmNotRobotAppAzureSetup
Compression=lzma
SolidCompression=yes

[Files]
Source: "\DuplicateDetectionApp\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "\DuplicateDetectionApp\bin\Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "\DuplicateDetectionApp\bin\Release\*.exe.config"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\IAmNotRobotAppAzure"; Filename: "{app}\IAmNotRobotAppAzure.exe"; WorkingDir: "{app}"

[Run]
Filename: "{app}\IAmNotRobotAppAzure.exe"; Description: "Launch IAmNotRobotAppAzure"; Flags: nowait postinstall skipifsilent