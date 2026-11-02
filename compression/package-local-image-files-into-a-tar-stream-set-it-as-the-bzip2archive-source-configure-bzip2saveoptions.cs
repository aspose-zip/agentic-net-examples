// HOW-TO: Create a Bzip2 Compressed TAR Archive With Multi‑Threading in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string inputPath1 = Path.Combine(dataDir, "image1.jpg");
            string inputPath2 = Path.Combine(dataDir, "image2.png");
            string outputPath = Path.Combine(dataDir, "parallel.tar.bz2");

            // Validate input files
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add image files
            using (TarArchive tar = new TarArchive())
            {
                tar.CreateEntry("image1.jpg", inputPath1);
                tar.CreateEntry("image2.png", inputPath2);

                // Create Bzip2 archive, set TAR as source, configure options, and save
                using (Bzip2Archive bz2 = new Bzip2Archive())
                {
                    bz2.SetSource(tar);
                    Bzip2SaveOptions options = new Bzip2SaveOptions();
                    options.CompressionThreads = 12;
                    bz2.Save(outputPath, options);
                }
            }

            Console.WriteLine("Archive created successfully: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several image files into a single TAR file and compress it with Bzip2 to reduce size while taking advantage of multiple CPU cores in a C# application.
 * 2. When you want to generate a .tar.bz2 backup of media assets for efficient storage or transfer over limited‑bandwidth networks using Aspose.Zip.
 * 3. When your deployment pipeline requires creating a compressed archive of resources on the fly, and you want to control the number of compression threads for optimal performance.
 * 4. When you are building a cross‑platform tool that archives files into TAR and then applies Bzip2 compression, ensuring the output can be extracted by standard Unix utilities.
 * 5. When you need to programmatically create a high‑compression archive of images for archival purposes, and you want to specify a custom thread count to speed up the Bzip2 compression step.
 */
