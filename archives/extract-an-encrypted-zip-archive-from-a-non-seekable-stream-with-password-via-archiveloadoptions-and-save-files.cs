// HOW-TO: Extract Encrypted ZIP From Non‑Seekable Stream With Password In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    // Simple wrapper that disables seeking on an underlying stream.
    private sealed class NonSeekableStream : Stream
    {
        private readonly Stream _baseStream;

        public NonSeekableStream(Stream baseStream)
        {
            _baseStream = baseStream ?? throw new ArgumentNullException(nameof(baseStream));
        }

        public override bool CanRead => _baseStream.CanRead;
        public override bool CanSeek => false;
        public override bool CanWrite => _baseStream.CanWrite;
        public override long Length => throw new NotSupportedException();

        public override long Position
        {
            get => throw new NotSupportedException();
            set => throw new NotSupportedException();
        }

        public override void Flush()
        {
            _baseStream.Flush();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _baseStream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            _baseStream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            _baseStream.Write(buffer, offset, count);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _baseStream.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input ZIP path and output directory.
            string inputPath = "encrypted.zip";
            string outputDirectory = "extracted";

            // Validate input file existence.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputDirectory);

            // Open the input file as a non‑seekable stream.
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (NonSeekableStream nonSeekable = new NonSeekableStream(fileStream))
            {
                // Set the password for the encrypted archive.
                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
                {
                    DecryptionPassword = "MySecretPassword"
                };

                // Load the archive from the non‑seekable stream.
                using (Archive archive = new Archive(nonSeekable, loadOptions))
                {
                    // Extract all entries to the output directory.
                    archive.ExtractToDirectory(outputDirectory);
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a C# application receives a password‑protected ZIP over a network socket that does not support seeking, this code can decrypt and extract its contents directly.
 * 2. When processing large encrypted backup files streamed from cloud storage APIs that provide only forward‑only streams, developers can use this pattern to unpack the data without loading the whole archive into memory.
 * 3. When integrating with legacy systems that output encrypted ZIP archives via HTTP responses or pipes, the non‑seekable wrapper enables seamless extraction in a .NET service.
 * 4. When building a file‑upload service that validates and extracts user‑submitted encrypted ZIP files streamed from a web request, this approach ensures the password is applied and files are saved to disk.
 * 5. When automating the extraction of confidential documents from encrypted ZIP archives stored in a message queue payload, the code allows decryption and extraction without requiring a temporary seekable file.
 */
