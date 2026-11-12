// HOW-TO: Add Uncompressed Config File to XAR Archive Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string configFilePath = "config.cfg";
            string xarOutputPath = "output\\archive.xar";

            if (!File.Exists(configFilePath))
            {
                Console.Error.WriteLine($"File not found: {configFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(xarOutputPath));

            XarCompressionSettings storeCompression = new XarStoreCompressionSettings();

            using (XarArchive archive = new XarArchive(storeCompression))
            {
                FileInfo configFileInfo = new FileInfo(configFilePath);
                archive.CreateEntry(
                    configFileInfo.Name,
                    configFileInfo.FullName,
                    false,
                    storeCompression);

                archive.Save(xarOutputPath);
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
 * 1. When you need to bundle a configuration file with an application deployment package without compressing it, you can add it as an uncompressed entry to a XAR archive in C#.
 * 2. When creating a backup of system settings where the config file must remain directly readable, you can store it uncompressed in a XAR archive using FileInfo.
 * 3. When generating a XAR archive for a software installer that requires the config file to be extracted quickly, you can add the file with store compression to avoid decompression overhead.
 * 4. When integrating Aspose.Zip into a CI pipeline to package build artifacts while preserving the original file size of configuration files, you can create an uncompressed XAR entry in C#.
 * 5. When distributing configuration files alongside other compressed resources but need them to stay unchanged for version control, you can use the XarStoreCompressionSettings to add the file uncompressed to the XAR archive.
 */
