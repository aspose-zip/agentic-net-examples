// HOW-TO: Create In‑Memory TAR.GZ Archive With Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path for the TAR.GZ file
            string outputPath = "output.tar.gz";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new TAR archive in memory
            using (TarArchive tar = new TarArchive())
            {
                // In‑memory file content
                byte[] fileData = Encoding.UTF8.GetBytes("Hello, this is in‑memory file content.");

                // Add the in‑memory file to the TAR archive
                using (MemoryStream ms = new MemoryStream(fileData))
                {
                    // The entry will be stored as "folder/inmemory.txt" inside the archive
                    tar.CreateEntry("folder/inmemory.txt", ms);
                }

                // Save the TAR archive as a gzipped file
                tar.SaveGzipped(outputPath);
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
 * 1. When you need to package dynamically generated text files into a compressed TAR.GZ without writing temporary files to disk.
 * 2. When a web service must return a gzipped TAR payload containing configuration data created on the fly.
 * 3. When automating backup of in‑memory logs or reports into a single TAR.GZ archive for efficient storage or transfer.
 * 4. When integrating with Linux‑based deployment pipelines that expect a TAR.GZ bundle created directly from C# code.
 * 5. When building a cross‑platform installer that bundles resources into a compressed TAR archive without using the file system.
 */
