// HOW-TO: Set Individual Passwords for Files in a 7z Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = "input1.txt";
            string inputPath2 = "input2.txt";
            string inputPath3 = "input3.txt";

            // Hardcoded output archive path
            string outputPath = "output/archive.7z";

            // Verify each input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create FileInfo objects for the input files
            FileInfo fi1 = new FileInfo(inputPath1);
            FileInfo fi2 = new FileInfo(inputPath2);
            FileInfo fi3 = new FileInfo(inputPath3);

            // Open the output 7z file stream
            using (FileStream sevenZipFile = File.Open(outputPath, FileMode.Create))
            {
                // Create a new SevenZipArchive
                using (SevenZipArchive archive = new SevenZipArchive())
                {
                    // Add first entry with its own password
                    archive.CreateEntry(
                        "file1.txt",
                        fi1,
                        false,
                        new SevenZipEntrySettings(
                            new SevenZipStoreCompressionSettings(),
                            new SevenZipAESEncryptionSettings("password1")));

                    // Add second entry with a different password
                    archive.CreateEntry(
                        "file2.txt",
                        fi2,
                        false,
                        new SevenZipEntrySettings(
                            new SevenZipStoreCompressionSettings(),
                            new SevenZipAESEncryptionSettings("password2")));

                    // Add third entry with another password
                    archive.CreateEntry(
                        "file3.txt",
                        fi3,
                        false,
                        new SevenZipEntrySettings(
                            new SevenZipStoreCompressionSettings(),
                            new SevenZipAESEncryptionSettings("password3")));

                    // Save the archive to the file stream
                    archive.Save(sevenZipFile);
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
 * 1. When you need to protect confidential documents in a single 7z package but require separate passwords for each file.
 * 2. When distributing software components where each module must be accessed only by authorized users with distinct credentials.
 * 3. When creating an archive for a client that mandates individual file encryption for compliance with data‑privacy regulations.
 * 4. When automating backup scripts that store logs in a 7z archive and want to restrict access to each log file separately.
 * 5. When building a multi‑tenant SaaS solution that packages tenant data into one archive while keeping each tenant’s files isolated with unique passwords.
 */
