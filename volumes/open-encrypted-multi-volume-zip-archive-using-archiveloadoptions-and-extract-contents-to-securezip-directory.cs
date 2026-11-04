// HOW-TO: Extract Encrypted Multi‑Volume ZIP Archive to Folder Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input directory containing the multi‑volume archive parts
            string dataDir = @"C:\Data\Multivolume";

            // Main segment (the .zip file)
            string mainSegment = Path.Combine(dataDir, "archive.zip");

            // Additional segments (e.g., .z01, .z02, etc.)
            string[] segmentFiles = Directory.GetFiles(dataDir, "archive.z*")
                .OrderBy(f => f)
                .Where(f => !f.EndsWith(".zip"))
                .ToArray();

            // Verify the main segment exists
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Verify each additional segment exists
            foreach (string seg in segmentFiles)
            {
                if (!File.Exists(seg))
                {
                    Console.Error.WriteLine($"File not found: {seg}");
                    return;
                }
            }

            // Output directory for extracted files
            string outputDir = Path.Combine(dataDir, "SecureZip");
            Directory.CreateDirectory(outputDir);

            // Load the encrypted multi‑volume ZIP archive with the password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "P@ssw0rd";

            using (Archive archive = new Archive(mainSegment, segmentFiles, loadOptions))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string outPath = Path.Combine(outputDir, entry.Name);
                    // Ensure the directory for the entry exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                    using (FileStream output = new FileStream(outPath, FileMode.Create))
                    {
                        entry.Extract(output);
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
 * 1. When you need to programmatically unpack a password‑protected split ZIP that was created for secure file transfer.
 * 2. When your C# application must read a large encrypted archive divided into .z01, .z02, etc., without manually merging the parts.
 * 3. When you want to automate extraction of confidential backup data stored in a multi‑volume ZIP to a protected directory.
 * 4. When integrating Aspose.Zip into a .NET service that processes encrypted archives received from external partners.
 * 5. When you have to validate and extract encrypted split archives as part of a deployment pipeline or CI/CD process.
 */
