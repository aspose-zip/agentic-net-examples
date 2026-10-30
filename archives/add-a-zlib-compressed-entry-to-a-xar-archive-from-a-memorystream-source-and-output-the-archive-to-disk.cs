// HOW-TO: Create XAR Archive With Zlib Compression From Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input paths
            string textFilePath = "sample.txt";
            if (!File.Exists(textFilePath))
            {
                Console.Error.WriteLine($"File not found: {textFilePath}");
                return;
            }

            string htmlFilePath = "sample.html";
            if (!File.Exists(htmlFilePath))
            {
                Console.Error.WriteLine($"File not found: {htmlFilePath}");
                return;
            }

            string directoryToPack = "FolderToPack";
            if (!Directory.Exists(directoryToPack))
            {
                Console.Error.WriteLine($"Directory not found: {directoryToPack}");
                return;
            }

            // Define output XAR file path
            string xarOutput = "output.xar";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(xarOutput) ?? ".");

            // Create default Zlib compression settings
            XarCompressionSettings defaultCompression = new XarZlibCompressionSettings();

            // Initialize the XAR archive with the default compression settings
            using (XarArchive archive = new XarArchive(defaultCompression))
            {
                // Add a Zlib-compressed entry from a file
                archive.CreateEntry("sample.txt", textFilePath, openImmediately: false, compressionSettings: defaultCompression);

                // Add a stored (no compression) entry from a file
                XarCompressionSettings storeCompression = new XarStoreCompressionSettings();
                archive.CreateEntry("sample.html", htmlFilePath, openImmediately: false, compressionSettings: storeCompression);

                // Add all entries from a directory with default compression
                archive.CreateEntries(directoryToPack, includeRootDirectory: false, compressionSettings: defaultCompression);

                // Save the XAR archive to disk
                archive.Save(xarOutput);
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
 * 1. When you need to package multiple files into a single XAR archive with Zlib compression for efficient storage or distribution in a .NET application.
 * 2. When you want to include both compressed and uncompressed entries in the same XAR file to balance performance and size for different file types.
 * 3. When you must generate an XAR archive on the fly from a directory structure and write it directly to disk without intermediate temporary files.
 * 4. When your deployment process requires creating XAR archives that can be later extracted by tools that support Zlib compression, such as macOS installer packages.
 * 5. When you are building a backup solution in C# that stores files in a compressed XAR container to reduce disk usage while preserving original file hierarchy.
 */
