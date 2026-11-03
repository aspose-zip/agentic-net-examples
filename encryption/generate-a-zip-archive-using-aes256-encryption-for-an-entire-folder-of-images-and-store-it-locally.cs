// HOW-TO: Create AES256 Encrypted ZIP of Image Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input folder containing images and output ZIP path
        string inputFolder = @"C:\Images";
        string outputZip = @"C:\Output\images_encrypted.zip";

        // Validate input folder
        if (!Directory.Exists(inputFolder))
        {
            Console.Error.WriteLine($"Directory not found: {inputFolder}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

        try
        {
            using (FileStream zipStream = File.Open(outputZip, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputFolder);
                FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

                foreach (FileInfo file in files)
                {
                    // Validate each file before processing
                    if (!File.Exists(file.FullName))
                    {
                        Console.Error.WriteLine($"File not found: {file.FullName}");
                        continue;
                    }

                    // Open the source file stream
                    using (FileStream fileStream = file.OpenRead())
                    {
                        // Compute entry name relative to the input folder
                        string entryName = Path.GetRelativePath(inputFolder, file.FullName);

                        // Set AES256 encryption for the entry
                        ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                            null,
                            new AesEcryptionSettings("SamplePassword123", EncryptionMethod.AES256));

                        // Add the entry to the archive with encryption
                        archive.CreateEntry(entryName, fileStream, entrySettings);
                    }
                }

                // Save the encrypted ZIP archive
                archive.Save(zipStream);
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
 * 1. When you need to securely back up a collection of photos before uploading them to cloud storage, you can encrypt the entire folder into a ZIP file using AES256 in C#.
 * 2. When transmitting confidential product images to a partner over an insecure network, you can package and encrypt the folder as a ZIP archive to protect the data.
 * 3. When complying with data‑protection regulations that require encryption of personal image files, you can generate an AES‑256 encrypted ZIP archive programmatically in a .NET application.
 * 4. When creating a downloadable asset bundle for a desktop application that must prevent users from easily extracting the images, you can encrypt the bundle with AES256 during ZIP creation.
 * 5. When automating nightly archiving of surveillance camera snapshots, you can compress the daily folder and apply AES256 encryption to keep the images safe on local storage.
 */
