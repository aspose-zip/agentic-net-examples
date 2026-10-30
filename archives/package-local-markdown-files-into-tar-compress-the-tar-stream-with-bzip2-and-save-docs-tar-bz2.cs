// HOW-TO: Create a BZIP2 Compressed TAR of Markdown Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string sourceDir = @"C:\Data\Markdown";
            string outputPath = @"C:\Data\Output\docs.tar.bz2";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Verify source directory exists
            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            // Get all markdown files in the source directory
            string[] markdownFiles = Directory.GetFiles(sourceDir, "*.md");

            using (TarArchive archive = new TarArchive())
            {
                foreach (string filePath in markdownFiles)
                {
                    // Verify each file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Add file to TAR archive; entry name is the file name
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Compress the TAR archive with BZIP2 and save
                using (Bzip2Archive bz2 = new Bzip2Archive())
                {
                    bz2.SetSource(archive);
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
 * 1. When you need to bundle a set of documentation markdown files into a single archive for easy distribution, this code creates a TAR archive and compresses it with BZIP2.
 * 2. When deploying static site content to a server that only accepts .tar.bz2 packages, you can use this snippet to package and compress the markdown sources.
 * 3. When backing up project documentation to reduce disk usage while preserving the original file hierarchy, the code generates a BZIP2‑compressed TAR file.
 * 4. When sending markdown files over email or a low‑bandwidth network, compressing them into a .tar.bz2 archive minimizes transfer size.
 * 5. When integrating a build pipeline that requires archived source files in BZIP2 format for later extraction, this example automates the creation of the archive.
 */
