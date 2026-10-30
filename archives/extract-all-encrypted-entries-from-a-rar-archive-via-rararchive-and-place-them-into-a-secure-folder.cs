// HOW-TO: Extract Encrypted RAR Files to Secure Folder Using C# Aspose (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\encrypted.rar";
            string outputPath = @"C:\SecureFolder";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream fs = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fs, new RarArchiveLoadOptions() { DecryptionPassword = "password123" }))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to automatically pull password‑protected RAR logs from a server and place them in a protected directory for compliance auditing.
 * 2. When a backup system stores encrypted RAR archives and you must programmatically extract their contents to a secure location before further processing.
 * 3. When a desktop application must read confidential RAR‑packed documents using a known password and save them to a restricted folder to prevent unauthorized access.
 * 4. When integrating a file‑transfer workflow that receives encrypted RAR shipments and you need to decrypt and extract them directly into an isolated storage area.
 * 5. When building a C# utility that validates and extracts encrypted RAR archives as part of a security‑oriented data pipeline, ensuring the output is written to a safe folder.
 */
