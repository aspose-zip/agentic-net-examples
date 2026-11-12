// HOW-TO: Create Parallel Bzip2 TAR Archive of MP4 Videos in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing video files
            string dataDir = "data";
            // Hardcoded output path for the compressed TAR.BZ2 archive
            string outputPath = "output/parallel.tar.bz2";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Bzip2 archive and set the TAR archive as its source
            using (Bzip2Archive bz2 = new Bzip2Archive())
            {
                using (TarArchive tar = new TarArchive())
                {
                    // Get all video files (e.g., .mp4) from the input directory
                    string[] videoFiles = Directory.GetFiles(dataDir, "*.mp4");
                    foreach (string filePath in videoFiles)
                    {
                        // Verify each input file exists
                        if (!File.Exists(filePath))
                        {
                            Console.Error.WriteLine($"File not found: {filePath}");
                            continue;
                        }

                        // Use the file name as the entry name inside the TAR archive
                        string entryName = Path.GetFileName(filePath);
                        tar.CreateEntry(entryName, filePath);
                    }

                    // Set the TAR archive as the source for Bzip2 compression
                    bz2.SetSource(tar);
                }

                // Configure Bzip2 save options with 16 compression threads
                Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                saveOptions.CompressionThreads = 16;

                // Save the compressed archive to the specified output path
                bz2.Save(outputPath, saveOptions);
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
 * 1. When you need to bundle multiple large MP4 video files into a single .tar.bz2 archive for efficient storage or transfer while leveraging multi‑threaded compression in a .NET application.
 * 2. When you want to generate a compressed backup of a video directory that can be decompressed on Unix/Linux systems using standard tar and bzip2 tools.
 * 3. When you are building a media‑distribution pipeline that packages videos into a portable archive before uploading to cloud storage, reducing upload time with 16 compression threads.
 * 4. When you require a C# solution to create a Bzip2‑compressed TAR stream on the fly without writing intermediate files to disk, improving performance for large media collections.
 * 5. When you need to automate the creation of a .tar.bz2 archive for video assets in a CI/CD process, ensuring consistent compression settings across builds.
 */
