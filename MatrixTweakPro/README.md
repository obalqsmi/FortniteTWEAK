# Matrix Tweak Pro

Matrix Tweak Pro is a Windows-only WPF utility that applies reversible performance tweaks for competitive gaming. It features a Matrix rain UI and one-click revert.

## Build
```bash
dotnet publish MatrixTweakPro.sln -c Release -r win-x64 -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true -p:PublishTrimmed=false
```

## Testing
```bash
dotnet test MatrixTweakPro.sln
```

## Notes
- Requires Windows and administrator privileges.
- Restore points are created before applying tweaks when available.
- Revert scripts are generated under `Desktop/MatrixTweakPro-Revert` when tweaks are applied.

Screenshots:
![Dashboard](screenshots/dashboard.png)
![Tweaks](screenshots/tweaks.png)
