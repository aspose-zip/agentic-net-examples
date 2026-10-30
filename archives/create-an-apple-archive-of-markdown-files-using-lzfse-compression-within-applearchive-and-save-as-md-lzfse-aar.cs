// HOW-TO: Create Zip Archive of Multiple Markdown Files with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath1 = "Data\\doc1.md";
            string inputPath2 = "Data\\doc2.md";

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

            string outputPath = "md_archive.zip";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream zipFile = File.Open(outputPath, FileMode.Create, FileAccess.Write))
            {
                using (FileStream source1 = File.OpenRead(inputPath1))
                {
                    using (FileStream source2 = File.OpenRead(inputPath2))
                    {
                        using (Archive archive = new Archive())
                        {
                            archive.CreateEntry("doc1.md", source1);
                            archive.CreateEntry("doc2.md", source2);

                            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                            saveOptions.Encoding = Encoding.ASCII;
                            saveOptions.ArchiveComment = "Multiple markdown files";

                            archive.Save(zipFile, saveOptions);
                        }
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
 * 1. When you need to bundle several documentation markdown files into a single compressed zip archive for easy distribution using Aspose.Zip in C#.
 * 2. When an automated build script must generate a portable zip package of generated .md reports to upload to a documentation portal.
 * 3. When a desktop application stores user‑created notes as markdown and wants to back them up as a single zip file via C# code.
 * 4. When a CI/CD pipeline has to archive source‑code README files into a zip before publishing them as release assets.
 * 5. When a web service provides downloadable content bundles and must create the zip on the fly from in‑memory markdown streams using Aspose.Zip.
 */
