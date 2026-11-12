// HOW-TO: Extract Only Encrypted Files From a Mixed ZIP Archive In C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.zip";
            string outputPath = "extracted\\";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            var passwords = new Dictionary<string, string>
            {
                { "file1.txt", "password1" },
                { "file2.txt", "password2" }
            };
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (passwords.TryGetValue(entry.Name, out string pwd))
                    {
                        string destinationFile = Path.Combine(outputPath, entry.Name);
                        string destinationDir = Path.GetDirectoryName(destinationFile);
                        if (!string.IsNullOrEmpty(destinationDir))
                        {
                            Directory.CreateDirectory(destinationDir);
                        }
                        entry.Extract(destinationFile, pwd);
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
 * 1. When you need to pull confidential documents out of a ZIP that also contains public files, using a password map to decrypt only the protected entries.
 * 2. When an automated deployment script must extract sensitive configuration files from a packaged archive without exposing unencrypted assets.
 * 3. When a backup restoration tool has to recover only the encrypted user data from a mixed‑content zip while ignoring regular logs.
 * 4. When a security audit process extracts password‑protected reports from a zip bundle for further analysis in a .NET application.
 * 5. When a file‑sharing service selectively decrypts and extracts encrypted attachments from a zip uploaded by users, leaving other files untouched.
 */
