// HOW-TO: Create a ZIP Archive with Multiple Text Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output ZIP archive path (hard‑coded)
            string outputPath = @"C:\Temp\MyArchive.zip";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a ZIP archive
            using (Archive archive = new Archive())
            {
                // First text file entry
                string text1 = "Hello, this is file 1.";
                byte[] data1 = Encoding.UTF8.GetBytes(text1);
                using (MemoryStream stream1 = new MemoryStream(data1))
                {
                    archive.CreateEntry("file1.txt", stream1);
                }

                // Second text file entry inside a folder
                string text2 = "Second file content.";
                byte[] data2 = Encoding.UTF8.GetBytes(text2);
                using (MemoryStream stream2 = new MemoryStream(data2))
                {
                    archive.CreateEntry("folder/file2.txt", stream2);
                }

                // Save the ZIP archive to disk
                archive.Save(outputPath);
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
 * 1. When you need to bundle several log files into a single ZIP for easy transfer or backup in a C# application.
 * 2. When generating a downloadable package of configuration files for a client, you can create the ZIP on the fly using Aspose.Zip.
 * 3. When exporting reports as plain‑text files and sending them as a compressed archive to reduce bandwidth.
 * 4. When automating the creation of a deployment package that includes documentation files organized in folders.
 * 5. When archiving user‑generated notes into a ZIP archive for storage or later extraction in a .NET service.
 */
