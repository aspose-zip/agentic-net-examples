// HOW-TO: Create ZIP Archive From Markdown Files And Extract With Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input markdown files
            string inputFile1 = "file1.md";
            string inputFile2 = "file2.md";

            // Output ZIP archive path
            string zipPath = "archive.zip";

            // Extraction directory
            string extractDir = "docs";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory for ZIP exists (if any)
            string zipDir = Path.GetDirectoryName(zipPath);
            if (!string.IsNullOrEmpty(zipDir))
            {
                Directory.CreateDirectory(zipDir);
            }

            // Create ZIP archive with markdown files
            using (FileStream zipFile = File.Open(zipPath, FileMode.Create))
            {
                using (FileStream source1 = File.Open(inputFile1, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream source2 = File.Open(inputFile2, FileMode.Open, FileAccess.Read))
                    {
                        using (var archive = new Archive())
                        {
                            archive.CreateEntry("file1.md", source1);
                            archive.CreateEntry("file2.md", source2);
                            archive.Save(zipFile, new ArchiveSaveOptions()
                            {
                                Encoding = Encoding.ASCII,
                                ArchiveComment = "Markdown files archive"
                            });
                        }
                    }
                }
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract the archive to the docs folder
            using (FileStream zipFileRead = File.Open(zipPath, FileMode.Open))
            {
                using (var archive = new Archive(zipFileRead))
                {
                    archive.ExtractToDirectory(extractDir);
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
 * 1. When you need to bundle multiple markdown documentation files into a single ZIP for easy distribution or backup.
 * 2. When you want to programmatically generate a compressed archive of source notes and then unpack them into a documentation folder on a server.
 * 3. When an automated build process must package markdown files and later extract them to a target directory for publishing.
 * 4. When you are creating a portable documentation package that can be sent to clients and later expanded into a local docs folder.
 * 5. When you need to validate the existence of markdown files, compress them with a custom comment, and extract them using Aspose.Zip in a .NET application.
 */
