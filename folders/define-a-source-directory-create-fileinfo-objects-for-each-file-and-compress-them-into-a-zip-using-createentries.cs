// HOW-TO: Compress All Files in a Folder to ZIP Using Aspose.Zip C# (Aspose.ZIP for .NET)
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
            // Define source directory and output zip file paths (hardcoded)
            string sourceDirectory = @"C:\Data\Source";
            string outputZipPath = @"C:\Data\Output\archive.zip";

            // Verify source directory exists
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Create output directory unconditionally
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Get FileInfo objects for each file in the source directory
            DirectoryInfo dirInfo = new DirectoryInfo(sourceDirectory);
            FileInfo[] files = dirInfo.GetFiles();

            // Create a new ZIP archive and add all entries from the directory
            using (Archive archive = new Archive())
            {
                // Add all files from the directory (including subfolders if needed)
                archive.CreateEntries(dirInfo);

                // Save the archive to the output file
                using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
                {
                    ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                    {
                        Encoding = Encoding.UTF8
                    };
                    archive.Save(zipStream, saveOptions);
                }
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically archive all files from a specific folder into a single ZIP file for backup or distribution using C# and Aspose.Zip.
 * 2. When an application must generate a compressed package of generated reports stored in a directory before sending them via email or uploading to cloud storage.
 * 3. When you want to create a ZIP archive with UTF‑8 encoded entry names to ensure proper handling of international characters in file names.
 * 4. When a deployment script has to bundle configuration files from a known location into a ZIP archive as part of an automated build process.
 * 5. When a desktop utility must compress user‑selected folder contents into a ZIP archive without relying on external tools, using Aspose.Zip’s CreateEntries method.
 */
