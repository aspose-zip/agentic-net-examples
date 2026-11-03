// HOW-TO: Extract Zip Entries With Individual Passwords Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = @"C:\Data\protected.zip";
            // Hardcoded output directory path
            string outputPath = @"C:\Data\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                // Iterate through each entry in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine the password for the current entry
                    string entryPassword = GetPasswordForEntry(entry.Name);

                    // Extract the entry using its specific password
                    entry.Extract(outputPath, entryPassword);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple helper to map entry names to passwords
    private static string GetPasswordForEntry(string entryName)
    {
        // Example mapping – adjust as needed for real passwords
        if (entryName.EndsWith("secret1.txt", StringComparison.OrdinalIgnoreCase))
            return "PasswordOne";
        if (entryName.EndsWith("secret2.txt", StringComparison.OrdinalIgnoreCase))
            return "PasswordTwo";

        // Default password if none matches
        return string.Empty;
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack a ZIP archive where each file is protected by a different password, such as a secure document bundle distributed to multiple recipients.
 * 2. When automating the processing of encrypted archives in a C# application and must supply the correct password for each entry to extract its contents.
 * 3. When building a data migration tool that reads a protected ZIP file with per‑file encryption, ensuring only authorized data is extracted.
 * 4. When creating a backup restoration script that handles ZIP archives with individual file passwords, using Aspose.Zip to provide the appropriate password during extraction.
 * 5. When developing a compliance‑focused reporting system that extracts confidential files from a ZIP archive, each encrypted with a unique password, to audit their contents.
 */
