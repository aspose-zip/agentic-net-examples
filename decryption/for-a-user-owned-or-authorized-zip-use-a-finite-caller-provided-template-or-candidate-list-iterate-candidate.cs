// HOW-TO: Brute Force Candidate Passwords to Extract Encrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path
            string inputZipPath = "encrypted.zip";

            // Verify input file exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Hardcoded output directory
            string outputDirectory = "extracted";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Candidate passwords to try
            string[] candidatePasswords = new string[]
            {
                "password1",
                "password2",
                "123456",
                "secret"
            };

            // Open the ZIP archive (no archive-level password)
            using (Archive archive = new Archive(inputZipPath))
            {
                bool extractionSucceeded = false;

                foreach (string password in candidatePasswords)
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        try
                        {
                            // Attempt to open the entry with the current password
                            using (Stream entryStream = entry.Open(password))
                            {
                                // Prepare full path for the extracted entry
                                string extractedFilePath = Path.Combine(outputDirectory, entry.Name);

                                // Ensure the directory for the entry exists
                                Directory.CreateDirectory(Path.GetDirectoryName(extractedFilePath));

                                // Write the entry contents to the file system
                                using (FileStream fileStream = new FileStream(extractedFilePath, FileMode.Create, FileAccess.Write))
                                {
                                    entryStream.CopyTo(fileStream);
                                }

                                // Record the successful password (non‑secret outcome)
                                string passwordInfoPath = Path.Combine(outputDirectory, "password_used.txt");
                                File.WriteAllText(passwordInfoPath, password);

                                Console.WriteLine($"Successfully extracted '{entry.Name}' using password '{password}'.");
                                extractionSucceeded = true;
                                break;
                            }
                        }
                        catch (Exception)
                        {
                            // Incorrect password or other extraction issue; try next password
                            continue;
                        }
                    }

                    if (extractionSucceeded)
                    {
                        break;
                    }
                }

                if (!extractionSucceeded)
                {
                    Console.Error.WriteLine("Failed to decrypt any entry with the provided passwords.");
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
 * 1. When a user receives a password‑protected ZIP and you have a known list of possible passwords, you can automatically try each one until the correct password decrypts an entry and the file is extracted.
 * 2. When integrating a document processing pipeline that must handle encrypted archives from multiple sources, this code lets you programmatically test a template of passwords and extract the contents without manual intervention.
 * 3. When performing forensic analysis on a suspect’s encrypted ZIP, you can supply candidate passwords to quickly locate the valid one and retrieve the files for further examination.
 * 4. When building a backup restoration tool that needs to recover data from encrypted ZIP backups with limited password hints, the looped password trial extracts the data to a designated folder.
 * 5. When creating a batch job that processes incoming encrypted ZIP uploads and you want to log only the extraction success status while keeping the extracted files confidential, this approach fulfills that requirement.
 */
