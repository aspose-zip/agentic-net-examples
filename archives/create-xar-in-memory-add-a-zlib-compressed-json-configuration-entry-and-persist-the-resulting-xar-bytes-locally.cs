// HOW-TO: Create XAR Archive with Zlib Compressed JSON Config in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/config.xar";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string jsonFilePath = "temp/config.json";
            Directory.CreateDirectory(Path.GetDirectoryName(jsonFilePath));

            string jsonContent = "{ \"setting\": \"value\", \"enabled\": true }";
            byte[] jsonBytes = Encoding.UTF8.GetBytes(jsonContent);
            File.WriteAllBytes(jsonFilePath, jsonBytes);

            if (!File.Exists(jsonFilePath))
            {
                Console.Error.WriteLine($"File not found: {jsonFilePath}");
                return;
            }

            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                archive.CreateEntry("config.json", jsonFilePath, openImmediately: false, compressionSettings: defaultCompression);
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
 * 1. When you need to package application settings into a single XAR file for easy distribution and version control.
 * 2. When you want to compress configuration data using Zlib to reduce file size before deploying to embedded devices.
 * 3. When you must generate an XAR archive programmatically in C# without writing intermediate files to disk.
 * 4. When you require a portable archive that stores JSON configuration alongside other resources for backup or transport.
 * 5. When you need to automate the creation of a compressed XAR bundle as part of a CI/CD pipeline for configuration management.
 */
