// HOW-TO: Create CPIO Archive from Folder in C# with Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "C:\\Data\\Docs";
            string outputPath = "C:\\Data\\docs.cpio";

            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntries(inputFolder);
                archive.Save(outputPath);
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
 * 1. When you need to package a set of configuration files for deployment on a Unix system, you can use this code to create a CPIO archive directly from a C# application.
 * 2. When automating backup of documentation directories on Windows before transferring them to a Linux server, the code generates a single docs.cpio file for easy transport.
 * 3. When building a cross‑platform installer that requires Unix‑style CPIO packages, developers can compress the source folder with Aspose.Zip in .NET.
 * 4. When integrating a CI/CD pipeline that must bundle generated reports into a CPIO archive for later extraction on a Unix build agent, this snippet provides the needed compression step.
 * 5. When creating a reproducible archive of source code or assets for archival compliance that must be readable by standard Unix tools, the code creates the CPIO file without external command‑line utilities.
 */
