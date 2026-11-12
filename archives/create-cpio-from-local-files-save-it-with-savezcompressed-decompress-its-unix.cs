// HOW-TO: Create Z‑Compressed CPIO Archive From Files And Extract In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\Data\Input";
            string outputArchivePath = @"C:\Data\output.cpio.z";
            string extractDirectory = @"C:\Data\Extracted";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));
            Directory.CreateDirectory(extractDirectory);

            using (CpioArchive archive = new CpioArchive())
            {
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                archive.SaveZCompressed(outputArchivePath);
            }

            using (CpioArchive archive = new CpioArchive(outputArchivePath))
            {
                foreach (CpioEntry entry in archive.Entries)
                {
                    string destinationPath = Path.Combine(extractDirectory, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        entryStream.CopyTo(fileStream);
                    }
                }
            }

            Console.WriteLine("Archive created, compressed, and extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple log files into a single CPIO archive and compress it for efficient storage or transfer on Linux systems.
 * 2. When you want to generate a Z‑compressed CPIO package programmatically in a .NET application for deployment to Unix‑based servers.
 * 3. When you must extract the contents of a compressed CPIO archive on Windows before sending the files to a Unix environment.
 * 4. When automating backup of configuration files by creating a compressed CPIO archive that can be easily unpacked by standard Unix tools.
 * 5. When integrating CPIO archive creation and extraction into a CI/CD pipeline to package build artifacts for cross‑platform distribution.
 */
