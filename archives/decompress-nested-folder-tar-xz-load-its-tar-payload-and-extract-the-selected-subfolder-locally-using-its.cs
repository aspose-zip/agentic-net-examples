// HOW-TO: Extract Specific Subfolder From Tar.Xz Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "nested_folder.tar.xz";
            string outputRoot = "ExtractedSubfolder";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputRoot);

            // Decompress the .xz archive to obtain the TAR payload
            using (XzArchive xzArchive = new XzArchive())
            {
                xzArchive.SetSource(inputPath);

                using (MemoryStream tarStream = new MemoryStream())
                {
                    // Extract decompressed data into a memory stream
                    xzArchive.Extract(tarStream);
                    tarStream.Position = 0;

                    // Load the TAR archive from the decompressed stream
                    using (TarArchive tarArchive = new TarArchive(tarStream))
                    {
                        // Define the subfolder inside the TAR to extract
                        string targetFolder = "subfolder/";

                        // Iterate through all entries in the TAR archive
                        foreach (TarEntry entry in tarArchive.Entries)
                        {
                            // Process only entries that belong to the selected subfolder
                            if (entry.Name.StartsWith(targetFolder, StringComparison.OrdinalIgnoreCase))
                            {
                                // Compute the relative path inside the target subfolder
                                string relativePath = entry.Name.Substring(targetFolder.Length);
                                string destinationPath = Path.Combine(outputRoot, relativePath);

                                if (entry.IsDirectory)
                                {
                                    // Create directory for the entry
                                    Directory.CreateDirectory(destinationPath);
                                }
                                else
                                {
                                    // Ensure the directory for the file exists
                                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                                    // Extract the file entry to the destination path
                                    using (FileStream outputFile = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                                    {
                                        using (Stream entryStream = entry.Open())
                                        {
                                            entryStream.CopyTo(outputFile);
                                        }
                                    }
                                }
                            }
                        }
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
 * 1. When you need to decompress a .tar.xz package and retrieve only a particular directory for processing in a .NET application.
 * 2. When a build pipeline receives a compressed tarball containing multiple modules and you want to extract just the module's folder to reduce I/O.
 * 3. When deploying updates from a vendor distribution that ships as tar.xz and you only need the configuration subfolder on the target machine.
 * 4. When analyzing log files stored inside a nested archive and you want to pull out only the logs directory without extracting the entire archive.
 * 5. When creating a backup restoration tool that restores a specific project folder from a tar.xz backup archive in C#.
 */
