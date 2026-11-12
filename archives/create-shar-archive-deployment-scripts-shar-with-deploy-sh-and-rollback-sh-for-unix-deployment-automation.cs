// HOW-TO: Create SHAR Archive of Deployment Scripts with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input script files
            string inputPath1 = "deploy.sh";
            string inputPath2 = "rollback.sh";

            // Output SHAR archive
            string outputPath = "deployment_scripts.shar";

            // Validate input files
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

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create archive and add scripts
            using (Archive archive = new Archive())
            {
                using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("deploy.sh", fs1);
                }

                using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry("rollback.sh", fs2);
                }

                // Save as SHAR (extension .shar)
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
 * 1. When you need to bundle multiple Unix deployment scripts into a single SHAR file for easy distribution.
 * 2. When automating release pipelines that require packaging deploy.sh and rollback.sh together before uploading to a server.
 * 3. When you want to ensure the deployment scripts are stored in a portable archive format that preserves file permissions on Unix systems.
 * 4. When integrating Aspose.Zip into a .NET build process to create custom archives without relying on external command‑line tools.
 * 5. When you must programmatically verify the existence of script files and generate a SHAR archive as part of a CI/CD validation step.
 */
