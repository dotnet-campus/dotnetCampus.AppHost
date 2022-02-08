using dotnetCampus.AppHosting.Tasks.Models;
using dotnetCampus.Cli;
using dotnetCampus.Configurations.Core;
using dotnetCampus.MSBuildUtils;

namespace dotnetCampus.EasiPlugins.Tasks.Helpers;

internal abstract class CommandLineTask
{
    [Option("Options")]
    public string? OptionsFilePath { get; set; }

    internal void Run()
    {
        if (OptionsFilePath is { } optionsFilePath && !string.IsNullOrWhiteSpace(optionsFilePath))
        {
            var optionsFile = new FileInfo(optionsFilePath);
            if (optionsFile.Exists)
            {
                var options = ConfigurationFactory.FromFile(optionsFile.FullName).CreateAppConfigurator().Of<BuildOptions>();
                RunCore(options);
            }
            else
            {
                new MSBuildMessage($"无法找到编译属性文件：{optionsFile.FullName}。").Error();
            }
        }
        else
        {
            new MSBuildMessage($"未设置编译属性文件。").Error();
        }
    }

    protected abstract void RunCore(BuildOptions options);
}
