// HOW-TO: Encrypt a Single Image into a Password Protected ZIP in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input image file and output zip file paths
            string inputPath = @"C:\Data\image.jpg";
            string outputPath = @"C:\Output\encrypted.zip";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output zip file stream
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Open the source image file stream
                using (FileStream source = File.Open(inputPath, FileMode.Open, FileAccess.Read))
                {
                    // Set up traditional password protection for entries
                    ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                        null,
                        new TraditionalEncryptionSettings("MyPassword")
                    );

                    // Create the archive with the entry settings
                    using (Archive archive = new Archive(entrySettings))
                    {
                        // Add the image file to the archive
                        archive.CreateEntry("image.jpg", source);

                        // Save the archive to the zip file stream
                        archive.Save(zipFile);
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
 * 1. When you need to email a confidential photo and want to protect it with a password‑protected ZIP file using C#.
 * 2. When you must store medical or legal images securely on disk by encrypting them inside a ZIP archive with traditional password protection.
 * 3. When you want to back up sensitive design assets such as product renders and ensure they are encrypted before uploading to cloud storage.
 * 4. When your application must comply with data‑privacy regulations by delivering encrypted image files in a ZIP container to external partners.
 * 5. When you need to programmatically create a password‑protected ZIP of a single image for secure distribution to clients without using third‑party tools.
 */
