// HOW-TO: Create XAR Archive With Compressed Executable Using C# FileStream (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFilePath = "C:\\Data\\myExecutable.exe";
            string outputArchivePath = "C:\\Output\\myArchive.xar";

            // Validate input file existence
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Open the input file stream
            using (FileStream inputStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                // Create the output XAR file stream
                using (FileStream outputStream = File.Open(outputArchivePath, FileMode.Create, FileAccess.Write))
                {
                    // Create a new XAR archive
                    using (XarArchive xar = new XarArchive())
                    {
                        // XAR format does not support Bzip2 directly; using Zlib compression as the normal compressed setting
                        XarZlibCompressionSettings compressionSettings = new XarZlibCompressionSettings();

                        // Add the executable as a compressed entry
                        xar.CreateEntry("myExecutable.exe", inputStream, compressionSettings);

                        // Save the XAR archive to the output stream
                        xar.Save(outputStream);
                    }
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
 * 1. When you need to package a Windows executable into a XAR archive for distribution while keeping the file size small.
 * 2. When automating a build pipeline that must bundle compiled binaries into a compressed XAR container for cross‑platform deployment.
 * 3. When creating backup snapshots of application executables and want to store them in a single XAR file with built‑in compression.
 * 4. When developing a custom installer that reads XAR archives and you must generate the archive programmatically in C#.
 * 5. When integrating with macOS XAR‑based update systems and need to compress and archive Windows executables from a .NET application.
 */
