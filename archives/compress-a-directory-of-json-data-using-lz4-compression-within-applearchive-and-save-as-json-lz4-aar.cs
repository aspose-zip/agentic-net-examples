// HOW-TO: Compress JSON Files Into LZ4 Tar Archive With Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\JsonFiles";
            string outputPath = @"C:\Output\json_lz4.tar";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                string[] jsonFiles = Directory.GetFiles(inputDirectory, "*.json", SearchOption.TopDirectoryOnly);
                foreach (string filePath in jsonFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                archive.SaveLZ4Compressed(outputPath);
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
 * 1. When you need to bundle a set of JSON configuration files into a single LZ4‑compressed TAR archive for fast backup or transfer in a C# application.
 * 2. When you want to reduce the size of JSON logs before uploading them to cloud storage while preserving a standard TAR structure using Aspose.Zip.
 * 3. When a microservice must send multiple JSON payloads as a single compressed package to another service that expects a TAR.LZ4 file.
 * 4. When you are creating an offline data snapshot of JSON datasets that can be quickly decompressed on Apple devices using the AppleArchive format.
 * 5. When you need to automate the creation of a lightweight, LZ4‑compressed archive of JSON files as part of a CI/CD pipeline in .NET.
 */
