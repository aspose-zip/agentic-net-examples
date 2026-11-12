// HOW-TO: Create CAB Archive Entry From FileStream With CloseEntrySource In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = "input/sample.txt";
            string outputCabPath = "output/http_cab.cab";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            using (FileStream sourceStream = File.OpenRead(inputFilePath))
            {
                using (CabArchive cab = new CabArchive())
                {
                    cab.CreateEntry("sample.txt", sourceStream);
                    cab.Save(outputCabPath);
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
 * 1. When you need to package a configuration file into a CAB archive for deployment in a Windows installer using C#.
 * 2. When you want to programmatically add a log file to a CAB archive without loading the entire file into memory, using a FileStream.
 * 3. When you must ensure the source stream is automatically closed after the entry is written by enabling CloseEntrySource in the save options.
 * 4. When you are generating a CAB file for HTTP delivery (http_cab.cab) as part of a web application’s asset pipeline in .NET.
 * 5. When you require a simple way to create a CAB archive on the fly for backup or distribution of multiple files in a Windows environment.
 */
