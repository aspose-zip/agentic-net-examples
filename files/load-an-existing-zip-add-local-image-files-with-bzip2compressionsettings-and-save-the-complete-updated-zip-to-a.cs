// HOW-TO: Add Images to Existing ZIP with Bzip2 Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "C:\\Data\\";
            string sourceZipPath = Path.Combine(dataDir, "existing.zip");
            string outputZipPath = Path.Combine(dataDir, "updated.zip");

            if (!File.Exists(sourceZipPath))
            {
                Console.Error.WriteLine($"File not found: {sourceZipPath}");
                return;
            }

            string[] imageFiles = new string[]
            {
                Path.Combine(dataDir, "image1.jpg"),
                Path.Combine(dataDir, "image2.png")
            };

            foreach (string imgPath in imageFiles)
            {
                if (!File.Exists(imgPath))
                {
                    Console.Error.WriteLine($"File not found: {imgPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (Archive archive = new Archive(sourceZipPath))
            {
                foreach (string imgPath in imageFiles)
                {
                    string entryName = Path.GetFileName(imgPath);
                    archive.CreateEntry(entryName, imgPath);
                }

                archive.Save(outputZipPath);
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
 * 1. When you need to update a previously created ZIP file by inserting new photo assets without recreating the archive from scratch.
 * 2. When an application must programmatically bundle user‑uploaded images into an existing backup archive while applying Bzip2 compression to reduce size.
 * 3. When a deployment script has to augment a distribution package with additional screenshots or icons before publishing.
 * 4. When a server‑side process must merge newly generated report images into a stored ZIP archive for later download.
 * 5. When a desktop utility wants to preserve the original ZIP contents and simply add extra image files, saving the result as a new file.
 */
