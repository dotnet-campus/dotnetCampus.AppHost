using dotnetCampus.Configurations;

namespace dotnetCampus.AppHosting.Tasks.Models;

internal class BuildOptions : Configuration
{
    public BuildOptions() : base(null)
    {
    }

    public FileInfo AppHostFile => new(GetString());

    public string? DotNetRoot => GetString();

    public string? HostMissingMessage => GetString();

    public string? HostMissingUrl => GetString();

    public string? NeedPrereqsMessage => GetString();

    public string? NeedPrereqsUrl => GetString();
}
