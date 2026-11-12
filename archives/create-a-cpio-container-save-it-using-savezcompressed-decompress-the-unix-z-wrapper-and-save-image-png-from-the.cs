// HOW-TO: Create and Z‑Compress a CPIO Archive Containing an Image in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputImagePath = "input/image.png";
            string cpioZPath = "output/archive.cpio.z";

            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(cpioZPath));

            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntry("image.png", inputImagePath);
                archive.SaveZCompressed(cpioZPath);
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
 * 1. When you need to package a PNG file into a Unix‑compatible CPIO archive and compress it with the traditional Z format for distribution on legacy systems.
 * 2. When automating backup scripts that must create a single compressed file (.cpio.z) to store images before transferring them over SSH.
 * 3. When integrating with older embedded devices that only understand CPIO archives wrapped in Z compression, allowing you to embed resources like icons.
 * 4. When preparing software installation packages for Unix environments where the installer expects a .cpio.z payload containing assets.
 * 5. When implementing a custom deployment pipeline that compresses image assets into a single archive to reduce storage space and simplify extraction.
 */
