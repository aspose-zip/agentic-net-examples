// HOW-TO: Extract Specific MP3 From TAR.XZ Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Xz;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "music.tar.xz";
            string outputPath = "output/track2.mp3";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Decompress the .xz archive to obtain the TAR payload
            using (XzArchive xzArchive = new XzArchive(inputPath))
            {
                using (MemoryStream tarStream = new MemoryStream())
                {
                    // Extract the decompressed TAR data into a memory stream
                    xzArchive.Extract(tarStream);
                    tarStream.Position = 0;

                    // Load the TAR archive from the memory stream
                    using (TarArchive tarArchive = new TarArchive(tarStream))
                    {
                        // Locate the specific entry
                        TarEntry entry = tarArchive.Entries.FirstOrDefault(e => e.Name == "track2.mp3");
                        if (entry == null)
                        {
                            Console.Error.WriteLine("Entry 'track2.mp3' not found in the TAR archive.");
                            return;
                        }

                        // Extract the entry to the output file
                        using (FileStream outputFile = File.Create(outputPath))
                        {
                            entry.Extract(outputFile);
                        }
                    }
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically retrieve a single track from a compressed music collection distributed as a .tar.xz file.
 * 2. When an application must decompress a .xz archive, read its TAR contents, and save a particular MP3 without extracting the entire archive.
 * 3. When building a media server that automatically extracts metadata or audio files from archived releases packaged in TAR.XZ format.
 * 4. When integrating Aspose.Zip in a C# tool to selectively extract files from nested compression layers for backup or processing.
 * 5. When processing large distribution packages where only one specific file, such as track2.mp3, is required for further analysis or playback.
 */
