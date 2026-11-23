# P5 ENV Editor
A GUI tool for viewing, editing and saving ENV files from Persona 5. Currently only vanilla Persona 5 ENV files are supported, Royal support will come later.

This program requires you have [.NET Desktop Runtime 10](https://dotnet.microsoft.com/en-us/download/dotnet/10.0/runtime) installed to use. Only Windows is officially supported however it should work fine on Linux using Wine. 

<img width="426" height="512" alt="A screenshot of the Fog tab in P5 ENV Editor" src="https://github.com/user-attachments/assets/3af5647c-f52a-44e6-bbd7-1729e713591f" />

## How to Use
- Download the latest [release](https://github.com/ARandomGuy231/P5ENVEditor/releases) and extract the zip on your PC.
- Open P5ENVEditor.exe and drag and drop the ENV file you want to edit into the editor or click File > Open to browse for one.
  - The editor will warn you if you load a partially supported ENV version, take care when editing these files as some parameters may be incorrect.
- Make any changes you wish to make and press Ctrl+S to save the file, or click File > Save As to make a new ENV file.
  - Some parameters are named differently compared to the [010 Editor template](https://github.com/tge-was-taken/010-Editor-Templates/blob/master/templates/p5_env.bt). This is due to me using  the debug editor in the Feb 2016 beta as a reference, so some parameters that were incorrectly named/unamed are now named in this editor.

When encountering bugs or issues, please include the ENV file you were trying to edit and the log files found in the same folder as the editor, this helps massively when looking into issues.

## Planned Features
- Live ENV editing. Allowing you to use the editor to make changes and see them in-game in real time, RPCS3 only for now.

## Supported ENV Versions
A table of supported and unsupported ENV versions, you can check your ENV version by loading the file in the editor and looking at the version label on the bottom left. If you get an unsupported version error on a file that should be supported, please make a new issue so I can look into it.
| Key | Status | Description |
| :---: | :---: | --- |
|✅| Full Support | Can safely and reliably load and save. |
|🟡| Partial Support | Can load but may have disabled or incorrect values in the editor, may not save correctly. The editor will warn you when a partially supported version is loaded. |
|❌| No Support | Cannot load or save. The editor will tell you when an unsupported version is loaded. |

| ENV Version | Status | Game | Notes |
|:---:|:---:|:---:|:---:|
| Below 0x1104900 | ❌ | Persona 5 | Not many files use versions below this and will not be supported. |
| 0x1104900 to 0x1105040 | 🟡 | Persona 5 | A handful of files use these versions. They will load but may have incorrect values, please report any issues. |
| 0x1105050 to 0x1105070 | ✅ | Persona 5 | Most commonly used versions in the game, all files using these versions are fully supported. |
| 0x1105080 | ❌ | Persona 5 Royal | An undocumented version found in 31 files. Support will not be added unless it becomes documented. |
| 0x1105090 | ❌ | Persona 5 Royal | Support could be added but due to the amount of differences and the fact that only 16 files use this version it isn't planned.  |
| 0x1105100 | ✅ | Persona 5 Royal | Majority of the files in Royal use this version, it is fully supported in v1.1.0 and above. |

## Special Thanks
- [TGE](https://github.com/tge-was-taken), [Lyn](https://github.com/lyncpk), Sierra and [SecreC](https://github.com/Secre-C) for their work on the [010 Editor template](https://github.com/tge-was-taken/010-Editor-Templates/blob/master/templates/p5_env.bt), which was used as a base for paramater names, types, locations and more.
