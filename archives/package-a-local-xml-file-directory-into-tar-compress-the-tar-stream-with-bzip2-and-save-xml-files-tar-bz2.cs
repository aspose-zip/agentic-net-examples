// HOW-TO: Create Bzip2 Compressed TAR Archive of XML Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing XML files
            string inputDir = @"C:\Data\XmlFiles";
            // Hardcoded output path for the compressed TAR archive
            string outputPath = @"C:\Data\xml_files.tar.bz2";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a TAR archive and add XML files
            using (TarArchive tar = new TarArchive())
            {
                string[] xmlFiles = Directory.GetFiles(inputDir, "*.xml", SearchOption.TopDirectoryOnly);
                foreach (string filePath in xmlFiles)
                {
                    string entryName = Path.GetFileName(filePath);
                    tar.CreateEntry(entryName, filePath);
                }

                // Compress the TAR archive with BZIP2
                using (Bzip2Archive bz2 = new Bzip2Archive())
                {
                    bz2.SetSource(tar);
                    bz2.Save(outputPath);
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
 * 1. When you need to bundle a set of XML configuration files into a single portable archive for transfer to a Linux system that expects tar.bz2 format.
 * 2. When you want to reduce the size of a directory of XML logs before uploading them to cloud storage while preserving the original file names.
 * 3. When an automated build pipeline must package generated XML reports into a BZIP2‑compressed TAR file for archival and later extraction.
 * 4. When a backup script has to create a compact, Unix‑compatible archive of XML data to meet storage quota constraints.
 * 5. When integrating with third‑party tools that only accept .tar.bz2 archives, you can programmatically create the required archive from a local XML folder.
 */
