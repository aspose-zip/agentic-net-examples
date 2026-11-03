// HOW-TO: Compress Multiple Files into a ZIP with Parallel Processing in C# (Aspose.ZIP for .NET)
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
            string inputFile1 = "data/file1.txt";
            string inputFile2 = "data/file2.txt";
            string outputZip = "output/compressed.zip";

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

            Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

            using (FileStream zipFile = File.Open(outputZip, FileMode.Create))
            {
                using (FileStream source1 = File.Open(inputFile1, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream source2 = File.Open(inputFile2, FileMode.Open, FileAccess.Read))
                    {
                        using (Archive archive = new Archive())
                        {
                            archive.CreateEntry(Path.GetFileName(inputFile1), source1);
                            archive.CreateEntry(Path.GetFileName(inputFile2), source2);

                            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                            saveOptions.Encoding = Encoding.ASCII;
                            saveOptions.ArchiveComment = "Compressed with parallel processing";
                            saveOptions.ParallelOptions = new Aspose.Zip.Saving.ParallelOptions();

                            archive.Save(zipFile, saveOptions);
                        }
                    }
                }
            }

            using (Archive archive = new Archive(outputZip))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    Console.WriteLine($"Entry: {entry.Name}");
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
 * 1. When you need to quickly create a ZIP file from several large text files on a server, using parallel compression to reduce processing time.
 * 2. When you want to add an archive comment and ensure consistent ASCII encoding for compatibility with legacy systems.
 * 3. When you must generate a ZIP archive in a specific output folder and automatically create missing directories beforehand.
 * 4. When you need to verify the contents of a newly created ZIP by enumerating its entries without extracting them.
 * 5. When you are building a .NET application that processes multiple input streams concurrently and requires robust error handling for missing source files.
 */
