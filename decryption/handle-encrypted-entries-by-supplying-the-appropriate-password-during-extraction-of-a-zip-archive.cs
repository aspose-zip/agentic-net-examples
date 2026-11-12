// HOW-TO: Extract Encrypted ZIP Entries with Individual Passwords Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\encrypted.zip";
            string outputDir = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine the password for the current entry
                    string entryPassword = GetPasswordForEntry(entry.Name);

                    // Open the entry stream with the appropriate password
                    using (Stream entryStream = entry.Open(entryPassword))
                    {
                        string destinationPath = Path.Combine(outputDir, entry.Name);
                        // Ensure the destination directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        using (FileStream fileStream = File.Create(destinationPath))
                        {
                            entryStream.CopyTo(fileStream);
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple mapping of entry names to passwords (replace with real logic as needed)
    private static string GetPasswordForEntry(string entryName)
    {
        if (entryName.Equals("secret1.txt", StringComparison.OrdinalIgnoreCase))
            return "Password1";
        if (entryName.Equals("secret2.txt", StringComparison.OrdinalIgnoreCase))
            return "Password2";
        // Default password if not specified
        return string.Empty;
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to programmatically unzip a archive where each file is protected by a different password, such as a secure document bundle sent by a client.
 * 2. When an application must automatically extract confidential reports from a password‑protected ZIP while mapping each file name to its specific decryption key.
 * 3. When integrating Aspose.Zip in a C# service that processes encrypted backups, requiring per‑entry passwords to restore individual files.
 * 4. When building a file‑import tool that reads encrypted ZIP entries from a shared drive and saves them to a local folder without manual password entry.
 * 5. When creating a batch extraction utility that validates the existence of a ZIP, creates the destination structure, and extracts each protected entry using custom password logic.
 */
