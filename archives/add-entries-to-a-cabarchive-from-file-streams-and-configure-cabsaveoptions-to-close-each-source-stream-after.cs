// HOW-TO: Create Cab Archive With Mixed Compression From Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath1 = @"C:\Temp\file1.txt";
            string inputFilePath2 = @"C:\Temp\file2.html";
            string cabOutputPath = @"C:\Temp\output.cab";

            if (!File.Exists(inputFilePath1))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath1}");
                return;
            }
            if (!File.Exists(inputFilePath2))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath2}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(cabOutputPath));

            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                archive.CreateEntry("file1.txt", inputFilePath1);

                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());
                archive.CreateEntry("file2.html", inputFilePath2, storedSettings);

                archive.Save(cabOutputPath);
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
 * 1. When you need to bundle multiple installation files into a single CAB file, using MSZIP compression for some files and storing others unchanged for a Windows installer.
 * 2. When you want to archive log and HTML report files together, compressing the text file while keeping the HTML file uncompressed to preserve its original format.
 * 3. When creating driver packages that require certain binaries to remain uncompressed while other supporting files are compressed to reduce the overall package size.
 * 4. When automating deployment scripts in a .NET application that generate a CAB archive from configuration files and static resources in one step.
 * 5. When building a backup utility that stores selected files into a CAB archive and automatically closes each source stream after the archive is saved.
 */
