// HOW-TO: Compress a Text File to XZ Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data/source.txt";
            string outputPath = "output/output.xz";

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

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of log or configuration files before uploading them to a server, you can use this code to create an XZ archive in C# with Aspose.Zip.
 * 2. When a .NET application must generate a portable, high‑compression backup of a single text document for long‑term storage, this snippet creates an .xz file programmatically.
 * 3. When integrating automated build pipelines that package generated reports into XZ archives for distribution, developers can employ this code to compress the report files on the fly.
 * 4. When implementing a file‑transfer feature that sends large text files over limited bandwidth, the code shows how to compress the file to XZ format using Aspose.Zip before transmission.
 * 5. When building a Windows service that periodically archives sensor data files into a space‑efficient format, this example demonstrates the C# approach to create .xz archives with Aspose.Zip.
 */
