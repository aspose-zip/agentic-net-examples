// HOW-TO: Create 7z Archive From Folder With LZMA FastBytes 256 In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = @"C:\Data\SourceFolder";
            string outputPath = @"C:\Data\Archive\output.7z";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            SevenZipLZMACompressionSettings lzmaSettings = new SevenZipLZMACompressionSettings();

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzmaSettings);

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(inputDir);
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
 * 1. When you need to package a large set of files into a single 7z archive for distribution while maximizing compression speed using LZMA FastBytes 256 in a C# application.
 * 2. When you want to automate the creation of backup archives of a directory on a Windows server using Aspose.Zip for .NET with custom LZMA settings.
 * 3. When you are building an installer that bundles resources into a 7z file with specific compression parameters to reduce download size for end users.
 * 4. When you need to generate compressed archives of log files daily, ensuring consistent compression settings across runs in a .NET service.
 * 5. When you are integrating file archiving into a CI/CD pipeline, creating 7z packages from build output with LZMA FastBytes 256 for efficient storage and transfer.
 */
