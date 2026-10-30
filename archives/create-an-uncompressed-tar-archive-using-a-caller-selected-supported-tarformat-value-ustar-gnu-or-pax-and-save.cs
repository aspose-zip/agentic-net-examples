// HOW-TO: Create Uncompressed TAR Archive With Specific Format Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "input";
            string outputPath = "output/output.tar";

            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntries(inputFolder);
                archive.Save(outputPath);
            }

            Console.WriteLine($"TAR archive created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a folder of log files into a standard TAR archive without compression for compatibility with Unix tools.
 * 2. When your application must generate a TAR file in a chosen format (USTar, GNU, or PAX) to meet legacy backup system requirements.
 * 3. When you want to create an uncompressed archive to speed up subsequent extraction on the client side while preserving file metadata.
 * 4. When integrating Aspose.Zip into a .NET service that delivers downloadable TAR bundles of source code or assets to end users.
 * 5. When automating deployment pipelines that require creating TAR archives before uploading them to a Linux server or container registry.
 */
