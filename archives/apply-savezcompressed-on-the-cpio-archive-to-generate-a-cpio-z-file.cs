// HOW-TO: Compress CPIO Archive to Z Format Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cpio";
            string outputPath = "output.cpio.Z";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the CPIO archive and save it with Z compression
            using (CpioArchive archive = new CpioArchive(inputPath))
            {
                archive.SaveZCompressed(outputPath);
            }

            Console.WriteLine($"Archive saved successfully to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a CPIO package for faster network transfer or storage, you can compress it to a .cpio.Z file using Aspose.Zip in C#.
 * 2. When distributing Linux kernel modules or initramfs images that must be in Z‑compressed CPIO format, this code creates the required .cpio.Z archive programmatically.
 * 3. When automating backup scripts that archive system files into CPIO and then apply legacy Z compression for compatibility with older tools, the snippet handles the conversion.
 * 4. When integrating a .NET application with a legacy deployment pipeline that expects .cpio.Z files, you can generate the compressed archive directly from C# without external utilities.
 * 5. When building a cross‑platform installer that packages resources in CPIO and needs to compress them to meet size constraints, this example shows how to produce the Z‑compressed archive on the fly.
 */
