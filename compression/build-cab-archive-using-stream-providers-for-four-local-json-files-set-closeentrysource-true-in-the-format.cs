// HOW-TO: Create CAB Archive from Multiple JSON Files Using Stream Providers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JSON file paths
            string inputPath1 = "data1.json";
            string inputPath2 = "data2.json";
            string inputPath3 = "data3.json";
            string inputPath4 = "data4.json";

            // Hardcoded output CAB file path
            string outputPath = "json_bundle.cab";

            // Validate each input file exists
            if (!File.Exists(inputPath1)) { Console.Error.WriteLine($"File not found: {inputPath1}"); return; }
            if (!File.Exists(inputPath2)) { Console.Error.WriteLine($"File not found: {inputPath2}"); return; }
            if (!File.Exists(inputPath3)) { Console.Error.WriteLine($"File not found: {inputPath3}"); return; }
            if (!File.Exists(inputPath4)) { Console.Error.WriteLine($"File not found: {inputPath4}"); return; }

            // Ensure the output directory exists (guard against null/empty)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new CAB archive
            using (CabArchive cab = new CabArchive())
            {
                // Default entry settings using MSZIP compression
                CabEntrySettings entrySettings = new CabEntrySettings(new CabMsZipCompressionSettings());

                // Add first JSON file as an entry using a stream provider
                using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                {
                    cab.CreateEntry("data1.json", fs1, entrySettings);
                }

                // Add second JSON file
                using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                {
                    cab.CreateEntry("data2.json", fs2, entrySettings);
                }

                // Add third JSON file
                using (FileStream fs3 = new FileStream(inputPath3, FileMode.Open, FileAccess.Read))
                {
                    cab.CreateEntry("data3.json", fs3, entrySettings);
                }

                // Add fourth JSON file
                using (FileStream fs4 = new FileStream(inputPath4, FileMode.Open, FileAccess.Read))
                {
                    cab.CreateEntry("data4.json", fs4, entrySettings);
                }

                // Save the CAB archive to the specified output path
                cab.Save(outputPath);
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
 * 1. When you need to bundle several configuration JSON files into a single CAB package for easy distribution with MSZIP compression in a .NET application.
 * 2. When deploying a Windows service that requires all its JSON settings to be shipped as a compressed CAB archive to reduce file count and improve installation speed.
 * 3. When creating backup archives of small JSON data sets and want to use stream providers to avoid loading entire files into memory.
 * 4. When integrating with legacy Windows installers that only accept CAB files, and you must programmatically add multiple JSON resources from disk.
 * 5. When you want to generate a CAB file on the fly in a web API, ensuring each JSON entry is written directly from a FileStream and the source streams are closed automatically.
 */
