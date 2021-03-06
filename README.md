# Il2CppInspector
Extract types, methods, properties and fields from Unity IL2CPP binaries.

* Supports ELF (Android .so) and PE (Windows .exe) file formats
* Supports ARM, ARMv7 Thumb (T1) and x86 architectures regardless of file format
* Supports metadata versions 21 and 22
* No manual reverse-engineering required; all data is calculated automatically
* **Il2CppInspector** re-usable class library

Targets .NET Standard 1.6. Built with Visual Studio 2017.

### Build instructions

```
git clone --recursive https://github.com/djkaty/Il2CppInspector
cd Il2CppInspector
dotnet restore -r win7-x86
dotnet publish -c Release -r win7-x86
```

This will build Il2CppInspector for Windows 7 and later. For MacOS and Linux, replace `win7-x86` with a RID from https://docs.microsoft.com/en-us/dotnet/articles/core/rid-catalog

The output binary is placed in `Il2CppInspector/Il2CppDumper/bin/Release/netstandard1.6/win7-x86/publish`.

### Usage

```
Il2CppDumper [<binary-file> [<metadata-file> [<output-file>]]]
```

Defaults if not specified:

- _binary-file_ - searches for `libil2cpp.so` and `GameAssembly.dll`
- _metadata-file_ - `global-metadata.dat`
- _output-file_ - `types.cs`

File format and architecture are automatically detected.

### Help with iOS support

Mach-O (iOS) file format is not currently supported. Please contact me via the contact form at http://www.djkaty.com if you have a rooted iOS device and can produce cracked IPA files.

### Acknowledgements

Thanks to the following individuals whose code and research helped me develop this tool:

- Perfare - https://github.com/Perfare/Il2CppDumper
- Jumboperson - https://github.com/Jumboperson/Il2CppDumper
- nevermoe - https://github.com/nevermoe/unity_metadata_loader
- branw - https://github.com/branw/pogo-proto-dumper
- fry - https://github.com/fry/d3
- ARMConvertor - http://armconverter.com

This tool uses Perfare's Il2CppDumper code as a base.

### License

All rights reserved. Unauthorized use, re-use or the creation of derivative works of this code for commercial purposes whether directly or indirectly is strictly prohibited. Use, re-use or the creation of derivative works for non-commercial purposes is expressly permitted.
