// HOW-TO: Extract Encrypted Zip From Pipe Stream With Password In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.IO.Pipes;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path and output directory
            string inputPath = "encrypted.zip";
            string outputDirectory = "ExtractedFiles";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the encrypted ZIP file and pipe its contents
            using (FileStream fileStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (AnonymousPipeServerStream pipeServer = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable))
            using (AnonymousPipeClientStream pipeClient = new AnonymousPipeClientStream(PipeDirection.In, pipeServer.GetClientHandleAsString()))
            {
                // Transfer ZIP data to the pipe
                fileStream.CopyTo(pipeServer);
                pipeServer.Flush();
                pipeServer.DisposeLocalCopyOfClientHandle();
                pipeServer.Close(); // Signal end of stream

                // Load the archive from the pipe in forward‑only mode with password
                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                loadOptions.DecryptionPassword = "Secret123";
                loadOptions.ForwardOnly = true;

                using (Archive archive = new Archive(pipeClient, loadOptions))
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to extract password‑protected zip files received over an inter‑process pipe without loading the entire archive into memory.
 * 2. When a .NET service must process encrypted zip archives streamed from another process in forward‑only mode for low‑memory extraction.
 * 3. When you want to securely transfer a zip file between applications using anonymous pipes and automatically decrypt it during extraction.
 * 4. When building a pipeline that reads compressed data from a file, pipes it to a consumer, and extracts its contents to a directory with a known password.
 * 5. When you have to extract all files from an encrypted archive in a single pass while preserving the original folder structure in C#.
 */
