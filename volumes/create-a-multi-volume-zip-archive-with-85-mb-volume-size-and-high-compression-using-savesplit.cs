// HOW-TO: Create Multi‑Volume Zip Archive With 85 MB Parts And High Compression In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing files to be archived
            string inputDirectory = @"C:\Data\SourceFiles";
            // Hardcoded output directory and base archive name
            string outputDirectory = @"C:\Data\Output";
            string outputPath = Path.Combine(outputDirectory, "multivolume.zip");

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // High compression settings for all entries
            ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(new EnhancedDeflateCompressionSettings());

            using (Archive archive = new Archive(entrySettings))
            {
                // Add all files from the input directory (including subfolders)
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                FileInfo[] files = dirInfo.GetFiles("*", SearchOption.AllDirectories);
                foreach (FileInfo file in files)
                {
                    // Validate each file before adding
                    if (!File.Exists(file.FullName))
                    {
                        Console.Error.WriteLine($"File not found: {file.FullName}");
                        continue;
                    }

                    // Preserve relative path inside the zip archive
                    string entryName = Path.GetRelativePath(inputDirectory, file.FullName);
                    archive.CreateEntry(entryName, file);
                }

                // Configure split (multi‑volume) options with 85 MB volume size
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(85 * 1024 * 1024);

                // Save the archive as split volumes
                archive.SaveSplit(outputPath, saveOptions);
            }

            Console.WriteLine("Multi‑volume ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up a large folder to removable media that only accepts files up to 85 MB, you can split the archive into multiple high‑compression volumes using Aspose.Zip in C#.
 * 2. When distributing a software package over email or a file‑sharing service that imposes a maximum attachment size, creating a multi‑volume zip with 85 MB parts ensures each piece meets the limit while keeping the overall size minimal.
 * 3. When archiving log files for long‑term retention on a network drive with quota restrictions, splitting the archive into 85 MB compressed volumes allows you to stay within the quota and speed up future extraction.
 * 4. When implementing a custom backup solution that must compress data heavily and store it on DVDs or Blu‑ray discs with fixed capacity, generating high‑compression split archives simplifies the process of writing each volume to the disc.
 * 5. When building an automated deployment pipeline that packages large binaries and resources, using Aspose.Zip to create split archives with a defined volume size enables parallel upload and reliable resume of interrupted transfers.
 */
