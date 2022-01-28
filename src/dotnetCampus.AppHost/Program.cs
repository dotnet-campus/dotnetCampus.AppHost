#if !NET6_0
internal static class Program
{
    private static void Main()
    {
    }
}
#else
using dotnetCampus.AppHosting;
using dotnetCampus.AppHosting.Tasks;
using dotnetCampus.Cli;
using dotnetCampus.MSBuildUtils;

try
{
    var options = CommandLine.Parse(args).As<Options>();
    Run(options);
}
catch (MSBuildException ex)
{
    ex.MSBuildMessage.Error();
}
catch (Exception ex)
{
    Console.WriteLine($@"设置 AppHost 的 DOTNET_ROOT 时出现未知错误：{ex.Message}
{ex}");
}

static void Run(Options options)
{
    const string dotnetCampusBuildedAppHostDotnetRootPlaceholder = "622e5d2d0f48bd3448f713291ed3f86df2f05ca222e95084f222207c5c348eea";
    var patcher = new AppHostPatcher(options.AppHostExePath, dotnetCampusBuildedAppHostDotnetRootPlaceholder, "DCAppHostDotnetRoot");
    if (options.DCAppHostDotnetRoot is { } dotnetRoot)
    {
        patcher.Patch(dotnetRoot);
    }
    else
    {
        throw new InvalidOperationException($"当未设置 {nameof(Options.DCAppHostDotnetRoot)} 时不应该调用此程序修改 AppHost。");
    }
}
#endif
