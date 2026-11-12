// HOW-TO: Create a ZIP Archive From Multiple Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "input1.txt";
            string inputPath2 = "input2.txt";

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

            string outputPath = "output.zip";

            string outputDir = Path.GetDirectoryName(outputPath) ?? string.Empty;
            Directory.CreateDirectory(outputDir);

            using (Archive archive = new Archive())
            {
                archive.CreateEntry("input1.txt", new FileInfo(inputPath1));
                archive.CreateEntry("input2.txt", new FileInfo(inputPath2));

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
 * 1. When you need to bundle several local text files into a single ZIP archive for easy email attachment.
 * 2. When you want to programmatically package configuration or settings files into a compressed ZIP before uploading to a server.
 * 3. When you must generate a downloadable ZIP of user‑generated documents in a C# web application.
 * 4. When you are automating the backup of log files by creating a ZIP archive on a scheduled task.
 * 5. When you need to create a portable ZIP archive of source code snippets for distribution to teammates.
 */
