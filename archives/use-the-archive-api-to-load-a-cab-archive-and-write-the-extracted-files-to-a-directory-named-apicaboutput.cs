// HOW-TO: Extract Files from a CAB Archive to a Folder Using Aspose.Zip for C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.cab";
        string outputDirectory = "ApiCabOutput";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the CAB archive
            using (CabArchive archive = new CabArchive(inputPath))
            {
                // Iterate through each entry in the archive
                foreach (CabEntry entry in archive.Entries)
                {
                    // Build full path for the extracted file
                    string entryOutputPath = Path.Combine(outputDirectory, entry.Name);

                    // Ensure the directory for the entry exists
                    string entryDir = Path.GetDirectoryName(entryOutputPath);
                    if (!string.IsNullOrEmpty(entryDir))
                    {
                        Directory.CreateDirectory(entryDir);
                    }

                    // Extract the entry to the file system
                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = File.Create(entryOutputPath))
                    {
                        entryStream.CopyTo(fileStream);
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
 * 1. When you need to programmatically unpack driver or installer CAB files on a Windows system in a C# application.
 * 2. When you want to automate extracting all entries from a CAB archive into a specific output directory for further processing.
 * 3. When you are building a deployment tool that must read the contents of a CAB package and copy them to a target folder.
 * 4. When you need to verify a CAB archive exists and safely extract its files without overwriting existing directories.
 * 5. When you are integrating Aspose.Zip into a .NET service that processes archived resources and stores the extracted files in a structured output folder.
 */
