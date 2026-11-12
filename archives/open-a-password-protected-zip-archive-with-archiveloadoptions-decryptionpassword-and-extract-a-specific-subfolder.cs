// HOW-TO: Extract Specific Subfolder From Password Protected ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths and password
            string inputPath = @"C:\Data\protected.zip";
            string password = "myPassword";
            string subfolderInArchive = "Docs/"; // Folder inside the ZIP to extract
            string outputPath = @"C:\Output\ExtractedDocs";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputPath);

            // Set load options with the decryption password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = password;

            // Open the ZIP archive stream
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the archive with password protection
                using (Archive archive = new Archive(zipStream, loadOptions))
                {
                    // Iterate through entries and extract those belonging to the specified subfolder
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        if (entry.Name.StartsWith(subfolderInArchive, StringComparison.OrdinalIgnoreCase))
                        {
                            // Determine the relative path inside the target folder
                            string relativePath = entry.Name.Substring(subfolderInArchive.Length);
                            string destinationPath = Path.Combine(outputPath, relativePath);

                            if (entry.IsDirectory)
                            {
                                // Create directory for folder entries
                                Directory.CreateDirectory(destinationPath);
                            }
                            else
                            {
                                // Ensure the directory for the file exists
                                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                                // Extract the file entry
                                using (FileStream outStream = File.Create(destinationPath))
                                {
                                    using (Stream entryStream = entry.Open())
                                    {
                                        entryStream.CopyTo(outStream);
                                    }
                                }
                            }
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically retrieve only the “Docs” folder from an encrypted ZIP sent by a client.
 * 2. When automating deployment scripts that must unpack confidential configuration files stored in a password‑protected archive.
 * 3. When building a desktop application that lets users open secured backup archives and view a selected project folder.
 * 4. When integrating a data‑processing pipeline that extracts only a subset of files from an encrypted ZIP without exposing the whole archive.
 * 5. When creating a scheduled task that periodically extracts updated reports from a protected ZIP to a reporting directory.
 */
