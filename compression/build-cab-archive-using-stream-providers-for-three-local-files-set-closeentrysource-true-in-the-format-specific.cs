// HOW-TO: Create CAB Archive from Multiple Files Using Stream Providers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string file1Path = "file1.txt";
            string file2Path = "file2.txt";
            string file3Path = "file3.txt";

            // Hardcoded output CAB path
            string outputPath = "local_files.cab";

            // Validate input files
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }
            if (!File.Exists(file3Path))
            {
                Console.Error.WriteLine($"File not found: {file3Path}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Default entry settings (compressed)
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());

            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add first file using a stream provider
                using (FileStream fs1 = new FileStream(file1Path, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("file1.txt", fs1);
                }

                // Add second file using a stream provider
                using (FileStream fs2 = new FileStream(file2Path, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("file2.txt", fs2);
                }

                // Add third file using a stream provider with stored (no compression) settings
                CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());
                using (FileStream fs3 = new FileStream(file3Path, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("file3.txt", fs3, storedSettings);
                }

                // Save the CAB archive with CloseEntrySource set to true
                CabSaveOptions saveOptions = new CabSaveOptions();
                saveOptions.CloseEntrySource = true;
                archive.Save(outputPath, saveOptions);
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
 * 1. When you need to package several configuration or log files into a single CAB file for distribution in a Windows installer.
 * 2. When you want to compress and store local resources on the fly without loading entire files into memory, using stream providers.
 * 3. When you must generate a CAB archive programmatically in a .NET service that creates backup bundles for legacy systems.
 * 4. When you need to ensure each entry is closed after writing to avoid file locks, by using format‑specific save options like CloseEntrySource.
 * 5. When you are building an automated build pipeline that bundles compiled assets into a CAB file for deployment to embedded devices.
 */
