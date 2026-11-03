---
name: decryption
description: C# examples for Decryption using Aspose.ZIP for .NET
language: csharp
framework: net9.0
parent: ../agents.md
---

# AGENTS - Decryption

## Persona

You are a C# developer specializing in archive processing using Aspose.ZIP for .NET,
working within the **Decryption** category.
This folder contains standalone C# examples for Decryption operations.
See the root [agents.md](../agents.md) for repository-wide conventions and boundaries.

## Required Namespaces

- `using System;` (45/38 files)
- `using System.IO;` (45/38 files)
- `using Aspose.Zip;` (45/38 files) ← category-specific
- `using System.Collections.Generic;` (18/38 files)
- `using System.Linq;` (4/38 files)
- `using System.Text;` (4/38 files)
- `using Aspose.Zip.Saving;` (2/38 files) ← category-specific
- `using Aspose.Zip.ArchiveInfo;` (1/38 files) ← category-specific
- `using System.Security.Cryptography;` (1/38 files)

## Files in this folder

| File | Key APIs | Description |
|------|----------|-------------|
| [extract-an-archive-with-multiple-encrypted-entries-supplying-the-appropriate-password-for-each-entry-as-needed.cs](./extract-an-archive-with-multiple-encrypted-entries-supplying-the-appropriate-password-for-each-entry-as-needed.cs) |  | Extract an archive with multiple encrypted entries, supplying the appropriate pa... |
| [extract-a-zip-archive-containing-encrypted-entries-by-supplying-the-correct-password-for-each-entry.cs](./extract-a-zip-archive-containing-encrypted-entries-by-supplying-the-correct-password-for-each-entry.cs) |  | Extract a ZIP archive containing encrypted entries by supplying the correct pass... |
| [extract-an-archive-that-contains-entries-protected-with-different-passwords-by-supplying-each-password-during.cs](./extract-an-archive-that-contains-entries-protected-with-different-passwords-by-supplying-each-password-during.cs) |  | Extract an archive that contains entries protected with different passwords by s... |
| [extract-archives-that-use-different-entry-passwords-by-iterating-over-entries-and-applying-each-password.cs](./extract-archives-that-use-different-entry-passwords-by-iterating-over-entries-and-applying-each-password.cs) |  | Extract archives that use different entry passwords by iterating over entries an... |
| [handle-encrypted-entries-by-providing-the-appropriate-password-while-extracting-files-from-a-zip-archive.cs](./handle-encrypted-entries-by-providing-the-appropriate-password-while-extracting-files-from-a-zip-archive.cs) |  | Handle encrypted entries by providing the appropriate password while extracting ... |
| [handle-encrypted-entries-by-supplying-the-appropriate-password-during-extraction-of-a-zip-archive.cs](./handle-encrypted-entries-by-supplying-the-appropriate-password-during-extraction-of-a-zip-archive.cs) |  | Handle encrypted entries by supplying the appropriate password during extraction... |
| [open-an-encrypted-zip-with-the-caller-supplied-password-decrypt-file-entry-contents-rebuild-a-zip-without.cs](./open-an-encrypted-zip-with-the-caller-supplied-password-decrypt-file-entry-contents-rebuild-a-zip-without.cs) | `ArchiveLoadOptions` | Open an encrypted ZIP with the caller-supplied password, decrypt file-entry cont... |
| [open-an-aes-256-encrypted-zip-with-the-caller-supplied-password-decrypt-its-entries-and-save-their-contents-in-a.cs](./open-an-aes-256-encrypted-zip-with-the-caller-supplied-password-decrypt-its-entries-and-save-their-contents-in-a.cs) | `ArchiveLoadOptions`, `ArchiveSaveOptions` | Open an AES-256 encrypted ZIP with the caller-supplied password, decrypt its ent... |
| [open-a-password-protected-zip-with-the-caller-supplied-password-extract-its-entries-to-memory-and-save-a-newly.cs](./open-a-password-protected-zip-with-the-caller-supplied-password-extract-its-entries-to-memory-and-save-a-newly.cs) | `ArchiveLoadOptions` | Open a password-protected ZIP with the caller-supplied password, extract its ent... |
| [decrypt-a-password-protected-zip-with-the-caller-supplied-password-recreate-its-entries-in-a-new-archive-without.cs](./decrypt-a-password-protected-zip-with-the-caller-supplied-password-recreate-its-entries-in-a-new-archive-without.cs) | `ArchiveLoadOptions`, `ArchiveSaveOptions` | Decrypt a password-protected ZIP with the caller-supplied password, recreate its... |
| [extract-all-files-from-a-zip-archive-encrypted-with-a-traditional-password-into-a-specified-output-folder.cs](./extract-all-files-from-a-zip-archive-encrypted-with-a-traditional-password-into-a-specified-output-folder.cs) | `ArchiveLoadOptions` | Extract all files from a ZIP archive encrypted with a traditional password into ... |
| [decrypt-and-extract-contents-of-an-aes128-encrypted-zip-archive-to-a-new-directory-on-disk.cs](./decrypt-and-extract-contents-of-an-aes128-encrypted-zip-archive-to-a-new-directory-on-disk.cs) | `ArchiveLoadOptions` | Decrypt and extract contents of an AES128‑encrypted ZIP archive to a new directo... |
| [retrieve-a-single-encrypted-file-from-a-stored-uncompressed-aes-encrypted-zip-archive-and-save-it.cs](./retrieve-a-single-encrypted-file-from-a-stored-uncompressed-aes-encrypted-zip-archive-and-save-it.cs) | `ArchiveLoadOptions` | Retrieve a single encrypted file from a stored (uncompressed) AES‑encrypted ZIP ... |
| [decrypt-a-zip-archive-encrypted-with-aes128-and-extract-only-files-matching-a-given-pattern-to-a-folder.cs](./decrypt-a-zip-archive-encrypted-with-aes128-and-extract-only-files-matching-a-given-pattern-to-a-folder.cs) | `ArchiveLoadOptions` | Decrypt a ZIP archive encrypted with AES128 and extract only files matching a gi... |
| [extract-files-from-a-stored-uncompressed-encrypted-zip-archive-using-the-correct-password-and-save-them.cs](./extract-files-from-a-stored-uncompressed-encrypted-zip-archive-using-the-correct-password-and-save-them.cs) | `ArchiveLoadOptions` | Extract files from a stored (uncompressed) encrypted ZIP archive using the corre... |
| [extract-only-the-encrypted-entries-from-a-zip-archive-that-contains-both-encrypted-and-unencrypted-files.cs](./extract-only-the-encrypted-entries-from-a-zip-archive-that-contains-both-encrypted-and-unencrypted-files.cs) |  | Extract only the encrypted entries from a ZIP archive that contains both encrypt... |
| [decrypt-a-zip-archive-encrypted-with-aes256-and-extract-its-contents-to-a-user-specified-output-location.cs](./decrypt-a-zip-archive-encrypted-with-aes256-and-extract-its-contents-to-a-user-specified-output-location.cs) | `ArchiveLoadOptions` | Decrypt a ZIP archive encrypted with AES256 and extract its contents to a user‑s... |
| [extract-all-files-from-a-zip-archive-encrypted-with-aes128-using-the-password-and-save-to-output-folder.cs](./extract-all-files-from-a-zip-archive-encrypted-with-aes128-using-the-password-and-save-to-output-folder.cs) | `ArchiveLoadOptions` | Extract all files from a ZIP archive encrypted with AES128 using the password an... |
| [decrypt-and-extract-a-zip-archive-containing-both-stored-uncompressed-entries-and-aes-encrypted-entries-to-an.cs](./decrypt-and-extract-a-zip-archive-containing-both-stored-uncompressed-entries-and-aes-encrypted-entries-to-an.cs) | `ArchiveLoadOptions` | Decrypt and extract a ZIP archive containing both stored (uncompressed) entries ... |
| [load-an-aes-encrypted-zip-verify-a-known-password-and-save-decrypted-files-to-a-folder.cs](./load-an-aes-encrypted-zip-verify-a-known-password-and-save-decrypted-files-to-a-folder.cs) | `ArchiveLoadOptions` | Load an AES‑encrypted ZIP, verify a known password, and save decrypted files to ... |
| [load-aes-encrypted-zip-verify-known-password-and-save-decrypted-archive-as-a-new-unencrypted-zip-file.cs](./load-aes-encrypted-zip-verify-known-password-and-save-decrypted-archive-as-a-new-unencrypted-zip-file.cs) | `ArchiveLoadOptions` | Load AES‑encrypted ZIP, verify known password, and save decrypted archive as a n... |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-unlock-a-password.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-unlock-a-password.cs) | `ArchiveLoadOptions` | For a user-owned or authorized ZIP, use a finite caller-provided template or can... |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs) | `ArchiveLoadOptions` | For a user-owned or authorized ZIP, try a finite caller-provided password templa... |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs) | `ArchiveLoadOptions` | For a user-owned or authorized ZIP, try a finite caller-provided password templa... |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs) | `ArchiveLoadOptions` | For a user-owned or authorized ZIP, try a finite caller-provided password templa... |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-iterate-candidate.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-iterate-candidate.cs) |  | For a user-owned or authorized ZIP, use a finite caller-provided template or can... |
| [use-archive-class-to-open-encrypted-zip-try-single-password-decryption-and-write-decrypted-content-to-a-folder.cs](./use-archive-class-to-open-encrypted-zip-try-single-password-decryption-and-write-decrypted-content-to-a-folder.cs) | `ArchiveLoadOptions` | Use Archive class to open encrypted ZIP, try single password decryption, and wri... |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-use-archive-class-to.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-use-archive-class-to.cs) | `ArchiveLoadOptions` | For a user-owned or authorized ZIP, use a finite caller-provided template or can... |
| [for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs](./for-a-user-owned-or-authorized-zip-try-a-finite-caller-provided-password-template-or-candidate-list-handle.cs) | `ArchiveLoadOptions` | For a user-owned or authorized ZIP, try a finite caller-provided password templa... |
| [for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-perform-password.cs](./for-a-user-owned-or-authorized-zip-use-a-finite-caller-provided-template-or-candidate-list-perform-password.cs) | `ArchiveLoadOptions` | For a user-owned or authorized ZIP, use a finite caller-provided template or can... |
| *...and 15 more files* | | [View all](https://github.com/aspose-zip/agentic-net-examples/tree/26.11.0/decryption) |

## Category Statistics
- Total examples: 38
- Failed: 0
- Pass rate: 100.0%

## Key API Surface

- `ArchiveLoadOptions`
- `ArchiveSaveOptions`

## Failed Tasks

All tasks passed ✅

<!-- AUTOGENERATED:START -->
Updated: 2026-11-03 | Run: `20261103_134649` | Examples: 38
<!-- AUTOGENERATED:END -->