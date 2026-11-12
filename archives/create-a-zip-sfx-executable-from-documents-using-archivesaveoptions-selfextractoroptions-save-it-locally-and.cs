// HOW-TO: Create Self‑Extracting ZIP Executable with AutoExtract AutoClose Switches in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing documents to be packaged.
            string inputDirectory = @"C:\Data\InputDocs";

            // Hardcoded output directory for the generated SFX executable and invocation file.
            string outputDirectory = @"C:\Data\Output";

            // Full path for the self‑extracting archive.
            string sfxPath = Path.Combine(outputDirectory, "MyArchive.exe");

            // Full path for the invocation file containing runtime switches.
            string invocationFilePath = Path.Combine(outputDirectory, "RunSfx.txt");

            // Validate input directory.
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));

            // Create a new ZIP archive.
            using (Archive archive = new Archive())
            {
                // Add all files from the input directory (including subfolders).
                archive.CreateEntries(new DirectoryInfo(inputDirectory));

                // Configure self‑extractor options.
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the archive as a self‑extracting executable.
                archive.Save(sfxPath, saveOptions);
            }

            // Write the invocation file with the required switches.
            using (StreamWriter writer = new StreamWriter(invocationFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine("-autoExtract");
                writer.WriteLine("-autoClose");
            }

            Console.WriteLine("Self‑extracting archive and invocation file created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of documents as a single executable that extracts itself automatically on the target machine without requiring a separate unzip tool.
 * 2. When you want to embed runtime switches such as -autoExtract and -autoClose in a separate invocation file to control the self‑extracting archive’s behavior at launch.
 * 3. When you must package files from a directory, including subfolders, into a self‑extracting archive for easy deployment in environments with limited user permissions.
 * 4. When you need to generate the SFX executable programmatically in a .NET application using Aspose.Zip without manually invoking external compression utilities.
 * 5. When you want to automate the creation of a self‑extracting installer that can be run silently by reading switches from a text file in enterprise software distribution.
 */
