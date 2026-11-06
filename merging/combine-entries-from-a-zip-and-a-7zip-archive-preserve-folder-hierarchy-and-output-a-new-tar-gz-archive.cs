// HOW-TO: Combine ZIP and 7z Files into a Gzipped TAR in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Tar;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string zipPath = "input.zip";
            string sevenZipPath = "input.7z";
            string outputTarGzPath = "output.tar.gz";

            // Validate input files
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }
            if (!File.Exists(sevenZipPath))
            {
                Console.Error.WriteLine($"File not found: {sevenZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

            // Temporary directory to combine extracted contents
            string tempCombineDir = Path.Combine(Path.GetDirectoryName(outputTarGzPath), "tempCombined");
            Directory.CreateDirectory(tempCombineDir);

            // Extract ZIP archive preserving hierarchy
            using (Archive zipArchive = new Archive(zipPath))
            {
                zipArchive.ExtractToDirectory(tempCombineDir);
            }

            // Extract 7ZIP archive preserving hierarchy
            using (SevenZipArchive sevenArchive = new SevenZipArchive(sevenZipPath))
            {
                sevenArchive.ExtractToDirectory(tempCombineDir);
            }

            // Create TAR archive from combined directory and save as GZipped TAR
            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntries(tempCombineDir);
                tarArchive.SaveGzipped(outputTarGzPath);
            }

            // Optionally clean up temporary directory
            // Directory.Delete(tempCombineDir, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to merge contents from a standard ZIP and a 7‑Zip archive while keeping their folder structures and deliver them as a single .tar.gz package for Linux deployment.
 * 2. When a backup system stores data in both .zip and .7z formats and you must create a compressed tarball to upload to a cloud storage service that only accepts .tar.gz files.
 * 3. When you are building a cross‑platform installer that gathers resources from multiple archive types and packages them into a gzipped tar archive for distribution on Unix‑like systems.
 * 4. When you want to extract two different compressed archives, combine their directory trees, and re‑compress them into a single archive to reduce the number of files a user must download.
 * 5. When automating a CI/CD pipeline that receives artifacts as .zip and .7z files and needs to produce a .tar.gz artifact for downstream Linux containers or Docker images.
 */
