// HOW-TO: Create CAB Archive with File Metadata and Save in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath1 = @"C:\Data\file1.txt";
            string inputFilePath2 = @"C:\Data\file2.html";
            string outputCabPath = @"C:\Output\archive.cab";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            FileInfo fileInfo1 = new FileInfo(inputFilePath1);
            FileInfo fileInfo2 = new FileInfo(inputFilePath2);

            CabEntrySettings defaultArchiveSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultArchiveSettings))
            {
                archive.CreateEntry(fileInfo1.Name, inputFilePath1);
                archive.CreateEntry(fileInfo2.Name, inputFilePath2);
                archive.Save(outputCabPath);
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
 * 1. When you need to bundle multiple configuration files into a single CAB file for Windows deployment while preserving original file names and timestamps.
 * 2. When automating the creation of installation packages that require CAB compression and you want to programmatically add files using their metadata in a C# application.
 * 3. When generating backup archives of web assets where the entry names must match the source filenames and the archive must retain the original modification dates.
 * 4. When integrating with legacy Windows setup programs that only accept CAB archives and you must create them on the fly from dynamic file paths in .NET.
 * 5. When building a custom installer that compresses log and report files into a CAB container and needs to store accurate timestamps for later extraction verification.
 */
