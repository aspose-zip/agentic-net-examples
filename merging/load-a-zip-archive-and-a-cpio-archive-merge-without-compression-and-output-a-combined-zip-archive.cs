// HOW-TO: Create Uncompressed ZIP Archive From Multiple Files In C# (Aspose.ZIP for .NET)
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
            string dataDir = "Data";
            string file1Path = Path.Combine(dataDir, "file1.txt");
            string file2Path = Path.Combine(dataDir, "file2.txt");
            string outputZipPath = Path.Combine("output", "archive.zip");

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            FileInfo fi1 = new FileInfo(file1Path);
            FileInfo fi2 = new FileInfo(file2Path);

            using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                archive.CreateEntry("file1.txt", fi1);
                archive.CreateEntry("file2.txt", fi2);

                using (FileStream outStream = File.Open(outputZipPath, FileMode.Create))
                {
                    archive.Save(outStream, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
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
 * 1. When you need to bundle log files into a ZIP without compressing them to preserve original file sizes for quick access.
 * 2. When generating a deployment package that must remain uncompressed for compatibility with legacy systems that only support stored entries.
 * 3. When creating an archive of source code files where compression is unnecessary because the files are already compressed, such as images or binaries.
 * 4. When preparing a data export that will be streamed directly to another service that expects a ZIP with stored (no‑compression) entries.
 * 5. When combining multiple text reports into a single ZIP archive for email attachment while keeping the files readable without decompression.
 */
