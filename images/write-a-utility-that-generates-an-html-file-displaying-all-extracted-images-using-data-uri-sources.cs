// HOW-TO: Generate HTML Gallery of Images from ZIP Using Data URIs in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "input.zip";

            // Hardcoded output HTML file path
            string outputHtmlPath = "output\\images.html";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputHtmlPath));

            // List to hold generated <img> tags
            List<string> imageTags = new List<string>();

            // Open the ZIP archive
            using (FileStream zipFile = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipFile))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine file extension
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();

                    // Process only common image formats
                    if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif")
                    {
                        // Read entry data into memory
                        using (Stream entryStream = entry.Open())
                        using (MemoryStream memory = new MemoryStream())
                        {
                            entryStream.CopyTo(memory);
                            byte[] imageData = memory.ToArray();

                            // Convert image bytes to Base64 string
                            string base64 = Convert.ToBase64String(imageData);

                            // Determine MIME type based on extension
                            string mimeType;
                            if (extension == ".png")
                            {
                                mimeType = "image/png";
                            }
                            else if (extension == ".gif")
                            {
                                mimeType = "image/gif";
                            }
                            else
                            {
                                mimeType = "image/jpeg";
                            }

                            // Build the <img> tag with data URI
                            string imgTag = $"<img src=\"data:{mimeType};base64,{base64}\" alt=\"{Path.GetFileName(entry.Name)}\" />";
                            imageTags.Add(imgTag);
                        }
                    }
                }
            }

            // Build the final HTML content
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.AppendLine("<!DOCTYPE html>");
            htmlBuilder.AppendLine("<html>");
            htmlBuilder.AppendLine("<head>");
            htmlBuilder.AppendLine("<meta charset=\"UTF-8\">");
            htmlBuilder.AppendLine("<title>Extracted Images</title>");
            htmlBuilder.AppendLine("</head>");
            htmlBuilder.AppendLine("<body>");
            foreach (string tag in imageTags)
            {
                htmlBuilder.AppendLine(tag);
            }
            htmlBuilder.AppendLine("</body>");
            htmlBuilder.AppendLine("</html>");

            // Write HTML to the output file
            File.WriteAllText(outputHtmlPath, htmlBuilder.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to embed all pictures from a zip archive into a single self‑contained HTML page for quick preview without writing separate image files.
 * 2. When building a web‑based report that must display extracted screenshots stored in a zip without relying on external file paths.
 * 3. When creating an automated email attachment that includes images from a compressed archive as inline data URIs to ensure they render in any email client.
 * 4. When developing a documentation generator that pulls diagrams from a zip package and shows them directly in the generated HTML documentation.
 * 5. When testing image extraction logic by visualizing every image in a zip archive in a browser without extracting to disk.
 */
