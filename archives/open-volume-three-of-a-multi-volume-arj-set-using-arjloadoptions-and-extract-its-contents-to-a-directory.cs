// HOW-TO: Extract Third Volume Of Multi‑Volume ARJ Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\archive.r02";
            string outputPath = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            ArjLoadOptions loadOptions = new ArjLoadOptions();

            using (ArjArchive archive = new ArjArchive(inputPath, loadOptions))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a specific part of a split ARJ backup that spans multiple files, such as the third volume, to restore data on a Windows server using C#.
 * 2. When a legacy application produces multi‑volume ARJ archives and you must programmatically extract the contents of a particular volume to a target directory in a .NET service.
 * 3. When automating migration of archived logs stored in a three‑part ARJ set, and you need to extract only the third segment to process recent entries.
 * 4. When building a file‑recovery tool that reads ARJ split archives and extracts the selected volume to a temporary folder for validation before full reconstruction.
 * 5. When integrating with an existing backup workflow that saves large datasets as r01, r02, r03 files, and you need C# code to open the r02 (third) volume and extract its files for further analysis.
 */
