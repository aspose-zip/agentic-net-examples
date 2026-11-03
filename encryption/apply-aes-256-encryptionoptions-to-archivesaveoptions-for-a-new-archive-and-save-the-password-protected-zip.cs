// HOW-TO: Create AES256 Encrypted Zip Archive With Password In C# (Aspose.ZIP for .NET)
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
            string inputPath = "data\\sample.txt";
            string outputPath = "output\\protected.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create, FileAccess.Write))
            {
                ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(null, new AesEcryptionSettings("StrongPassword123", EncryptionMethod.AES256));
                using (Archive archive = new Archive(entrySettings))
                {
                    archive.CreateEntry("sample.txt", sourceStream);
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
 * 1. When you need to securely transmit confidential text files over email by packaging them into a password‑protected AES‑256 ZIP using C#.
 * 2. When your application must store sensitive configuration files in an encrypted archive to meet data‑protection compliance requirements.
 * 3. When you want to automate backup of log files into a strong‑encryption ZIP to prevent unauthorized access on shared storage.
 * 4. When integrating with third‑party systems that only accept encrypted ZIP uploads, you can generate the archive programmatically in .NET.
 * 5. When delivering downloadable resources to customers and you must ensure only users with the correct password can extract the contents.
 */
