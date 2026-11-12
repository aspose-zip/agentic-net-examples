// HOW-TO: Create ZIP Archive From Memory Streams In C# Without Parallel Options (Aspose.ZIP for .NET)
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
            // Output ZIP file path
            string outputPath = "output/memoryOnly.zip";

            // Create output directory
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare in‑memory data for entries
            byte[] data1 = Encoding.UTF8.GetBytes("Hello from memory stream 1");
            MemoryStream stream1 = new MemoryStream(data1);

            byte[] data2 = Encoding.UTF8.GetBytes("Hello from memory stream 2");
            MemoryStream stream2 = new MemoryStream(data2);

            // Create a new ZIP archive and add entries from memory streams
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", stream1);
                archive.CreateEntry("file2.txt", stream2);

                // Save the archive
                archive.Save(outputPath);
            }

            // Dispose memory streams after saving
            stream1.Dispose();
            stream2.Dispose();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a ZIP file on the fly from data held in memory, such as creating downloadable reports without writing temporary files to disk.
 * 2. When you want to bundle multiple in‑memory text files into a single archive for email attachment or API response.
 * 3. When you are building a web service that returns a ZIP of generated content and you prefer a straightforward synchronous approach without parallel processing overhead.
 * 4. When you must create a ZIP archive in a restricted environment where only synchronous operations are allowed, avoiding the complexity of ParallelOptions.
 * 5. When you want to programmatically create a ZIP file for unit testing without persisting intermediate files to the file system.
 */
