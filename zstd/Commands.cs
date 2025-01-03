using System.Diagnostics.CodeAnalysis;
using ZstdSharp;

namespace zstd;

[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Non-static public members required for source generator.")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "For some reason, Visual Studio is not recognizing above suppression as required.")]
public class Commands
{
    /// <summary>
    /// Compress a file using Zstandard.
    /// </summary>
    /// <param name="fin">The input file.</param>
    /// <param name="fout">The output file, if not specified, the input file with a .zst extension will be used.</param>
    /// <param name="level">The compression level, from 1 to 22, default is 3.</param>
    public async Task Compress(string fin, string fout = "", int level = 3)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fin, nameof(fin));
        ArgumentOutOfRangeException.ThrowIfLessThan(level, 1, nameof(level));
        ArgumentOutOfRangeException.ThrowIfGreaterThan(level, 22, nameof(level));
        if (string.IsNullOrEmpty(fout))
        {
            fout = $"{fin}.zst";
        }
        await using FileStream input = File.OpenRead(fin);
        await using FileStream output = File.Create(fout);
        await using CompressionStream compressionStream = new(output, level);
        await input.CopyToAsync(compressionStream);
    }

    /// <summary>
    /// Decompress a file using Zstandard.
    /// </summary>
    /// <param name="fin">The input file.</param>
    /// <param name="fout">The output file, if not specified, the input file without the .zst extension will be used.</param>
    public async Task Decompress(string fin, string fout = "")
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fin, nameof(fin));
        if (string.IsNullOrEmpty(fout))
        {
            fout = Path.GetFileNameWithoutExtension(fin);
        }
        await using FileStream input = File.OpenRead(fin);
        await using FileStream output = File.Create(fout);
        await using DecompressionStream decompressionStream = new(input);
        await decompressionStream.CopyToAsync(output);
    }
}
