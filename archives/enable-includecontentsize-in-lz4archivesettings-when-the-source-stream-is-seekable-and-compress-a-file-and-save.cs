// HOW-TO: Compress a File to LZ4 with IncludeContentSize in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output.lz4";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of a log file before transferring it over a network, you can use this code to create a LZ4 archive that includes the original content size for faster validation.
 * 2. When building a backup utility that stores individual files as separate LZ4 streams, enabling IncludeContentSize ensures the archive can be decompressed even if the source stream supports seeking.
 * 3. When integrating file compression into a .NET application that processes large text files, this snippet shows how to compress the file locally while preserving size metadata for later integrity checks.
 * 4. When creating a lightweight packaging format for configuration files, you can use the code to generate a .lz4 file that can be quickly decompressed by downstream services.
 * 5. When developing a data pipeline that archives intermediate results, this example demonstrates saving the compressed output to disk with LZ4 settings that retain the original content length for monitoring purposes.
 */
