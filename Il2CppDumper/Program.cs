﻿// Copyright (c) 2017 Katy Coe - https://www.djkaty.com - https://github.com/djlaty
// All rights reserved

using System;
using System.IO;

namespace Il2CppInspector
{
    public class App
    {
        static void Main(string[] args) {

            // Command-line usage: dotnet run [<binary-file> [<metadata-file> [<output-file>]]]
            // Defaults to libil2cpp.so or GameAssembly.dll if binary file not specified
            string imageFile = "libil2cpp.so";
            string metaFile = "global-metadata.dat";
            string outFile = "types.cs";

            if (args.Length == 0)
                if (!File.Exists(imageFile))
                    imageFile = "GameAssembly.dll";

            if (args.Length >= 1)
                imageFile = args[0];

            if (args.Length >= 2)
                metaFile = args[1];

            if (args.Length >= 3)
                outFile = args[2];

            // Check files
            if (!File.Exists(imageFile)) {
                Console.Error.WriteLine($"File {imageFile} does not exist");
                Environment.Exit(1);
            }
            if (!File.Exists(metaFile)) {
                Console.Error.WriteLine($"File {metaFile} does not exist");
                Environment.Exit(1);
            }

            // Analyze data
            var il2cpp = Il2CppProcessor.LoadFromFile(imageFile, metaFile);
            if (il2cpp == null)
                Environment.Exit(1);

            // Write output file
            var dumper = new Il2CppDumper(il2cpp);
            dumper.WriteFile(outFile);
        }
    }
}
