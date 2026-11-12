// HOW-TO: Create SHAR Archive With Multiple Shell Scripts Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path for the SHAR archive (actually a ZIP archive with .shar extension)
            string outputPath = "scripts_collection.shar";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create the archive
            using (Archive archive = new Archive())
            {
                // Script A content
                string scriptA = "#!/bin/sh\n" +
                                 "echo \"Running script A\"\n";
                using (MemoryStream msA = new MemoryStream(Encoding.UTF8.GetBytes(scriptA)))
                {
                    archive.CreateEntry("script_a.sh", msA);
                }

                // Script B content
                string scriptB = "#!/bin/sh\n" +
                                 "echo \"Running script B\"\n";
                using (MemoryStream msB = new MemoryStream(Encoding.UTF8.GetBytes(scriptB)))
                {
                    archive.CreateEntry("script_b.sh", msB);
                }

                // Script C content
                string scriptC = "#!/bin/sh\n" +
                                 "echo \"Running script C\"\n";
                using (MemoryStream msC = new MemoryStream(Encoding.UTF8.GetBytes(scriptC)))
                {
                    archive.CreateEntry("script_c.sh", msC);
                }

                // Save the archive to the specified path
                archive.Save(outputPath);
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
 * 1. When you need to package several .sh scripts into a single distributable file for Linux deployment using C#.
 * 2. When automating the creation of a custom .shar (zip) archive as part of a build pipeline that bundles shell utilities.
 * 3. When delivering a set of startup scripts to remote servers and want to compress them into one archive programmatically.
 * 4. When integrating Aspose.Zip in a .NET application to generate archives with a non‑standard .shar extension for legacy tools.
 * 5. When you want to create a portable script collection that can be extracted on any platform without manual zipping.
 */
