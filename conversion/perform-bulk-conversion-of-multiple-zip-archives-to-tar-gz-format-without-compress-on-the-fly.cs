// HOW-TO: Convert Multiple ZIP Files to TAR.GZ in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string[] zipPaths = new string[]
            {
                "C:\\Data\\Archive1.zip",
                "C:\\Data\\Archive2.zip"
            };

            foreach (string zipPath in zipPaths)
            {
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    continue;
                }

                string outputDirectory = "C:\\Output";
                Directory.CreateDirectory(outputDirectory);

                string tarGzPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(zipPath) + ".tar.gz");
                Directory.CreateDirectory(Path.GetDirectoryName(tarGzPath));

                // Extract ZIP to a temporary folder
                string tempExtractDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempExtractDir);

                using (Archive zipArchive = new Archive(zipPath))
                {
                    zipArchive.ExtractToDirectory(tempExtractDir);
                }

                // Create TAR.GZ from extracted files
                using (TarArchive tarArchive = new TarArchive())
                {
                    tarArchive.CreateEntries(new DirectoryInfo(tempExtractDir));
                    tarArchive.SaveGzipped(tarGzPath);
                }

                // Clean up temporary extraction folder
                Directory.Delete(tempExtractDir, true);
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
 * 1. When you need to migrate legacy ZIP backups to TAR.GZ for Linux‑based storage pipelines.
 * 2. When processing a batch of user‑uploaded ZIP archives and storing them as compressed TAR files to save space on a server.
 * 3. When integrating with a CI/CD workflow that requires build artifacts in TAR.GZ format instead of ZIP.
 * 4. When converting archived project resources from ZIP to TAR.GZ before uploading to a cloud bucket that only accepts tar.gz files.
 * 5. When automating archival of log files that are originally zipped, converting them to TAR.GZ for long‑term retention without recompressing the data.
 */
