// HOW-TO: Create Split ZIP of JSON Config Files with 64KB Segments in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = @"C:\Data\JsonConfigs";
            string outputDir = @"C:\Output";

            if (!Directory.Exists(dataDir))
            {
                Console.Error.WriteLine($"Directory not found: {dataDir}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                string[] jsonFiles = Directory.GetFiles(dataDir, "*.json", SearchOption.TopDirectoryOnly);
                foreach (string jsonFilePath in jsonFiles)
                {
                    if (!File.Exists(jsonFilePath))
                    {
                        Console.Error.WriteLine($"File not found: {jsonFilePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(jsonFilePath);
                    FileInfo fileInfo = new FileInfo(jsonFilePath);
                    archive.CreateEntry(entryName, fileInfo);
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(64 * 1024);

                string basePath = Path.Combine(outputDir, "config");
                Directory.CreateDirectory(Path.GetDirectoryName(basePath));

                archive.SaveSplit(basePath, saveOptions);
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
 * 1. When you need to package multiple JSON configuration files into a ZIP archive that can be transferred over networks with size limits, such as email attachments or legacy file systems.
 * 2. When you want to split a large ZIP archive into 64 KiB parts to comply with storage media constraints like floppy disks or old USB drives.
 * 3. When you must generate a set of sequentially named ZIP segments (config.z01, config.z02, …) for incremental backup or distribution of configuration data.
 * 4. When you need to programmatically create a ZIP archive in C# without using external tools, ensuring each entry preserves the original file name and metadata.
 * 5. When you are building an automated deployment pipeline that bundles configuration JSON files into split archives for reliable extraction on target machines.
 */
