// HOW-TO: Compress Existing TAR Archive to XZ File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\example.tar";
            string outputPath = @"C:\Data\example.tar.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive archive = new TarArchive(inputPath))
            {
                archive.SaveXzCompressed(outputPath);
            }

            Console.WriteLine($"Compressed TAR archive saved as XZ: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to shrink a TAR backup before uploading it to cloud storage, you can compress it to an XZ file with this code.
 * 2. When distributing Linux packages over limited bandwidth, converting a .tar archive to .tar.xz using Aspose.Zip in a C# build pipeline reduces transfer size.
 * 3. When archiving large sets of log files for long‑term retention, turning the TAR collection into XZ format helps save disk space on Windows servers.
 * 4. When integrating a .NET application with a Linux deployment workflow, generating .tar.xz archives ensures compatibility with standard Linux extraction tools.
 * 5. When automating nightly data exports, compressing the generated TAR files to XZ speeds up transfer to remote backup systems.
 */
