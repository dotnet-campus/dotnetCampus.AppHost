#if !NET8_0
internal static class Program
{
    private static void Main()
    {
    }
}
#else
using dotnetCampus.AppHosting.Tasks;
using dotnetCampus.Cli;
using dotnetCampus.MSBuildUtils;

try
{
    var options = CommandLine.Parse(args)
        .AddHandler<AppHostPatchingTask>(o => o.Run())
        .Run();
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
#endif
