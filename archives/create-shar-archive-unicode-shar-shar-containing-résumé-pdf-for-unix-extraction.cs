// HOW-TO: Create SHAR Archive With Unicode Filename From PDF In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "résumé.pdf";
            string outputPath = "unicode_shar.shar";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // Read the PDF file and encode it to Base64
            byte[] pdfBytes = File.ReadAllBytes(inputPath);
            string base64String = Convert.ToBase64String(pdfBytes);

            // Build the SHAR script content
            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.AppendLine("#!/bin/sh");
            scriptBuilder.AppendLine("# SHAR archive containing résumé.pdf");
            scriptBuilder.AppendLine("base64 -d << 'END_OF_BASE64' > \"résumé.pdf\"");

            int lineLength = 76;
            for (int i = 0; i < base64String.Length; i += lineLength)
            {
                int length = Math.Min(lineLength, base64String.Length - i);
                scriptBuilder.AppendLine(base64String.Substring(i, length));
            }

            scriptBuilder.AppendLine("END_OF_BASE64");
            scriptBuilder.AppendLine("chmod 644 \"résumé.pdf\"");

            // Write the SHAR script to the output file
            File.WriteAllText(outputPath, scriptBuilder.ToString(), Encoding.UTF8);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a PDF with a non‑ASCII name to Unix users via a simple shell script, this code generates a SHAR file that recreates the file on extraction.
 * 2. When automating deployment scripts that must embed binary resources directly in a shell script without external archives, you can use this C# program to embed the PDF as Base64 in a SHAR archive.
 * 3. When building a cross‑platform tool that packages documents for legacy Unix systems lacking modern archive utilities, the code creates a self‑extracting SHAR containing the Unicode‑named PDF.
 * 4. When you want to include a PDF with accented characters in its filename inside a source‑control repository as plain text, this approach converts it to a SHAR script for easy reconstruction.
 * 5. When generating installation packages that need to preserve exact filenames on Unix machines, this snippet creates a SHAR archive that decodes the PDF and sets appropriate permissions during extraction.
 */
