using dotnetCampus.Cli;

namespace dotnetCampus.AppHosting;

internal class Options
{
    private string? _appHostExePath;

    [Value(0, Description = "AppHost.exe 的路径。")]
    [Option('a', "Apphost", Description = "AppHost.exe 的路径。")]
    public string AppHostExePath
    {
        get => _appHostExePath ?? throw new ArgumentException($"{nameof(AppHostExePath)} 未初始化。", nameof(AppHostExePath));
        set => _appHostExePath = value ?? throw new ArgumentNullException(nameof(AppHostExePath));
    }

    [Option('d', "AppHostDotnetRoot", Description = ".NET 运行时（DOTNET_ROOT）的路径。")]
    public string? DCAppHostDotnetRoot { get; set; }
}
