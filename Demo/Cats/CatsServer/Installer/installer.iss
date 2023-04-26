#ifdef RELEASE
#define AppName "CatsServer"
#else
#define AppName "CatsServerDebug"
#endif
#define GroupName "Pocota Demo"
#define AppVersion "1.0.0"
[Setup]
AppName={#AppName}
AppVersion={#AppVersion}
AppId={{19C9DCA7-5AA4-4326-83C6-84E7B1B02C44}
DefaultDirName={autopf}\{#GroupName}\{#AppName}
DefaultGroupName={#GroupName}
OutputBaseFilename={#AppName}-{#AppVersion}-install
Compression=lzma

[Files]
#ifdef RELEASE
Source: "..\bin\Release\net6.0\*"; DestDir: "{app}"; Flags: recursesubdirs;
#else
Source: "..\bin\Debug\net6.0\*"; DestDir: "{app}"; Flags: recursesubdirs;
#endif

[Run]
Filename: "{cmd}"; Parameters: "/k ""{app}\{#AppName}.EXE"" --CheckDatabase > {tmp}\check_result.txt"; Flags: waituntilterminated;
Filename: "{tmp}\check_result.txt"; Verb: open; Flags: shellexec;