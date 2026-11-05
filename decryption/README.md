# Decryption of Encrypted ZIP Archives in C# with Aspose.ZIP  

A set of ready‑to‑run C# examples that show how to **decrypt** ZIP files using Aspose.ZIP for .NET. The code demonstrates decrypting AES‑128 protected archives, extracting only selected files, renaming extracted entries with an archive‑name prefix, and handling per‑entry passwords. Aspose.ZIP is a UI‑agnostic backend API that works in ASP.NET Core, console apps, Azure Functions, Docker containers, and any .NET 9+ environment without UI dependencies.

## What You Can Do  

- **Decrypt an AES‑128 encrypted ZIP and extract all files** to a target folder.  
- **Decrypt an AES‑128 encrypted ZIP and extract only files that match a given pattern** (e.g., `*.txt`).  
- **Decrypt an AES‑128 encrypted ZIP and rename each extracted file** by adding the archive name as a prefix.  
- **Extract all files from an AES‑128 encrypted ZIP using a single password**.  
- **Iterate over entries that use different passwords**, applying the correct password per entry while extracting.

## Quick Start  

```csharp
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main()
    {
        // Paths and password – adjust to your environment
        string zipPath   = "encrypted.zip";
        string outFolder = "Extracted";
        string password  = "MySecretPassword";

        if (!File.Exists(zipPath))
        {
            Console.Error.WriteLine($"File not found: {zipPath}");
            return;
        }

        // Open the encrypted archive
        using (ZipArchive archive = new ZipArchive(zipPath, password))
        {
            // Extract every entry to the output folder
            archive.ExtractAll(outFolder);
        }

        Console.WriteLine($"Decryption and extraction completed: {outFolder}");
    }
}
```

The snippet above covers the most common scenario—decrypting an AES‑128 protected ZIP and extracting its entire contents.

## Requirements  

- **.NET 9+**  
- **Aspose.Zip** NuGet package  

```bash
dotnet add package Aspose.Zip
```

## Resources  

| Resource | Link |
|----------|------|
| Documentation | https://docs.aspose.com/zip/net/ |
| NuGet | https://www.nuget.org/packages/Aspose.Zip |
| Release Notes | https://releases.aspose.com/zip/net/ |
| Online Apps | https://products.aspose.app/zip/family/ |

## Files

Examples and tasks in this folder:

| Example |
|---------|
| [after-successful-decryption-rename-extracted-files-with-a-prefix-indicating-the-archive-name-and-save-them.cs](./after-successful-decryption-rename-extracted-files-with-a-prefix-indicating-the-archive-name-and-save-them.cs) |
| [create-a-checksum-sha256-file-for-each-extracted-file-after-successful-decryption.cs](./create-a-checksum-sha256-file-for-each-extracted-file-after-successful-decryption.cs) |
| [decrypt-a-password-protected-zip-with-the-caller-supplied-password-recreate-its-entries-in-a-new-archive-without.cs](./decrypt-a-password-protected-zip-with-the-caller-supplied-password-recreate-its-entries-in-a-new-archive-without.cs) |
| [decrypt-a-zip-archive-encrypted-with-aes128-and-extract-only-files-matching-a-given-pattern-to-a-folder.cs](./decrypt-a-zip-archive-encrypted-with-aes128-and-extract-only-files-matching-a-given-pattern-to-a-folder.cs) |
| [decrypt-a-zip-archive-encrypted-with-aes256-and-extract-its-contents-to-a-user-specified-output-location.cs](./decrypt-a-zip-archive-encrypted-with-aes256-and-extract-its-contents-to-a-user-specified-output-location.cs) |
| [decrypt-and-extract-a-zip-archive-containing-both-stored-uncompressed-entries-and-aes-encrypted-entries-to-an.cs](./decrypt-and-extract-a-zip-archive-containing-both-stored-uncompressed-entries-and-aes-encrypted-entries-to-an.cs) |
| [decrypt-and-extract-contents-of-an-aes128-encrypted-zip-archive-to-a-new-directory-on-disk.cs](./decrypt-and-extract-contents-of-an-aes128-encrypted-zip-archive-to-a-new-directory-on-disk.cs) |
| [extract-a-zip-archive-containing-encrypted-entries-by-supplying-the-correct-password-for-each-entry.cs](./extract-a-zip-archive-containing-encrypted-entries-by-supplying-the-correct-password-for-each-entry.cs) |
| [extract-all-files-from-a-zip-archive-encrypted-with-a-traditional-password-into-a-specified-output-folder.cs](./extract-all-files-from-a-zip-archive-encrypted-with-a-traditional-password-into-a-specified-output-folder.cs) |
| [extract-all-files-from-a-zip-archive-encrypted-with-aes128-using-the-password-and-save-to-output-folder.cs](./extract-all-files-from-a-zip-archive-encrypted-with-aes128-using-the-password-and-save-to-output-folder.cs) |
| [extract-an-archive-that-contains-entries-protected-with-different-passwords-by-supplying-each-password-during.cs](./extract-an-archive-that-contains-entries-protected-with-different-passwords-by-supplying-each-password-during.cs) |
| [extract-an-archive-with-multiple-encrypted-entries-supplying-the-appropriate-password-for-each-entry-as-needed.cs](./extract-an-archive-with-multiple-encrypted-entries-supplying-the-appropriate-password-for-each-entry-as-needed.cs) |
| [extract-archives-that-use-different-entry-passwords-by-iterating-over-entries-and-applying-each-password.cs](./extract-archives-that-use-different-entry-passwords-by-iterating-over-entries-and-applying-each-password.cs) |
| [extract-files-from-a-stored-uncompressed-encrypted-zip-archive-using-the-correct-password-and-save-them.cs](./extract-files-from-a-stored-uncompressed-encrypted-zip-archive-using-the-correct-password-and-save-them.cs) |
| [extract-only-the-encrypted-entries-from-a-zip-archive-that-contains-both-encrypted-and-unencrypted-files.cs](./extract-only-the-encrypted-entries-from-a-zip-archive-that-contains-both-encrypted-and-unencrypted-files.cs) |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53659.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53659.cs) |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53660.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53660.cs) |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53664.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53664.cs) |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53676.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53676.cs) |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53680.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle-53680.cs) |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-after-unlocking-an.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-after-unlocking-an.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-apply-password-53674.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-apply-password-53674.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-apply-password.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-apply-password.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-iterate-candidate.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-iterate-candidate.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-load-all-segments-of.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-load-all-segments-of.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-load-an-encrypted-zip-53671.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-load-an-encrypted-zip-53671.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-load-an-encrypted-zip.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-load-an-encrypted-zip.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-open-encrypted-zip.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-open-encrypted-zip.cs) |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-perform-password.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-perform-password.cs) |
[**View all 45 examples →**](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/decryption)