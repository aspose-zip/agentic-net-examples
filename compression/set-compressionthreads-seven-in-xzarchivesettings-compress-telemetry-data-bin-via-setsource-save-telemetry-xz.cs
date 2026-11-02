// HOW-TO: Compress Binary File to XZ with Seven Threads Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\telemetry_data.bin";
            string outputPath = "C:\\Data\\telemetry.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (XzArchive archive = new XzArchive())
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
 * 1. When you need to reduce the size of large telemetry logs before transferring them over a network, you can compress the binary file to an XZ archive using Aspose.Zip with multiple threads in C#.
 * 2. When archiving sensor data for long‑term storage, you can use the XzArchive SetSource method to create a high‑compression XZ file while controlling the thread count for faster processing.
 * 3. When building a backup utility that must handle big binary files efficiently, you can employ Aspose.Zip’s XzArchive to compress the file on the fly and write the result to a specified path in C#.
 * 4. When integrating data compression into a telemetry pipeline, you can set CompressionThreads to seven to balance CPU usage and speed while generating an XZ file for downstream analysis.
 * 5. When developing a cross‑platform .NET service that needs to package binary payloads into a compact XZ container, you can use Aspose.Zip’s SetSource and Save methods to produce the archive with multithreaded compression.
 */
