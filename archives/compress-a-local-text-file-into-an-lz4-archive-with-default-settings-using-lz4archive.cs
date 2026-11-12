// HOW-TO: Compress a Text File to LZ4 Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "data/input.txt";
            string outputPath = "data/output.lz4";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create LZ4 archive, set source file, and save
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"File compressed successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of log or configuration files before sending them over a network, you can compress the text file into an LZ4 archive with Aspose.Zip in C#.
 * 2. When building a backup utility that stores daily reports in a fast‑decompressing format, this code lets you create LZ4 archives of the reports programmatically.
 * 3. When integrating a data‑pipeline that archives intermediate CSV outputs for later analysis, you can use the snippet to pack each file into an LZ4 container efficiently.
 * 4. When developing a game or IoT application that must store large text resources on limited storage, the example shows how to shrink those resources using LZ4 compression in .NET.
 * 5. When creating a command‑line tool that prepares files for cloud upload with minimal CPU overhead, this code demonstrates the straightforward way to generate LZ4 archives in C#.
 */
