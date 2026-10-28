// HOW-TO: Create HTML Gallery of Images Extracted from ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.zip";
            string outputHtmlPath = "output\\images.html";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));

            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html><head><meta charset=\"UTF-8\"><title>Extracted Images</title></head><body>");

            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                        if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif")
                        {
                            using (MemoryStream memory = new MemoryStream())
                            {
                                using (Stream entryStream = entry.Open())
                                {
                                    entryStream.CopyTo(memory);
                                }

                                byte[] imageBytes = memory.ToArray();
                                string base64 = Convert.ToBase64String(imageBytes);
                                string mime = extension == ".png" ? "image/png" :
                                              extension == ".gif" ? "image/gif" :
                                              "image/jpeg";

                                htmlBuilder.AppendLine($"<img src=\"data:{mime};base64,{base64}\" alt=\"{entry.Name}\" />");
                            }
                        }
                    }
                }
            }

            htmlBuilder.AppendLine("</body></html>");

            File.WriteAllText(outputHtmlPath, htmlBuilder.ToString(), Encoding.UTF8);
            Console.WriteLine($"HTML file generated at: {outputHtmlPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed all pictures from a ZIP file directly into a single HTML page without writing separate image files.
 * 2. When generating a preview report that shows extracted PNG, JPEG, or GIF images from an archive in a web‑friendly format.
 * 3. When creating an email‑ready HTML document that includes images from a compressed package using data URIs to avoid external attachments.
 * 4. When building a documentation tool that visualizes assets stored in a ZIP archive without extracting them to the file system.
 * 5. When automating a CI pipeline that validates image contents of a ZIP by rendering them in an HTML summary for quick review.
 */
