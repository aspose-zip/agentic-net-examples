// HOW-TO: Create a CAB Archive From a Folder Recursively in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded source folder and output CAB file paths
            string sourceFolder = @"C:\SourceFolder";
            string outputPath = @"C:\Output\archive.cab";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new CAB archive
            using (CabArchive cab = new CabArchive())
            {
                // Retrieve all files from the source folder recursively
                string[] files = Directory.GetFiles(sourceFolder, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Verify the file exists before processing
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Determine the entry name relative to the source folder
                    string entryName = Path.GetRelativePath(sourceFolder, filePath);

                    // Open the file stream for reading
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        // Use default MSZIP compression for the entry
                        CabEntrySettings entrySettings = new CabEntrySettings(new CabMsZipCompressionSettings());

                        // Add the file as an entry to the CAB archive
                        cab.CreateEntry(entryName, fileStream, entrySettings);
                    }
                }

                // Save the populated CAB archive to the specified output path
                cab.Save(outputPath);
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
 * 1. When you need to package an entire application directory into a single CAB file for Windows installer distribution.
 * 2. When you want to back up a project's source files into a compressed CAB archive while preserving the folder hierarchy recursively.
 * 3. When you must generate a CAB archive on the fly in a C# service to send bundled logs to a remote server.
 * 4. When you are automating the creation of driver packages that require all files to be stored in a CAB format.
 * 5. When you need to compress and archive configuration files from multiple subfolders into one CAB for easy deployment.
 */
