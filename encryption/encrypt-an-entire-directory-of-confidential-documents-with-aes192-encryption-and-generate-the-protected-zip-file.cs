// HOW-TO: Encrypt a Folder to AES192 Protected Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output ZIP file paths
            string inputDirectory = @"C:\Data\Confidential";
            string outputZipPath = @"C:\Data\Encrypted\confidential.zip";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDir);

            // Open the output ZIP file stream
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Create an Archive with AES192 encryption for all entries
                using (Archive archive = new Archive(
                    new ArchiveEntrySettings(
                        null,
                        new AesEcryptionSettings("MySecretPassword", EncryptionMethod.AES192))))
                {
                    // Collect all files from the input directory (including subfolders)
                    List<string> files = new List<string>(Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories));

                    foreach (string filePath in files)
                    {
                        // Compute the entry name relative to the input directory
                        string entryName = filePath.Substring(inputDirectory.Length).TrimStart(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                        // Open source file stream
                        using (FileStream sourceStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                        {
                            // Add the file to the archive; encryption settings are inherited from the archive
                            archive.CreateEntry(entryName, sourceStream);
                        }
                    }

                    // Save the archive to the ZIP file
                    archive.Save(zipStream);
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
 * 1. When you need to securely back up confidential client files by creating an AES‑192 encrypted ZIP archive from a local directory in a C# application.
 * 2. When a compliance‑driven system must transmit sensitive documents over an insecure network, you can encrypt the entire folder into a password‑protected ZIP using Aspose.Zip.
 * 3. When automating nightly data archiving for a financial service, you can compress and AES‑192 encrypt the day’s reports into a single ZIP file before storing them in cloud storage.
 * 4. When building a document‑management portal that allows users to download multiple protected files at once, you can package the selected folder into an AES‑192 encrypted ZIP on the fly.
 * 5. When implementing a secure export feature for medical records, you can ensure HIPAA compliance by encrypting the exported directory with AES‑192 and delivering it as a ZIP file.
 */
