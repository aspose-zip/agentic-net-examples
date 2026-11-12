// HOW-TO: Extract a Specific File from a 7z Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths and entry name
            string inputPath = "sample.7z";
            string entryName = "document.txt";
            string outputPath = "extracted\\document.txt";

            // Verify input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                SevenZipArchiveEntry targetEntry = null;

                // Locate the desired entry
                foreach (SevenZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase))
                    {
                        targetEntry = entry;
                        break;
                    }
                }

                if (targetEntry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry to the output file
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    targetEntry.Extract(outStream);
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
 * 1. When you need to pull a single document out of a large 7z backup without extracting the entire archive, this code lets you retrieve it directly to a chosen folder.
 * 2. When an application must read a configuration file stored inside a compressed 7z package at runtime, you can locate and extract that entry on the fly.
 * 3. When deploying updates, you may want to extract only the changed DLL from a 7z release bundle to replace the existing version.
 * 4. When processing user‑uploaded 7z files, you can validate and extract a required manifest file to verify the package contents before further processing.
 * 5. When automating data migration, you can pull a specific CSV report from a multi‑file 7z archive and save it to a target directory for downstream analysis.
 */
