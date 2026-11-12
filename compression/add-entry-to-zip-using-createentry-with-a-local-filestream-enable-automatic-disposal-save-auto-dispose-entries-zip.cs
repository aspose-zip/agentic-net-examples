// HOW-TO: Add File to Existing ZIP Archive with Automatic Disposal in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "Data/";
            string sourceArchivePath = dataDir + "existing.zip";
            string fileToAddPath = dataDir + "newfile.txt";
            string resultPath = dataDir + "auto_dispose_entries.zip";

            if (!File.Exists(sourceArchivePath))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath}");
                return;
            }

            if (!File.Exists(fileToAddPath))
            {
                Console.Error.WriteLine($"File not found: {fileToAddPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(resultPath));

            using (Archive archive = new Archive(sourceArchivePath))
            {
                archive.CreateEntry("newfile.txt", fileToAddPath);
                archive.Save(resultPath);
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
 * 1. When you need to programmatically add a new text file to an existing ZIP package without loading the whole archive into memory, using Aspose.Zip’s CreateEntry method in C#.
 * 2. When you want to update a distribution ZIP with a configuration file while ensuring all file handles are released automatically via a using block.
 * 3. When building a backup utility that appends log files to a pre‑existing archive and saves the result as a new ZIP file.
 * 4. When integrating dynamic content generation where each generated report must be inserted into a master ZIP archive on the fly.
 * 5. When creating a deployment script that modifies an existing installer ZIP by adding a manifest file and relies on automatic disposal to avoid file‑lock issues.
 */
