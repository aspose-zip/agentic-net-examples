// HOW-TO: Create Password Protected ZIP with Multiple Files in C# (Aspose.ZIP for .NET)
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
            string inputDir = @"C:\Data\";
            string filePath1 = Path.Combine(inputDir, "file1.txt");
            string filePath2 = Path.Combine(inputDir, "file2.txt");
            string filePath3 = Path.Combine(inputDir, "file3.txt");
            string outputPath = @"C:\Output\protected.zip";

            // Validate input files
            if (!File.Exists(filePath1))
            {
                Console.Error.WriteLine($"File not found: {filePath1}");
                return;
            }
            if (!File.Exists(filePath2))
            {
                Console.Error.WriteLine($"File not found: {filePath2}");
                return;
            }
            if (!File.Exists(filePath3))
            {
                Console.Error.WriteLine($"File not found: {filePath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the ZIP archive with traditional password protection
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            using (FileStream source1 = File.Open(filePath1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(filePath2, FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(filePath3, FileMode.Open, FileAccess.Read))
            {
                ArchiveEntrySettings defaultSettings = new ArchiveEntrySettings(
                    null,
                    new TraditionalEncryptionSettings("MyPassword")
                );

                using (Archive archive = new Archive(defaultSettings))
                {
                    archive.CreateEntry("file1.txt", source1);
                    archive.CreateEntry("file2.txt", source2);
                    archive.CreateEntry("file3.txt", source3);
                    archive.Save(zipFile);
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
 * 1. When you need to securely bundle several log files before sending them over email, you can create a password‑protected ZIP archive in C#.
 * 2. When automating backup of configuration text files on a Windows server, you can compress them into an encrypted ZIP to prevent unauthorized access.
 * 3. When delivering confidential reports to clients, you can generate a traditional encrypted ZIP with a shared password using Aspose.Zip for .NET.
 * 4. When implementing a file‑export feature that packages selected documents into a single archive, you can protect the archive with a password to meet compliance requirements.
 * 5. When integrating a batch processing job that archives processed data files, you can create a password‑protected ZIP to store the files safely before archiving them long‑term.
 */
