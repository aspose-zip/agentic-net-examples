// HOW-TO: Create Uncompressed TAR Archive from Multiple Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "file1.txt";
            string inputPath2 = "file2.txt";

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

            string outputPath = "output/output.tar";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TarArchive tar = new TarArchive())
            {
                tar.CreateEntry(inputPath1, Path.GetFileName(inputPath1));
                tar.CreateEntry(inputPath2, Path.GetFileName(inputPath2));

                tar.Save(outputPath);
            }

            Console.WriteLine($"TAR archive created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle log files into an uncompressed TAR archive for easy transfer to a Linux server.
 * 2. When you want to generate a TAR package of configuration files for backup before deployment.
 * 3. When an application must create a POSIX‑compatible archive that third‑party tools can read without requiring compression.
 * 4. When you need to combine several text reports into a single TAR file for email attachment without increasing file size.
 * 5. When automating a build pipeline that packages source files into a TAR archive for distribution to Unix‑based environments.
 */
