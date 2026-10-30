// HOW-TO: How To Decompress A .Tar.Bz2 Archive And Extract Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tar.bz2";
            string outputDirectory = "Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Bzip2Archive bzip2 = new Bzip2Archive())
            {
                bzip2.SetSource(inputPath);
                using (MemoryStream tarStream = new MemoryStream())
                {
                    bzip2.Save(tarStream);
                    tarStream.Position = 0;

                    using (TarArchive tar = new TarArchive(tarStream))
                    {
                        tar.ExtractToDirectory(outputDirectory);
                    }
                }
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
 * 1. When you receive a .tar.bz2 backup from a Linux server and need to programmatically extract its contents in a .NET application.
 * 2. When you want to automate the processing of compressed data packages shipped as .tar.bz2 files for further analysis in C#.
 * 3. When your deployment pipeline must unpack a .tar.bz2 distribution archive before copying files to a target directory.
 * 4. When you need to read a .tar.bz2 log archive, decompress it in memory, and extract the logs to a local folder without writing intermediate files to disk.
 * 5. When building a cross‑platform tool that handles legacy Unix compression formats, such as .tar.bz2, within a Windows C# environment.
 */
