// HOW-TO: Create 7z Archive with Four Files Using 4 Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"C:\Docs\doc1.txt";
            string inputPath2 = @"C:\Docs\doc2.txt";
            string inputPath3 = @"C:\Docs\doc3.txt";
            string inputPath4 = @"C:\Docs\doc4.txt";

            // Verify each input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }
            if (!File.Exists(inputPath4))
            {
                Console.Error.WriteLine($"File not found: {inputPath4}");
                return;
            }

            // Hardcoded output path
            string outputPath = @"C:\Output\multiThread.7z";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LZMA2 compression with 4 threads
            SevenZipLZMA2CompressionSettings lzma2Settings = new SevenZipLZMA2CompressionSettings();
            lzma2Settings.CompressionThreads = 4;
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzma2Settings);

            // Create the 7z archive and add files
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("doc1.txt", fs1);
                }
                using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("doc2.txt", fs2);
                }
                using (FileStream fs3 = new FileStream(inputPath3, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("doc3.txt", fs3);
                }
                using (FileStream fs4 = new FileStream(inputPath4, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("doc4.txt", fs4);
                }

                // Save the archive to the specified output path
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
 * 1. When you need to bundle several text documents into a single 7z file for easier distribution while controlling CPU usage.
 * 2. When you want to speed up LZMA2 compression by allocating four parallel threads in a .NET application.
 * 3. When you must ensure the output archive is created in a specific folder and the folder is created automatically if missing.
 * 4. When you need to verify that each source file exists before adding it to the archive to avoid runtime errors.
 * 5. When you are building a backup utility that compresses multiple files into a multi‑threaded 7z archive for efficient storage.
 */
