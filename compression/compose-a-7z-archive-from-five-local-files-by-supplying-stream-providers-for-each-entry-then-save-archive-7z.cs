// HOW-TO: Create a 7z Archive From Multiple Files Using Stream Providers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"C:\Temp\File1.txt";
            string inputPath2 = @"C:\Temp\File2.txt";
            string inputPath3 = @"C:\Temp\File3.txt";
            string inputPath4 = @"C:\Temp\File4.txt";
            string inputPath5 = @"C:\Temp\File5.txt";

            // Verify each input file exists
            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }
            if (!File.Exists(inputPath4)) { Console.Error.WriteLine($"File not found: {inputPath4}"); return; }
            if (!File.Exists(inputPath5)) { Console.Error.WriteLine($"File not found: {inputPath5}"); return; }

            // Output archive path
            string outputPath = @"C:\Temp\archive.7z";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new 7z archive
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add entries using stream providers
                archive.CreateEntry("File1.txt", () => File.OpenRead(inputPath1));
                archive.CreateEntry("File2.txt", () => File.OpenRead(inputPath2));
                archive.CreateEntry("File3.txt", () => File.OpenRead(inputPath3));
                archive.CreateEntry("File4.txt", () => File.OpenRead(inputPath4));
                archive.CreateEntry("File5.txt", () => File.OpenRead(inputPath5));

                // Save the archive to disk
                archive.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several log or configuration files into a single 7z archive for easier distribution or backup in a .NET application.
 * 2. When you want to generate a compressed package on the fly without loading entire files into memory, using stream providers for efficient I/O.
 * 3. When you are implementing a custom backup solution that must create a 7z archive from files located in different directories on a Windows server.
 * 4. When you need to programmatically create a 7z archive to send as an email attachment or upload to cloud storage from a C# service.
 * 5. When you are building a deployment tool that assembles selected resources into a 7z archive before installing them on target machines.
 */
