// HOW-TO: Extract All Files From Non Seekable ZIP Stream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class NonSeekableStream : Stream
{
    private readonly Stream _baseStream;

    public NonSeekableStream(Stream baseStream)
    {
        _baseStream = baseStream;
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
        throw new NotSupportedException();
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.zip";
            string outputPath = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream fileStream = File.OpenRead(inputPath))
            using (NonSeekableStream nonSeekable = new NonSeekableStream(fileStream))
            using (Archive archive = new Archive(nonSeekable))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When processing a ZIP file received over a network socket that does not support seeking, you can extract every entry directly to a local folder using forward‑only mode.
 * 2. When reading a large ZIP archive from a cloud storage API that streams data, this code lets you unpack all files without loading the entire archive into memory.
 * 3. When working with a ZIP file embedded in a custom protocol where the underlying stream is read‑only and non‑seekable, you can still extract its contents to a directory.
 * 4. When building a command‑line tool that extracts archives from stdin (piped input), the non‑seekable stream wrapper enables extraction without requiring temporary files.
 * 5. When integrating Aspose.Zip into a web service that receives compressed uploads as streams, this approach allows you to decompress and save each entry on the server efficiently.
 */
