// HOW-TO: Create Split ZIP Archive of Combined Video Files with Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string[] videoFiles = new string[]
            {
                "C:\\Videos\\part1.mp4",
                "C:\\Videos\\part2.mp4"
            };

            foreach (string inputPath in videoFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            using (MemoryStream combinedStream = new MemoryStream())
            {
                foreach (string inputPath in videoFiles)
                {
                    using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
                    {
                        fileStream.CopyTo(combinedStream);
                    }
                }
                combinedStream.Position = 0;

                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("combined_video.mp4", combinedStream);

                    SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("video", 1 * 1024 * 1024);

                    string outputDir = "C:\\Output\\VideoArchive";

                    Directory.CreateDirectory(outputDir);
                    Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

                    archive.SaveSplit(outputDir, saveOptions);
                }
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
 * 1. When you need to merge multiple video parts into a single file and distribute it as small, 1 MiB ZIP chunks that can be uploaded to services with file‑size limits.
 * 2. When your application must create a split ZIP archive for large media assets so that each segment fits on removable media such as USB drives or DVDs.
 * 3. When you want to programmatically combine video streams and store them in a ZIP archive that can be later reassembled without manual extraction.
 * 4. When you have to generate a multi‑part archive on a server for clients to download in parallel, ensuring each part is under a specific size threshold.
 * 5. When you need to automate the creation of split ZIP files for backup or archival of large video files using Aspose.Zip in a .NET environment.
 */
