// HOW-TO: Create 7z Archive from Folder and Save with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output archive paths
            string inputDirectory = @"C:\Data\MyFolder";
            string outputArchive = @"C:\Output\MyArchive.7z";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchive));

            // Create the 7z archive, add all files from the directory, and save it
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputArchive);
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
 * 1. When you need to package a project's output files into a single 7z archive for easy distribution or deployment.
 * 2. When you want to back up a user‑generated data folder into a compressed archive before uploading it to cloud storage.
 * 3. When you must create a portable archive of log files to send to support engineers without losing directory structure.
 * 4. When an application needs to generate a compressed bundle of configuration files for automated installation scripts.
 * 5. When you are building a C# utility that archives large media collections into 7z format to reduce storage space.
 */
