// HOW-TO: Split Large Binary Files Into 300KB Zip Parts Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputPath1 = @"C:\Data\blob1.bin";
            string inputPath2 = @"C:\Data\blob2.bin";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            string outputDirectory = @"C:\Output\DatablobSplit";

            Directory.CreateDirectory(outputDirectory);

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("blob1.bin", new FileInfo(inputPath1));
                archive.CreateEntry("blob2.bin", new FileInfo(inputPath2));

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(300 * 1024);

                archive.SaveSplit(outputDirectory, saveOptions);
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
 * 1. When you need to archive multiple large binary blobs but must keep each ZIP segment under a specific size limit for email attachment restrictions.
 * 2. When a backup system requires splitting archives into 300 KB chunks to fit on legacy storage media such as floppy disks or small flash drives.
 * 3. When a cloud upload API only accepts files smaller than 500 KB, you can pre‑split the archive into 300 KB parts before transmission.
 * 4. When distributing software updates over limited‑bandwidth channels, splitting the ZIP ensures each part can be downloaded and verified independently.
 * 5. When integrating with third‑party tools that only process ZIP files of a certain maximum size, you can create compliant split archives directly from C#.
 */
