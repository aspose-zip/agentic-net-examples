// HOW-TO: Extract ZIP Files and Create a Gzipped TAR with In‑Memory File in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string zipPath = "input.zip";
            string extractDir = "extracted";
            string tarPath = "output.tar.gz";

            // Validate input ZIP file
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Ensure output directory for tar.gz exists
            Directory.CreateDirectory(Path.GetDirectoryName(tarPath));

            // Open ZIP archive and extract all entries
            using (Archive zipArchive = new Archive(zipPath))
            {
                zipArchive.ExtractToDirectory(extractDir);
            }

            // Create TAR archive and add extracted files
            using (TarArchive tarArchive = new TarArchive())
            {
                // Add files from the extracted directory
                string[] files = Directory.GetFiles(extractDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Preserve relative path inside the TAR
                    string relativePath = Path.GetRelativePath(extractDir, filePath).Replace('\\', '/');
                    tarArchive.CreateEntry(relativePath, filePath);
                }

                // Add an in‑memory file to the TAR archive
                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes("Hello from memory")))
                {
                    tarArchive.CreateEntry("memory.txt", memoryStream);
                }

                // Save the TAR archive compressed as GZIP (tar.gz)
                tarArchive.SaveGzipped(tarPath);
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
 * 1. When you need to convert a downloaded ZIP package into a tar.gz archive for deployment on Linux systems.
 * 2. When you must preserve the original directory structure while moving files from a ZIP to a TAR for backup purposes.
 * 3. When you want to embed dynamically generated content, such as a log or report, into a compressed TAR without writing a temporary file to disk.
 * 4. When automating a CI/CD pipeline that extracts artifacts from a ZIP and packages them as a gzipped TAR for distribution.
 * 5. When you need to combine extracted files and in‑memory data into a single .tar.gz archive to reduce storage and transfer size.
 */
