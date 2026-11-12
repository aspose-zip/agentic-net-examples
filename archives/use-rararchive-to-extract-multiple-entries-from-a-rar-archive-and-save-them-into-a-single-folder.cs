// HOW-TO: Extract Selected Files From RAR Archive To Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input RAR archive path
            string inputPath = "sample.rar";

            // Hardcoded output folder where entries will be extracted
            string outputFolder = "ExtractedFiles";

            // Verify that the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputFolder) ?? outputFolder);

            // Open the RAR archive
            using (RarArchive archive = new RarArchive(inputPath))
            {
                // Define the names of entries you want to extract
                string[] entriesToExtract = { "document.txt", "image.jpg", "data.csv" };

                foreach (RarArchiveEntry entry in archive.Entries)
                {
                    // Check if the current entry is one of the desired files
                    if (Array.IndexOf(entriesToExtract, entry.Name) >= 0)
                    {
                        // Build the full path for the extracted file
                        string destinationPath = Path.Combine(outputFolder, entry.Name);

                        // Ensure the directory for the destination file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        // Extract the entry to the specified file
                        entry.Extract(destinationPath);
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
 * 1. When you need to pull only certain documents, images, or data files from a large RAR backup and place them into a single directory in a C# application.
 * 2. When an automated deployment script must extract a predefined list of configuration files from a RAR package before starting a service.
 * 3. When a desktop utility processes user‑uploaded RAR archives and extracts only the required reports for further analysis.
 * 4. When a server‑side process validates the presence of specific files inside a RAR archive and extracts them to a working folder for processing.
 * 5. When a data‑migration tool reads a RAR archive and extracts selected CSV and image files into a target folder for import into a database.
 */
