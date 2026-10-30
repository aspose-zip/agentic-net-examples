// HOW-TO: Add a File to an Existing Zip Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define base data directory
            string dataDir = "C:\\Data\\";
            // Path to the existing ZIP archive
            string sourceArchivePath = dataDir + "sample.zip";
            // Path to the file that will be added to the archive
            string fileToAppend = dataDir + "newfile.txt";

            // Verify that the source archive exists
            if (!File.Exists(sourceArchivePath))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath}");
                return;
            }

            // Verify that the file to append exists
            if (!File.Exists(fileToAppend))
            {
                Console.Error.WriteLine($"File not found: {fileToAppend}");
                return;
            }

            // Open the existing archive
            using (Archive archive = new Archive(sourceArchivePath))
            {
                // Add the new file as an entry with the same name as the source file
                archive.CreateEntry(Path.GetFileName(fileToAppend), fileToAppend);

                // Define the output path for the updated archive
                string resultPath = dataDir + "updated.zip";

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

                // Save the updated archive
                archive.Save(resultPath);
            }

            Console.WriteLine("File appended and archive saved successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically include a new report file into a previously created zip package before sending it to a client.
 * 2. When an automated build process must append log files to an existing deployment archive without recreating the whole zip.
 * 3. When a desktop application updates a user’s backup zip by adding newly generated configuration files.
 * 4. When a server‑side service adds a generated invoice PDF to an existing zip of monthly statements for storage.
 * 5. When a data migration script incorporates additional CSV data into an existing compressed archive for archival compliance.
 */
