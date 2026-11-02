// HOW-TO: Create CAB Archive from Multiple XML Files with Stream Providers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input XML files
            string inputXmlPath1 = "input1.xml";
            string inputXmlPath2 = "input2.xml";

            // Output CAB file
            string outputCabPath = "output/xml.cab";

            // Validate input files
            if (!File.Exists(inputXmlPath1))
            {
                Console.Error.WriteLine($"File not found: {inputXmlPath1}");
                return;
            }
            if (!File.Exists(inputXmlPath2))
            {
                Console.Error.WriteLine($"File not found: {inputXmlPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCabPath));

            // Default compression (MS-ZIP) and stored (no compression) settings
            CabEntrySettings defaultSettings = new CabEntrySettings(new CabMsZipCompressionSettings());
            CabEntrySettings storedSettings = new CabEntrySettings(new CabStoreCompressionSettings());

            // Create CAB archive with default settings
            using (CabArchive archive = new CabArchive(defaultSettings))
            {
                // Add first XML file with default compression
                using (FileStream stream1 = new FileStream(inputXmlPath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("first.xml", stream1);
                }

                // Add second XML file with stored (no compression) setting
                using (FileStream stream2 = new FileStream(inputXmlPath2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("second.xml", stream2, storedSettings);
                }

                // Save the CAB archive
                archive.Save(outputCabPath);
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
 * 1. When you need to package configuration XML files into a single CAB for distribution with Windows installers.
 * 2. When you want to compress one XML file while storing another without compression to preserve its original size.
 * 3. When you must generate a CAB archive on the fly using streams to avoid loading whole files into memory.
 * 4. When you are building a deployment pipeline that automatically creates CAB archives for backup or versioning of XML resources.
 * 5. When you require deterministic disposal of file streams while creating a CAB to prevent file locks in a .NET application.
 */
