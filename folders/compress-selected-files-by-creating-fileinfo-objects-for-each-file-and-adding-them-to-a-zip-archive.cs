// HOW-TO: Compress Specific Files into a ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Define input files and output zip path
            string dataDir = @"C:\Data\";
            string inputPath1 = Path.Combine(dataDir, "file1.txt");
            string inputPath2 = Path.Combine(dataDir, "file2.txt");
            string outputPath = @"C:\Output\archive.zip";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create FileInfo objects for each input file
            FileInfo fi1 = new FileInfo(inputPath1);
            FileInfo fi2 = new FileInfo(inputPath2);

            // Create the ZIP archive and add entries
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("file1.txt", fi1);
                    archive.CreateEntry("file2.txt", fi2);
                    archive.Save(zipFile, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
                }
            }

            Console.WriteLine("Files compressed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a handful of log or configuration files into a single ZIP for easy transfer or backup, this code creates the archive directly from FileInfo objects.
 * 2. When an application must generate a downloadable package of user‑selected documents on the fly, the snippet shows how to add each chosen file to a ZIP with Aspose.Zip.
 * 3. When automating nightly builds you want to compress only the newly generated report files into a ZIP for archiving, the example demonstrates creating entries from existing files.
 * 4. When a desktop utility must create a compressed archive of selected images before uploading them to a server, this code illustrates the required steps in C#.
 * 5. When integrating a file‑export feature that saves multiple CSV exports into one compressed file for email attachment, the sample provides a straightforward way to build the ZIP.
 */
