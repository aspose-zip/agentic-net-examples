// HOW-TO: Compress a Folder into a XAR Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip.Xar;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "reports";
            string outputXarPath = "reports.xar";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputXarPath) ?? ".");

            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntries(inputDirectory, includeRootDirectory: false, compressionSettings: defaultCompression);
                archive.Save(outputXarPath);
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
 * 1. When you need to bundle a set of generated reports into a single XAR file for efficient storage or transfer in a .NET application.
 * 2. When you want to create a portable archive of log files to send to a remote support team while preserving directory structure using Aspose.Zip.
 * 3. When your deployment pipeline requires compressing build artifacts into XAR format before uploading to a cloud repository.
 * 4. When implementing a backup solution that archives user documents into XAR archives to reduce disk usage on Windows servers.
 * 5. When integrating a C# service that periodically compresses temporary data folders into XAR archives for archival compliance.
 */
