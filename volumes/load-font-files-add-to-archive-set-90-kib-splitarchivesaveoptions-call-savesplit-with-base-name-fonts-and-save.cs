// HOW-TO: Split Large Font Files into Multiple ZIP Segments in C# (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\Data\Fonts";
            string outputDirectory = @"C:\Data\Output";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Archive archive = new Archive())
            {
                foreach (string filePath in Directory.GetFiles(inputDirectory, "*.ttf"))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("fonts", 90 * 1024);
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
 * 1. When you need to package a collection of TrueType fonts for distribution but the target system only accepts ZIP files smaller than 100 KB, you can split the archive into 90 KB parts.
 * 2. When uploading font resources to a web service that imposes a maximum upload size per file, creating split ZIP segments lets you stay within the limit.
 * 3. When backing up font files to removable media with a fixed capacity per file, such as legacy USB drives or CDs, splitting the archive ensures each segment fits.
 * 4. When sending fonts via email where attachment size is restricted, generating multiple small ZIP files allows the recipient to receive all fonts.
 * 5. When storing fonts in cloud storage that prefers smaller chunks for cost efficiency, splitting the archive into uniform parts optimizes storage and retrieval.
 */
