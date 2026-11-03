// HOW-TO: Create AES192 Encrypted ZIP of a PDF in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input PDF file path
            string inputPath = @"C:\Data\sample.pdf";
            // Hardcoded output ZIP file path
            string outputPath = @"C:\Output\encrypted.zip";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the output ZIP file stream
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Open the source PDF file stream
                using (FileStream source = File.Open(inputPath, FileMode.Open, FileAccess.Read))
                {
                    // Create an archive with AES192 encryption settings
                    using (Archive archive = new Archive(
                        new ArchiveEntrySettings(
                            null,
                            new AesEcryptionSettings("MySecretPassword", EncryptionMethod.AES192))))
                    {
                        // Add the PDF file to the archive
                        archive.CreateEntry("sample.pdf", source);
                        // Save the archive to the ZIP file stream
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
 * 1. When a developer must securely send a confidential PDF to a client over email, they can encrypt it in an AES192 ZIP file using C# before attaching it.
 * 2. When an application needs to store sensitive PDF reports on a shared drive, the code can create an AES192 protected ZIP to meet data‑at‑rest encryption requirements.
 * 3. When automating a workflow that archives legal documents, a developer can compress each PDF into an AES192 encrypted ZIP to comply with industry regulations.
 * 4. When building a desktop tool that backs up invoices, the code allows the PDFs to be packaged into a password‑protected ZIP with strong AES192 encryption for safe archival.
 * 5. When integrating with a third‑party system that only accepts ZIP uploads, a developer can encrypt the PDF with AES192 in C# to ensure the file remains confidential during transfer.
 */
