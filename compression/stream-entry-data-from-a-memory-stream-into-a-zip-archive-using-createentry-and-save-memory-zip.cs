// HOW-TO: Add In-Memory Text File to ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Define the output ZIP file path
            string outputPath = "memory.zip";

            // Ensure the output directory exists (guard against null or empty directory name)
            string outputDirectory = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            // Create a memory stream containing the data to be added to the archive
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] data = Encoding.UTF8.GetBytes("Hello from memory stream");
                memoryStream.Write(data, 0, data.Length);
                memoryStream.Position = 0; // Reset position for reading

                // Create a new ZIP archive and add the memory stream as an entry
                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("memory.txt", memoryStream);
                    archive.Save(outputPath);
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
 * 1. When you need to compress dynamically generated text data without writing a temporary file to disk, you can stream the memory content directly into a ZIP entry.
 * 2. When an application creates log or report strings in memory and must package them for email attachment, this code creates a ZIP file on the fly.
 * 3. When a web service receives data streams from clients and must store them as compressed files for archival, you can use CreateEntry with a MemoryStream.
 * 4. When building a backup utility that gathers configuration files held in memory and wants to save them as a single ZIP archive, this approach avoids extra I/O overhead.
 * 5. When generating downloadable content such as CSV or JSON directly in memory and offering it as a compressed download, the code streams the data into a ZIP file for the end user.
 */
