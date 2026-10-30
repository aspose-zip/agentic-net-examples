// HOW-TO: Add Memory Stream Entry to CAB Archive with Default Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Output CAB file path
            string outputPath = "output.cab";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Sample data to be added to the CAB archive
            byte[] data = Encoding.UTF8.GetBytes("Sample data for CAB entry");

            // Create a memory stream from the sample data
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                // Initialize a new CAB archive
                using (CabArchive cabArchive = new CabArchive())
                {
                    // Define entry settings with default MS-ZIP compression
                    CabEntrySettings entrySettings = new CabEntrySettings(new CabMsZipCompressionSettings());

                    // Add an entry to the CAB archive from the memory stream
                    cabArchive.CreateEntry("sample.txt", memoryStream, entrySettings);

                    // Save the CAB archive to the specified file
                    using (FileStream fileStream = File.Open(outputPath, FileMode.Create))
                    {
                        cabArchive.Save(fileStream);
                    }
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
 * 1. When you need to package dynamically generated text or binary data into a CAB file without writing temporary files to disk.
 * 2. When you want to embed configuration files into an installer and control the compression level using Aspose.Zip's default MS‑ZIP settings.
 * 3. When a deployment tool must create a CAB archive from in‑memory streams for fast, memory‑efficient packaging of resources.
 * 4. When you are building a backup utility that compresses log data on the fly into a CAB file before saving it to storage.
 * 5. When you need to programmatically add files to a CAB archive in a .NET application while ensuring consistent compression across all entries.
 */
