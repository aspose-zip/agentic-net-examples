// HOW-TO: Create Split ZIP of XML Files with 80KB Parts in C# (Aspose.ZIP for .NET)
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
            string inputDir = "InputXml";
            string outputDir = "OutputZip";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                string[] xmlFiles = Directory.GetFiles(inputDir, "*.xml", SearchOption.TopDirectoryOnly);
                foreach (string filePath in xmlFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(81920);
                archive.SaveSplit(outputDir, saveOptions);
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
 * 1. When you need to package many small XML configuration files into a ZIP archive that can be transferred over a network with size‑limited packets, you can split the archive into 80 KB segments.
 * 2. When a legacy system only accepts ZIP files below a certain size, splitting the archive ensures each part meets the limit while preserving all XML data.
 * 3. When you want to back up XML logs to removable media that has a maximum file size restriction, creating split ZIP segments lets you store the backup across multiple files.
 * 4. When distributing XML resources to clients over email attachments that have size caps, generating split ZIP files allows each attachment to stay under the limit.
 * 5. When processing large batches of XML files in a pipeline that requires incremental extraction, a split archive lets you load and extract one segment at a time without loading the entire archive into memory.
 */
