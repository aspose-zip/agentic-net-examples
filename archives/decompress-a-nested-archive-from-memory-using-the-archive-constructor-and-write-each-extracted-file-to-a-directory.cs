// HOW-TO: Extract Files From In-Memory ZIP Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input archive path and output directory
        string inputPath = "input.zip";
        string outputDir = "ExtractedFiles";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Read the entire archive into memory
            byte[] archiveBytes = File.ReadAllBytes(inputPath);
            using (MemoryStream memoryStream = new MemoryStream(archiveBytes))
            {
                // Open the archive from the memory stream
                using (Archive archive = new Archive(memoryStream))
                {
                    // Iterate through each entry in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Skip directories; only extract files
                        if (entry.IsDirectory)
                        {
                            continue;
                        }

                        // Build the full output path for the extracted file
                        string outputFilePath = Path.Combine(outputDir, entry.Name);

                        // Ensure the directory for the file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                        // Extract the entry to the file system
                        using (Stream entryStream = entry.Open())
                        using (FileStream fileStream = File.Create(outputFilePath))
                        {
                            entryStream.CopyTo(fileStream);
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
 * 1. When a web service receives a ZIP file as a byte array and must unpack its contents directly to a server directory without creating a temporary file on disk.
 * 2. When processing email attachments that arrive as compressed archives in memory and you need to extract each file to a local folder for further analysis.
 * 3. When a desktop application loads a plugin package delivered as a nested ZIP stream and extracts the individual DLLs to a plugins folder at runtime.
 * 4. When a background job reads a backup archive stored in a database BLOB, decompresses it in memory, and writes the restored files to a specified output directory.
 * 5. When a CI/CD pipeline downloads a build artifact as a byte stream and needs to extract the compiled binaries to a workspace folder for deployment.
 */
