// HOW-TO: How To Decompress A BZ2 File To A Stream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\sample.bz2";
            string outputPath = "C:\\Data\\output.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive(inputPath))
            {
                using (Stream source = archive.Open())
                {
                    using (FileStream dest = File.Create(outputPath))
                    {
                        source.CopyTo(dest);
                    }
                }
            }

            Console.WriteLine("Decompression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a large text log stored as a .bz2 archive on a server and write it directly to a local file using C#.
 * 2. When an application receives compressed data in Bzip2 format over a network and must decompress it on‑the‑fly without loading the entire archive into memory.
 * 3. When automating a data‑pipeline that processes daily backup files delivered as .bz2 archives and you need to programmatically unpack them to a working directory.
 * 4. When integrating legacy Unix‑style Bzip2 compressed configuration files into a .NET service that requires them in plain‑text form.
 * 5. When building a utility that validates the integrity of .bz2 archives by opening them as streams and copying their contents to a destination file.
 */
