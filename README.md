# Zstandard CLI

When searching online for a way to uncompress a `.zst` file on Windows, there were no clear, non-sketchy-looking pre-built binaries available. So instead of diving into the world of non-GitHub, inofficial downloads, I just threw together a few lines of C# code using trusted open-source libraries ([oleg-st/ZstdSharp](https://github.com/oleg-st/ZstdSharp) and [Cysharp/ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework)). Also I wanted to try out [Cysharp/ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework) to see how it compares to `System.CommandLine`, I like the idea of code-generation for argument parsing. Anyways, here's the result:

Compress a file:

```shell
> zstd compress --help
Usage: compress [options...] [-h|--help] [--version]

Compress a file using Zstandard.

Options:
  --fin <string>     The input file. (Required)
  --fout <string>    The output file, if not specified, the input file with a .zst extension will be used. (Default: @"")
  --level <int>      The compression level, from 1 to 22, default is 3. (Default: 3)
```

Decompress a file:

```shell
> zstd decompress --help
Usage: decompress [options...] [-h|--help] [--version]

Decompress a file using Zstandard.

Options:
  --fin <string>     The input file. (Required)
  --fout <string>    The output file, if not specified, the input file without the .zst extension will be used. (Default: @"")
```