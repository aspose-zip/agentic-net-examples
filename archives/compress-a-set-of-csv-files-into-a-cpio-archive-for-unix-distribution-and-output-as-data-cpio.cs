// HOW-TO: Create CPIO Archive of CSV Files in C# for Unix Distribution (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing CSV files
            string inputDir = @"C:\Data\CsvFiles";
            // Hardcoded output CPIO archive path
            string outputPath = @"C:\Data\data.cpio";

            // Verify the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new CPIO archive and add all files from the input directory
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntries(inputDir);
                archive.Save(outputPath);
            }

            Console.WriteLine($"CPIO archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package multiple CSV reports into a single CPIO file for deployment on a Linux server using a C# build script.
 * 2. When automating the creation of a Unix‑compatible archive of data exports before transferring them via SCP or FTP.
 * 3. When preparing a backup of CSV log files that must be read by legacy Unix tools expecting a CPIO container.
 * 4. When integrating data packaging into a CI/CD pipeline that generates CPIO archives for downstream Linux‑based processing jobs.
 * 5. When consolidating CSV configuration files into a single archive to simplify distribution to multiple Unix workstations.
 */
