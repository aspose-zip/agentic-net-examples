// HOW-TO: Set Comment on Newly Created ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = @"C:\Temp\sample.txt";
            string outputFilePath = @"C:\Temp\Output\archive.zip";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputFilePath);
            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                FileInfo fileInfo = new FileInfo(inputFilePath);
                archive.CreateEntry(fileInfo.Name, fileInfo);
                archive.Save(outputFilePath);
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
 * 1. When you need to add a descriptive comment to a ZIP file you generate programmatically so users can see metadata about the archive in Windows Explorer or other tools.
 * 2. When automating the packaging of log files into a ZIP and want to embed the generation date and purpose as an archive comment for future reference.
 * 3. When creating downloadable resource bundles in a web application and you want to include licensing or version information inside the ZIP comment without modifying the contained files.
 * 4. When building a backup utility that stores a brief summary of the backup operation (e.g., source folder and timestamp) as a comment on each ZIP archive for quick identification.
 * 5. When integrating Aspose.Zip into a CI/CD pipeline to produce release artifacts and you need to tag each ZIP with a comment that indicates the build number and commit hash.
 */
