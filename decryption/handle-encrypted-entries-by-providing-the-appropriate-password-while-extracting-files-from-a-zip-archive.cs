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
            string inputPath = "input.zip";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.IsDirectory)
                        continue;

                    string entryPassword = GetPasswordForEntry(entry.Name);
                    string destinationPath = Path.Combine(outputDirectory, entry.Name);

                    // Ensure the destination directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                    // Extract the entry using its specific password
                    entry.Extract(destinationPath, entryPassword);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    // Simple helper to map entry names to passwords
    static string GetPasswordForEntry(string entryName)
    {
        // Example mapping; adjust as needed for real passwords
        if (entryName.Equals("secret1.txt", StringComparison.OrdinalIgnoreCase))
            return "PasswordOne";
        if (entryName.Equals("secret2.txt", StringComparison.OrdinalIgnoreCase))
            return "PasswordTwo";

        // Default password if none specific
        return "DefaultPassword";
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unzip a password‑protected archive where each file uses a different password.
 * 2. When processing a batch of confidential documents stored in a ZIP and you must supply the correct password for each entry during extraction.
 * 3. When automating deployment scripts that retrieve encrypted resources from a ZIP and require per‑file authentication.
 * 4. When building a data‑import tool that reads secured log files from a compressed archive and must handle varying passwords.
 * 5. When creating a backup restoration utility that extracts selectively encrypted files without prompting the user for passwords.
 */
