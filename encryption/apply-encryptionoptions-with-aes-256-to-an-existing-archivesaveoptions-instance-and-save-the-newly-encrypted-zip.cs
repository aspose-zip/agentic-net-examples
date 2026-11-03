// HOW-TO: Encrypt Existing ZIP with AES‑256 Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.zip";
            string outputPath = "encrypted.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing archive
            using (Archive archive = new Archive(inputPath))
            {
                // Create save options and apply AES‑256 encryption
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.EncryptionOptions = new AesEcryptionSettings("MyStrongPassword", EncryptionMethod.AES256);

                // Save the encrypted archive to the output file
                using (FileStream outStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
                {
                    archive.Save(outStream, saveOptions);
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
 * 1. When you need to protect a previously created ZIP file before sending it over an insecure network, you can apply AES‑256 encryption with Aspose.Zip in C#.
 * 2. When regulatory compliance requires archived documents to be stored with strong encryption, this code lets you re‑encrypt an existing ZIP archive using AES‑256.
 * 3. When a backup system creates ZIP archives without encryption, you can use this approach to add AES‑256 protection to those archives before saving them to cloud storage.
 * 4. When a desktop application must allow users to secure downloaded ZIP packages with a password, the snippet demonstrates how to encrypt the archive on the fly in C#.
 * 5. When integrating with third‑party tools that only accept encrypted ZIP files, you can take an unencrypted archive and produce an AES‑256 encrypted version using Aspose.Zip’s ArchiveSaveOptions.
 */
