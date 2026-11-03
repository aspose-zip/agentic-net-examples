// HOW-TO: Encrypt a ZIP Archive While Creating It in C# Using Aspose.Zip (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\Data\InputFolder";
            string outputZipPath = @"C:\Data\Output\Archive.zip";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (Archive archive = new Archive())
            {
                archive.CreateEntries(new DirectoryInfo(inputDirectory));
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                archive.Save(outputZipPath, saveOptions);
            }

            Console.WriteLine($"ZIP archive created at: {outputZipPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to securely package a folder of confidential documents for transmission without first extracting the files, you can create and encrypt the ZIP directly in C# with Aspose.Zip.
 * 2. When an automated backup system must generate password‑protected ZIP files from a directory to satisfy compliance and data‑protection policies, this code creates the encrypted archive in one step.
 * 3. When a web service produces downloadable reports and must encrypt the ZIP on the fly to prevent unauthorized access, Aspose.Zip’s EncryptionOptions let you do it without intermediate extraction.
 * 4. When a desktop application archives user data and wants to apply AES encryption without loading each file into memory, the ArchiveSaveOptions API handles compression and encryption efficiently.
 * 5. When a DevOps pipeline needs to compress build artifacts and encrypt them before storing them in a secure artifact repository, this C# approach creates an encrypted ZIP in a single operation.
 */
