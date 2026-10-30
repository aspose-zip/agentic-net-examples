// HOW-TO: Extract BZIP2 Archive To File Stream Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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

            using (FileStream inputStream = File.OpenRead(inputPath))
            {
                using (Bzip2Archive archive = new Bzip2Archive(inputStream))
                {
                    using (FileStream outputStream = File.Create(outputPath))
                    {
                        archive.Extract(outputStream);
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
 * 1. When you need to decompress a .bz2 log file directly into a writable stream for further processing in a .NET application.
 * 2. When a server receives BZIP2‑compressed configuration files and you must extract them to disk without loading the entire archive into memory.
 * 3. When integrating legacy backup data stored as BZIP2 archives into a modern C# service that writes the contents to a new file.
 * 4. When building a file‑transfer utility that automatically unpacks incoming .bz2 files into specified output locations.
 * 5. When performing batch extraction of compressed text reports in a Windows environment using Aspose.Zip’s Bzip2Archive class.
 */
