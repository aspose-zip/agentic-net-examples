// HOW-TO: Create a Z‑Compressed CPIO Archive from a Folder in C# (Aspose.ZIP for .NET)
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
            string outputArchivePath = @"C:\Data\Output\archive.cpio.z";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntries(inputDirectory);
                archive.SaveZCompressed(outputArchivePath);
            }

            Console.WriteLine("Archive created and compressed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a directory of files into a single CPIO archive for Unix systems and compress it to reduce size before transferring over the network.
 * 2. When automating backup scripts in a Windows environment that must produce CPIO.Z files compatible with legacy Unix extraction tools.
 * 3. When deploying configuration files to embedded Linux devices that require a compressed CPIO archive as the installation payload.
 * 4. When creating a reproducible build artifact that bundles compiled binaries and resources into a single compressed CPIO file for distribution.
 * 5. When integrating C# applications with existing CI/CD pipelines that generate CPIO.Z archives for downstream Unix‑based testing stages.
 */
