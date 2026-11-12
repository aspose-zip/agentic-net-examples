// HOW-TO: Brute Force Zip Password with Template and Extract Specific File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        string zipPath = @"C:\Temp\protected.zip";
        string outputDirectory = @"C:\Temp\Extracted";
        string targetEntryName = "info.txt";

        try
        {
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            bool passwordFound = false;
            string foundPassword = null;

            for (int d1 = 0; d1 <= 9; d1++)
            {
                for (int d2 = 0; d2 <= 9; d2++)
                {
                    string password = $"Secret{d1}{d2}";

                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                    loadOptions.DecryptionPassword = password;

                    try
                    {
                        using (Archive archive = new Archive(zipPath, loadOptions))
                        {
                            ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(targetEntryName, StringComparison.OrdinalIgnoreCase));
                            if (entry != null)
                            {
                                string destinationPath = Path.Combine(outputDirectory, entry.Name);
                                entry.Extract(destinationPath);
                                Console.WriteLine($"Extracted entry to {destinationPath}");
                                passwordFound = true;
                                foundPassword = password;
                                break;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        // Wrong password or load error; continue guessing
                    }

                    if (passwordFound)
                        break;
                }
                if (passwordFound)
                    break;
            }

            if (!passwordFound)
            {
                Console.Error.WriteLine("Password could not be guessed.");
            }
            else
            {
                Console.WriteLine($"Password found: {foundPassword}");
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
 * 1. When you receive a password‑protected ZIP from a partner and only know part of the password pattern, you can programmatically try the missing digits and extract the needed document without manual trial‑and‑error.
 * 2. When automating a data‑ingestion pipeline that must pull a specific log file from encrypted archives, this code lets you brute‑force the known password format and retrieve the file directly.
 * 3. When performing forensic analysis on a seized ZIP where the password follows a known naming convention, you can use the template‑based guessing to unlock the archive and extract the evidence file.
 * 4. When building a backup restoration tool that needs to recover a particular configuration file from a secured ZIP, the routine can iterate possible passwords and extract only that entry.
 * 5. When creating a scheduled task that monitors a folder for newly dropped encrypted ZIPs and must extract a summary report without exposing the full archive contents, this approach guesses the password and saves just the required file.
 */
