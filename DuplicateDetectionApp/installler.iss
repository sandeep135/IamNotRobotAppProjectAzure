﻿[Setup]
AppName=IAmNotRobotAppAzure
AppVersion=1.0
DefaultDirName={pf}\IAmNotRobotAppAzure
DefaultGroupName=IAmNotRobotAppAzure
OutputDir=Output
OutputBaseFilename=IAmNotRobotAppAzureSetup
Compression=lzma
SolidCompression=yes

[Files]
Source: "bin/Debug/*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin/Debug/*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "bin/Debug/*.exe.config"; DestDir: "{app}"; Flags: ignoreversion
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\IAmNotRobotAppAzure"; Filename: "{app}\IAmNotRobotAppAzure.exe"; WorkingDir: "{app}"

[Run]
Filename: "{app}\IAmNotRobotAppAzure.exe"; Description: "Launch IAmNotRobotAppAzure"; Flags: nowait postinstall skipifsilent