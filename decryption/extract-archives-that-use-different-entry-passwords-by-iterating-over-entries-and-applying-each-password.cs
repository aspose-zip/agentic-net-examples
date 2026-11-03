// HOW-TO: Extract Zip Archive Entries with Individual Passwords in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\archive.zip";
            string outputDirectory = "C:\\Data\\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            // Map entry names to their respective passwords
            Dictionary<string, string> entryPasswords = new Dictionary<string, string>()
            {
                { "secret1.txt", "PasswordOne" },
                { "confidential/report.pdf", "PasswordTwo" },
                { "images/photo.jpg", "PasswordThree" }
            };

            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string entryName = entry.Name;

                    if (entryPasswords.TryGetValue(entryName, out string password))
                    {
                        // Extract the entry using its specific password
                        entry.Extract(outputDirectory, password);
                    }
                    else
                    {
                        // Extract entries without a password
                        entry.Extract(outputDirectory);
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
 * 1. When you receive a zip file where each file is protected with a different password and you need to programmatically extract them in a .NET application.
 * 2. When a document management system stores confidential files in a single archive but assigns separate passwords per file for compliance, and you must automate the extraction process.
 * 3. When a backup solution creates a zip archive with per‑entry encryption and you need to restore specific files using their individual passwords in C#.
 * 4. When an enterprise workflow requires extracting only certain protected files from a zip while leaving others untouched, using a password map to control access.
 * 5. When you are building a migration tool that reads a password‑protected zip and extracts its contents to a new directory, handling each entry’s unique password automatically.
 */
