// HOW-TO: Add Files From Nested ZIP Into Main Archive Under Extracted Folder In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputMainPath = "input/main.zip";
            if (!File.Exists(inputMainPath))
            {
                Console.Error.WriteLine($"File not found: {inputMainPath}");
                return;
            }

            string outputMainPath = "output/main_modified.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputMainPath));

            // Temporary directories for extraction
            string tempRoot = "temp";
            Directory.CreateDirectory(tempRoot);
            string nestedExtractDir = Path.Combine(tempRoot, "extracted");
            Directory.CreateDirectory(nestedExtractDir);

            // Open the main ZIP archive
            using (Archive mainArchive = new Archive(inputMainPath))
            {
                // Locate the nested archive entry (assumed name "nested.zip")
                ArchiveEntry nestedEntry = mainArchive.Entries.FirstOrDefault(e => e.Name.Equals("nested.zip", StringComparison.OrdinalIgnoreCase));
                if (nestedEntry == null)
                {
                    Console.Error.WriteLine("Nested archive entry not found.");
                    return;
                }

                // Extract the nested archive to a temporary file
                string nestedTempPath = Path.Combine(tempRoot, "nested.zip");
                using (FileStream nestedStream = new FileStream(nestedTempPath, FileMode.Create, FileAccess.Write))
                {
                    nestedEntry.Extract(nestedStream);
                }

                // Open the extracted nested archive
                using (Archive nestedArchive = new Archive(nestedTempPath))
                {
                    // Extract all entries of the nested archive to a temporary folder
                    nestedArchive.ExtractToDirectory(nestedExtractDir);
                }

                // Add extracted files back into the main archive under "Extracted" folder
                string[] files = Directory.GetFiles(nestedExtractDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    string relativePath = Path.GetRelativePath(nestedExtractDir, filePath);
                    string entryPath = Path.Combine("Extracted", relativePath).Replace('\\', '/');
                    mainArchive.CreateEntry(entryPath, filePath);
                }

                // Save the modified main archive
                mainArchive.Save(outputMainPath);
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
 * 1. When you need to unpack a ZIP file that contains another ZIP and then store the inner files in a specific folder inside the original archive for organized distribution.
 * 2. When a deployment package includes a nested archive and you must merge its contents back into the main package without losing the original structure.
 * 3. When automating backup processes that compress logs into a nested ZIP and later want to re‑integrate those logs into the primary archive under a dedicated "Extracted" directory.
 * 4. When building a document management system that receives compound ZIP uploads and must flatten the hierarchy by extracting inner files into a known folder within the same archive.
 * 5. When creating a self‑extracting installer that extracts resources from an embedded ZIP and then repackages them into the installer’s main archive for later updates.
 */
