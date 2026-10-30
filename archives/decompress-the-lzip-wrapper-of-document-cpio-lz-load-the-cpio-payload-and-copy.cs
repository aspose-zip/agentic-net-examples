// HOW-TO: Decompress LZIP Wrapper and Extract CPIO Archive to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Lzip;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input LZIP file path
            string inputLzipPath = "document.cpio.lz";
            // Temporary path for extracted CPIO file
            string tempCpioPath = "temp.cpio";
            // Output directory for CPIO contents
            string outputDirectory = "ExtractedCpio";

            // Verify input file exists
            if (!File.Exists(inputLzipPath))
            {
                Console.Error.WriteLine($"File not found: {inputLzipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Decompress LZIP wrapper and extract the inner CPIO file
            using (LzipArchive lzipArchive = new LzipArchive(inputLzipPath))
            {
                using (FileStream cpioStream = File.Create(tempCpioPath))
                {
                    lzipArchive.Extract(cpioStream);
                }
            }

            // Verify the temporary CPIO file was created
            if (!File.Exists(tempCpioPath))
            {
                Console.Error.WriteLine($"Failed to extract CPIO payload to {tempCpioPath}");
                return;
            }

            // Load the CPIO archive and copy its entries to the output directory
            using (CpioArchive cpioArchive = new CpioArchive(tempCpioPath))
            {
                foreach (CpioEntry cpioEntry in cpioArchive.Entries)
                {
                    string destinationPath = Path.Combine(outputDirectory, cpioEntry.Name);
                    string destinationDir = Path.GetDirectoryName(destinationPath);
                    Directory.CreateDirectory(destinationDir);

                    using (FileStream outputStream = File.Create(destinationPath))
                    {
                        cpioEntry.Extract(outputStream);
                    }
                }
            }

            // Clean up temporary CPIO file
            if (File.Exists(tempCpioPath))
            {
                File.Delete(tempCpioPath);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a .cpio.lz file from a Linux build system and need to unpack its contents on a Windows .NET application.
 * 2. When you must programmatically extract files from a compressed CPIO archive that is wrapped in LZIP for further processing or analysis.
 * 3. When an automated deployment pipeline stores configuration files in LZIP‑compressed CPIO packages and you need to retrieve them in C#.
 * 4. When you are building a migration tool that reads legacy LZIP‑wrapped CPIO backups and writes the individual files to a directory structure.
 * 5. When a security scanner provides logs as .cpio.lz archives and you need to decompress and examine each log file using .NET code.
 */
