// HOW-TO: Create Self‑Extracting EXE From Full CAB Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Cab;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CAB file path
            string cabPath = "sample.cab";

            // Verify input file exists
            if (!File.Exists(cabPath))
            {
                Console.Error.WriteLine($"File not found: {cabPath}");
                return;
            }

            // Directory to extract CAB contents
            string extractDir = "ExtractedCab";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract all entries from the CAB archive
            using (CabArchive cabArchive = new CabArchive(cabPath))
            {
                cabArchive.ExtractToDirectory(extractDir);
            }

            // Path for the self‑extracting executable
            string sfxPath = "CabFullSfx.exe";

            // Ensure output directory exists (handles possible relative paths)
            string sfxDir = Path.GetDirectoryName(sfxPath);
            if (!string.IsNullOrEmpty(sfxDir))
            {
                Directory.CreateDirectory(sfxDir);
            }

            // Create a new ZIP archive and add extracted files
            using (Archive zipArchive = new Archive())
            {
                string[] files = Directory.GetFiles(extractDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute entry name relative to the extraction root
                    string entryName = Path.GetRelativePath(extractDir, filePath).Replace('\\', '/');

                    // Add file to the archive
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        zipArchive.CreateEntry(entryName, fileStream);
                    }
                }

                // Configure self‑extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save as a self‑extracting executable
                zipArchive.Save(sfxPath, saveOptions);
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
 * 1. When you need to distribute a Windows driver package originally in a CAB file as a single executable that users can run to unpack the files.
 * 2. When you want to automate the conversion of legacy CAB installers into modern self‑extracting ZIP executables for easier deployment.
 * 3. When a build pipeline must extract all files from a CAB archive and bundle them into a portable SFX for offline installation.
 * 4. When you need to create a single executable that contains the full contents of a CAB archive for inclusion in a software installer without requiring external extraction tools.
 * 5. When you are migrating legacy installation assets and require a C# solution to generate a self‑extracting archive that can be executed on any Windows machine.
 */
