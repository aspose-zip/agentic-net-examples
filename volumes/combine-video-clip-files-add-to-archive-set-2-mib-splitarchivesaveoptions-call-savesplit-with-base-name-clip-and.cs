// HOW-TO: Split Large Video Files Into Multiple ZIP Segments With C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputFiles = new string[]
            {
                "video1.mp4",
                "video2.mp4",
                "video3.mp4"
            };

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            string outputDir = "output";
            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                foreach (string inputPath in inputFiles)
                {
                    string entryName = Path.GetFileName(inputPath);
                    archive.CreateEntry(entryName, new FileInfo(inputPath));
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("clip", 2 * 1024 * 1024);
                archive.SaveSplit(outputDir, saveOptions);
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
 * 1. When you need to package several large video clips into a single archive but must keep each part under a specific size limit for email attachment or file‑system constraints.
 * 2. When distributing video assets to users who can only download small chunks, such as over slow or unstable network connections.
 * 3. When creating backup archives that must fit on multiple removable storage media like 2 MiB flash drives or legacy media.
 * 4. When preparing video files for upload to a cloud service that imposes a maximum file size per request.
 * 5. When automating a build pipeline that bundles media resources and splits the archive to comply with CI/CD artifact size restrictions.
 */
