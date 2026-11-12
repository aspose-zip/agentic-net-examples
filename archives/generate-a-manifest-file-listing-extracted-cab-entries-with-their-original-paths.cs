// HOW-TO: Extract CAB Archive and Generate Manifest File with Entry Paths in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        string inputCabPath = "sample.cab";
        string extractDirectory = "Extracted";
        string manifestFilePath = "manifest.txt";

        try
        {
            if (!File.Exists(inputCabPath))
            {
                Console.Error.WriteLine($"File not found: {inputCabPath}");
                return;
            }

            Directory.CreateDirectory(extractDirectory);
            string manifestDir = Path.GetDirectoryName(manifestFilePath);
            Directory.CreateDirectory(string.IsNullOrEmpty(manifestDir) ? "." : manifestDir);

            using (CabArchive archive = new CabArchive(inputCabPath))
            {
                archive.ExtractToDirectory(extractDirectory);

                using (StreamWriter writer = new StreamWriter(manifestFilePath, false, Encoding.UTF8))
                {
                    foreach (CabEntry entry in archive.Entries)
                    {
                        writer.WriteLine(entry.Name);
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
 * 1. When you need to unpack a Windows CAB installer and keep a text list of all original file paths for auditing or deployment scripts.
 * 2. When a build pipeline must extract resources from a CAB package and produce a manifest to verify that all expected components were included.
 * 3. When you are migrating legacy CAB archives to a new system and require a simple UTF‑8 manifest to document the extracted file hierarchy.
 * 4. When an automated installer needs to extract bundled files and generate a manifest for later checksum validation or rollback.
 * 5. When a support tool must read a CAB file, extract its contents to a folder, and create a readable list of entry names for troubleshooting or documentation.
 */
