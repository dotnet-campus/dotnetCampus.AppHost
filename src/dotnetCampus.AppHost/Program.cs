#if !IS_EXE_TOOL
using System;

internal static class Program
{
    private static void Main()
    {
        throw new NotSupportedException("不支持 .NET 8.0 以下的版本。通常是 NuGet 包制作错误，如看到此异常，请到 https://github.com/dotnet-campus/dotnetCampus.AppHost 提 Issues");
    }
}
#else
using System;
using dotnetCampus.AppHosting.Tasks;
using dotnetCampus.Cli;
using dotnetCampus.MSBuildUtils;

try
{
    Console.WriteLine(new MSBuildMessage($"开始执行 dotnet campus AppHost 替换工作。命令行参数：{Environment.CommandLine}").ToString(MessageLevel.Message));

    var options = CommandLine.Parse(args)
        .AddHandler<AppHostPatchingTask>(o => o.Run())
        .Run();

    Console.WriteLine(new MSBuildMessage("完成 dotnet campus AppHost 替换工作").ToString(MessageLevel.Message));
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
