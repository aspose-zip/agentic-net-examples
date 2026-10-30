// HOW-TO: Create HTML Report of ARJ Archive Metadata Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample.arj";
            string outputPath = "output\\archive.html";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                string fileName = Path.GetFileName(inputPath);
                string comment = string.Empty;

                string html = "<html><head><title>" + fileName + "</title></head>" +
                              "<body><h1>" + fileName + "</h1>" +
                              "<p>" + comment + "</p></body></html>";

                File.WriteAllText(outputPath, html);
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
 * 1. When you need to generate a quick web‑page summary of an ARJ file’s name and comment for documentation or audit purposes.
 * 2. When a legacy system produces ARJ archives and you want to display their basic information in a browser without extracting the contents.
 * 3. When you are building a monitoring tool that lists archived files and you need to render the archive details as HTML for end‑users.
 * 4. When you want to automate the creation of an index page that shows the filenames of ARJ archives stored on a server.
 * 5. When you are creating a searchable catalog of compressed archives and require a simple HTML snippet that includes the archive’s metadata.
 */
