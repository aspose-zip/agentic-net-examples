// HOW-TO: Create TAR.XZ Archive With CRC32 Checks For C# Source Files (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "source1.cs";
            string inputPath2 = "source2.cs";
            string inputPath3 = "source3.cs";

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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            string outputPath = "output/combined.tar.xz";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntry("source1.cs", inputPath1);
                tarArchive.CreateEntry("source2.cs", inputPath2);
                tarArchive.CreateEntry("source3.cs", inputPath3);

                tarArchive.SaveXzCompressed(outputPath);
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
 * 1. When you need to bundle several C# source files into a single portable archive for distribution or backup, you can create a TAR archive and compress it with XZ while adding CRC32 integrity checks.
 * 2. When deploying a .NET project to a Linux environment, you may package the .cs files into a .tar.xz file to preserve file permissions and reduce size before transfer.
 * 3. When sending source code over unreliable networks, using XZ compression with CRC32 ensures the archive is both small and can be verified for corruption on receipt.
 * 4. When archiving versioned source files for long‑term storage, a TAR.XZ archive provides a standard, open‑format container that can be extracted by many tools.
 * 5. When automating build pipelines, you can generate a compressed TAR.XZ of selected source files to include as an artifact for later stages or external reviewers.
 */
