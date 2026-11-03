// HOW-TO: Open Encrypted ZIP With Password And Create Unencrypted ZIP In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input, output, and password
        string inputPath = "input.zip";
        string outputPath = "output.zip";
        string password = "password123";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Open the encrypted ZIP archive with the supplied password
            using (Archive encryptedArchive = new Archive(inputPath, new ArchiveLoadOptions { DecryptionPassword = password }))
            {
                // Store entry names and their data in memory
                List<Tuple<string, MemoryStream>> entriesInMemory = new List<Tuple<string, MemoryStream>>();

                foreach (ArchiveEntry entry in encryptedArchive.Entries)
                {
                    MemoryStream memory = new MemoryStream();
                    using (Stream entryStream = entry.Open())
                    {
                        entryStream.CopyTo(memory);
                    }
                    memory.Position = 0; // Reset for later reading
                    entriesInMemory.Add(Tuple.Create(entry.Name, memory));
                }

                // Create a new unencrypted ZIP archive and add the in‑memory entries
                using (Archive newArchive = new Archive())
                {
                    foreach (Tuple<string, MemoryStream> item in entriesInMemory)
                    {
                        // Add entry from memory stream; no encryption settings are applied
                        newArchive.CreateEntry(item.Item1, item.Item2);
                    }

                    // Save the new archive to the output path
                    newArchive.Save(outputPath);
                }

                // Dispose the memory streams after the new archive has been saved
                foreach (Tuple<string, MemoryStream> item in entriesInMemory)
                {
                    item.Item2.Dispose();
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
 * 1. When you need to read a password‑protected ZIP file supplied by a user, extract its contents in memory, and then re‑package them without encryption for further processing.
 * 2. When migrating legacy encrypted archives to a new system that requires unencrypted ZIP files while keeping the original file names and data intact.
 * 3. When building a web service that receives encrypted ZIP uploads, validates the password, and returns a clean ZIP for downstream services.
 * 4. When automating a backup routine that decrypts secured ZIP backups, loads files into memory for transformation, and stores them as a plain ZIP for archiving.
 * 5. When creating a utility that removes password protection from ZIP archives to allow users without the password to access the files.
 */
