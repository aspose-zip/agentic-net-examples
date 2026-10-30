// HOW-TO: Create ZIP of Localization Resource Files and Extract to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string resourcesDir = "Resources";
            string zipPath = "output/localization.zip";
            string extractDir = "output/localization";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));
            Directory.CreateDirectory(extractDir);

            // List of resource files to include
            List<string> resourceFiles = new List<string>
            {
                "en.resx",
                "fr.resx",
                "es.resx"
            };

            // Verify each input file exists
            foreach (string fileName in resourceFiles)
            {
                string filePath = Path.Combine(resourcesDir, fileName);
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Create ZIP archive and add files
            List<FileStream> sourceStreams = new List<FileStream>();
            using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                foreach (string fileName in resourceFiles)
                {
                    string filePath = Path.Combine(resourcesDir, fileName);
                    FileStream source = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    archive.CreateEntry(fileName, source);
                    sourceStreams.Add(source);
                }

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                {
                    Encoding = Encoding.ASCII,
                    ArchiveComment = "Localization resources"
                };
                archive.Save(zipStream, saveOptions);
            }

            // Dispose source streams after archive is saved
            foreach (FileStream src in sourceStreams)
            {
                src.Dispose();
            }

            // Verify the created ZIP file exists before extraction
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Extract all entries to the localization directory
            using (Archive archive = new Archive(zipPath))
            {
                archive.ExtractToDirectory(extractDir);
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
 * 1. When you need to package multiple .resx language files into a single ZIP archive for easy distribution to translators.
 * 2. When you want to automate deployment by creating a ZIP of resource files and extracting them to a specific localization directory at runtime.
 * 3. When building a CI/CD pipeline that bundles localization resources into a compressed archive and then unpacks them on the target server for application use.
 * 4. When you must verify that all required language resource files exist before creating the archive to prevent missing‑file errors during extraction.
 * 5. When you require a programmatic way to generate a ZIP with an ASCII comment and then extract its contents to a predefined output folder for localized content.
 */
