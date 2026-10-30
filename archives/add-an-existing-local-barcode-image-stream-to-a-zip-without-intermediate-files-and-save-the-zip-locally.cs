// HOW-TO: Add Image Stream To ZIP Archive Directly In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths for the source image and the resulting ZIP file
            string inputImagePath = "C:\\Data\\barcode.png";
            string outputZipPath = "C:\\Data\\output.zip";

            // Verify that the source image file exists
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDirectory);

            // Open the image file as a stream
            using (FileStream imageStream = new FileStream(inputImagePath, FileMode.Open, FileAccess.Read))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add the image stream to the archive as an entry named "barcode.png"
                    archive.CreateEntry("barcode.png", imageStream);

                    // Save the archive to the specified output path
                    archive.Save(outputZipPath);
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
 * 1. When you need to package a barcode PNG generated in memory into a ZIP file for distribution without creating temporary files.
 * 2. When you want to compress multiple generated images on the fly before uploading them to a server.
 * 3. When an application must create a downloadable archive of scanned documents directly from streams to reduce I/O overhead.
 * 4. When you are building a reporting tool that bundles chart images into a ZIP for email attachment without writing intermediate files to disk.
 * 5. When you need to archive log screenshots or UI snapshots in a secure folder while preserving the original stream data.
 */
