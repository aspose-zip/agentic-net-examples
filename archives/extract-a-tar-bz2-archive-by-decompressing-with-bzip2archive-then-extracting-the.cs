// HOW-TO: Extract a Tar.Bz2 Archive to Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tar.bz2";
            string outputPath = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputPath);

            // Temporary directory for decompressed .tar file
            string tempDir = Path.Combine(Path.GetTempPath(), "TarBz2ExtractTemp");
            Directory.CreateDirectory(tempDir);

            // Decompress the .bz2 archive to obtain the .tar file
            using (Bzip2Archive bzip2 = new Bzip2Archive(inputPath))
            {
                bzip2.ExtractToDirectory(tempDir);
            }

            // Locate the .tar file inside the temporary directory
            string[] tarFiles = Directory.GetFiles(tempDir, "*.tar", SearchOption.TopDirectoryOnly);
            if (tarFiles.Length == 0)
            {
                Console.Error.WriteLine("Tar file not found after decompression.");
                return;
            }
            string tarFilePath = tarFiles[0];

            // Extract the .tar archive to the final output directory
            using (TarArchive tar = new TarArchive(tarFilePath))
            {
                tar.ExtractToDirectory(outputPath);
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
 * 1. When you receive a .tar.bz2 backup from a Linux server and need to unpack it in a .NET application.
 * 2. When you want to programmatically decompress a Bzip2‑compressed tar file before processing its contents in C#.
 * 3. When automating deployment scripts that must extract source code packaged as tar.bz2 archives on Windows.
 * 4. When building a file‑import tool that reads compressed tar archives and stores the extracted files in a specific directory.
 * 5. When integrating third‑party data delivered in tar.bz2 format into an ASP.NET service for further analysis.
 */
