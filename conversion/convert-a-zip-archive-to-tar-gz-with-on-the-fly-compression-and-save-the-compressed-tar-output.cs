// HOW-TO: Convert ZIP Archive to Gzipped TAR File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP and output TAR.GZ paths
            string inputZipPath = "input.zip";
            string outputTarGzPath = "output.tar.gz";

            // Validate input file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

            // Create a temporary directory for extracting ZIP contents
            string tempExtractDir = Path.Combine(Path.GetTempPath(), "ZipToTarTemp_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempExtractDir);

            // Extract ZIP archive to temporary directory
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                zipArchive.ExtractToDirectory(tempExtractDir);
            }

            // Create TAR archive and add extracted files, then save as GZipped TAR
            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntries(new DirectoryInfo(tempExtractDir));
                tarArchive.SaveGzipped(outputTarGzPath);
            }

            // Clean up temporary extraction directory
            Directory.Delete(tempExtractDir, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate a Windows‑generated ZIP backup to a Linux‑compatible .tar.gz package for deployment pipelines.
 * 2. When an application must unpack a ZIP bundle, re‑package its contents, and stream them as a compressed TAR archive to reduce storage size.
 * 3. When you want to provide end‑users a single .tar.gz file that contains files originally distributed as a ZIP, ensuring compatibility with Unix tools.
 * 4. When automating data archiving, you extract incoming ZIP uploads, convert them to gzipped TAR archives, and store them in cloud storage.
 * 5. When integrating with third‑party systems that only accept .tar.gz files, you programmatically transform received ZIP files using Aspose.Zip in C#.
 */
