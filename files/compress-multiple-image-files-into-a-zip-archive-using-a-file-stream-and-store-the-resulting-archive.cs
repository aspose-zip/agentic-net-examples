// HOW-TO: Compress Multiple Images into a ZIP File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input image files and output ZIP path
            string inputFile1 = @"C:\Images\image1.jpg";
            string inputFile2 = @"C:\Images\image2.png";
            string outputZip = @"C:\Output\images.zip";

            // Verify that each input file exists
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

            // Create file streams for the ZIP archive and source images
            using (FileStream zipStream = File.Open(outputZip, FileMode.Create))
            {
                using (FileStream source1 = File.Open(inputFile1, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream source2 = File.Open(inputFile2, FileMode.Open, FileAccess.Read))
                    {
                        // Create a new ZIP archive and add the image entries
                        using (Archive archive = new Archive())
                        {
                            archive.CreateEntry("image1.jpg", source1);
                            archive.CreateEntry("image2.png", source2);

                            // Set save options such as encoding and archive comment
                            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                            saveOptions.Encoding = Encoding.ASCII;
                            saveOptions.ArchiveComment = "Compressed images archive";

                            // Save the archive to the output stream
                            archive.Save(zipStream, saveOptions);
                        }
                    }
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
 * 1. When you need to bundle several photos into a single ZIP archive for easy download or transfer in a C# web application.
 * 2. When you want to programmatically create a compressed archive of image assets with a custom comment and specific encoding using Aspose.Zip.
 * 3. When you must ensure that image files exist and the output directory is created before saving a ZIP file on the server.
 * 4. When you are building a desktop utility that compresses user‑selected pictures into a ZIP file without loading the entire files into memory.
 * 5. When you need to generate a ZIP archive of images on the fly and stream it directly to a response or storage location in .NET.
 */
