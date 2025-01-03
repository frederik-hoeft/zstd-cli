using ConsoleAppFramework;
using zstd;

ConsoleApp.ConsoleAppBuilder app = ConsoleApp.Create();
app.Add<Commands>();
await app.RunAsync(args);