// HOW-TO: Create Self‑Extracting EXE from CAB Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string cabPath = @"C:\Data\sample.cab";

            // Verify the CAB file exists
            if (!File.Exists(cabPath))
            {
                Console.Error.WriteLine($"File not found: {cabPath}");
                return;
            }

            // Directory where CAB contents will be extracted
            string extractDir = @"C:\Temp\CabExtract";

            // Ensure the extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract all files from the CAB archive
            using (CabArchive cabArchive = new CabArchive(cabPath))
            {
                cabArchive.ExtractToDirectory(extractDir);
            }

            // Path for the self‑extracting executable output
            string sfxOutputPath = @"C:\Output\CabSfx.exe";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sfxOutputPath));

            // Create a new ZIP archive and add extracted files
            using (Archive zipArchive = new Archive())
            {
                string[] files = Directory.GetFiles(extractDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute the relative path inside the archive
                    string entryName = filePath.Substring(extractDir.Length).TrimStart(Path.DirectorySeparatorChar);
                    zipArchive.CreateEntry(entryName, filePath);
                }

                // Configure self‑extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the archive as a self‑extracting executable
                zipArchive.Save(sfxOutputPath, saveOptions);
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
 * 1. When you need to distribute software components packaged in a CAB file as a single executable that extracts itself on the target machine.
 * 2. When you want to automate the conversion of legacy CAB installers into modern self‑extracting archives for easier deployment.
 * 3. When a build pipeline must extract files from a CAB archive and repackage them into a portable SFX executable for end‑users.
 * 4. When you need to create a self‑extracting installer that includes files from multiple directories extracted from a CAB source.
 * 5. When you want to programmatically generate a self‑extracting EXE to simplify file delivery without requiring external extraction tools.
 */
