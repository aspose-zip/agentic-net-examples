// HOW-TO: Extract Encrypted ZIP Entries with Individual Passwords in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = @"C:\Data\encryptedArchive.zip";
            // Hardcoded output directory for extracted files
            string outputDir = @"C:\Data\Extracted";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    // Example: extract first entry with its password
                    if (archive.Entries.Count > 0)
                    {
                        // Password for the first entry
                        string passwordEntry0 = "PasswordOne";
                        archive.Entries[0].Extract(outputDir, passwordEntry0);
                    }

                    // Example: extract second entry with a different password
                    if (archive.Entries.Count > 1)
                    {
                        // Password for the second entry
                        string passwordEntry1 = "PasswordTwo";
                        archive.Entries[1].Extract(outputDir, passwordEntry1);
                    }

                    // Add additional entries extraction as needed, supplying the correct password for each.
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
 * 1. When a .NET application must unpack a ZIP archive where each file is protected by a different password, such as receiving confidential reports from multiple vendors.
 * 2. When automating the restoration of a secure backup that stores each component in an encrypted ZIP entry with its own password.
 * 3. When processing a batch of encrypted log files delivered in a single archive, requiring the correct password for each entry before analysis.
 * 4. When building a data‑migration tool that extracts sensitive documents from a password‑protected ZIP, using per‑file passwords stored in a configuration file.
 * 5. When creating a secure file‑sharing service that extracts user‑specific encrypted files from a ZIP archive on the server side.
 */
