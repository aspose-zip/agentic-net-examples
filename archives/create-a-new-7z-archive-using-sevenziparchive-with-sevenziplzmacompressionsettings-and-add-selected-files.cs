// HOW-TO: Create a 7z Archive With LZMA Compression Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputFiles = new string[]
            {
                @"C:\Data\file1.txt",
                @"C:\Data\file2.txt"
            };

            string outputPath = @"C:\Output\archive.7z";

            foreach (string filePath in inputFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<FileStream> openStreams = new List<FileStream>();

            using (SevenZipArchive archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMACompressionSettings())))
            {
                foreach (string filePath in inputFiles)
                {
                    FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    openStreams.Add(stream);
                    archive.CreateEntry(Path.GetFileName(filePath), stream);
                }

                archive.Save(outputPath);
            }

            foreach (FileStream stream in openStreams)
            {
                stream.Dispose();
            }

            Console.WriteLine("Archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically bundle multiple log files into a highly compressed 7z archive for efficient storage or transfer.
 * 2. When you want to generate a backup of selected configuration files in a .NET application using LZMA compression to minimize archive size.
 * 3. When an automated deployment script must package build artifacts into a 7z file before uploading to a remote server.
 * 4. When a desktop utility needs to create a password‑free 7z archive of user‑chosen documents without loading the entire files into memory.
 * 5. When a data‑processing service must archive processed CSV files into a single 7z container for archival compliance.
 */
