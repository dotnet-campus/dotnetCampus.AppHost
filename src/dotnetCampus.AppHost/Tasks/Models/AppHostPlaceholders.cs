namespace dotnetCampus.AppHosting.Tasks.Models;

internal static class AppHostPlaceholders
{
    /// <summary>
    /// <see cref="DotNetRoot"/> 的 MSBuild 属性名。
    /// </summary>
    public const string DotNetRootName = "AppHostDotNetRoot";

    /// <summary>
    /// 占位符，代表 AppHost 在编译后将使用的 .NET 运行时路径。
    /// </summary>
    public const string DotNetRoot = "622e5d2d0f48bd3448f713291ed3f86df2f05ca222e95084f222207c5c348eea";

    /// <summary>
    /// <see cref="HostMissingMessage"/> 的 MSBuild 属性名。
    /// </summary>
    public const string HostMissingMessageName = "AppHostCoreLibMissingDialogMessage";

    /// <summary>
    /// 占位符，代表 AppHost 无法找到 .NET 运行时后弹出的错误框中的文案。
    /// </summary>
    public const string HostMissingMessage = "a9259edaaad4b93446260c2986103cda9314b67e35e77149d3f84415c7ce86e3";

    /// <summary>
    /// <see cref="HostMissingUrl"/> 的 MSBuild 属性名。
    /// </summary>
    public const string HostMissingUrlName = "AppHostCoreLibMissingDialogUrl";

    /// <summary>
    /// 占位符，代表 AppHost 无法找到 .NET 运行时后在弹出的错误框中点“是”将跳转的 URL。
    /// </summary>
    public const string HostMissingUrl = "f9d4d2616fb661f40841679b3cd42136faa2585546e66955111e297c764ff0a3";

    /// <summary>
    /// <see cref="NeedPrereqsMessage"/> 的 MSBuild 属性名。
    /// </summary>
    public const string NeedPrereqsMessageName = "AppHostNeedSystemPrereqsMessage";

    /// <summary>
    /// 占位符，代表当前系统不支持运行 .NET 应用，需要 KB2533623 补丁。
    /// </summary>
    public const string NeedPrereqsMessage = "008ee4667a30ee16eea1d63122c94db9dea4f5e7a330e123587ce933ce233088";

    /// <summary>
    /// <see cref="NeedPrereqsUrl"/> 的 MSBuild 属性名。
    /// </summary>
    public const string NeedPrereqsUrlName = "AppHostNeedSystemPrereqsUrl";

    /// <summary>
    /// 占位符，代表当前系统不支持运行 .NET 应用，需要 KB2533623 补丁后在弹出的错误框中点“是”将跳转的 URL。
    /// </summary>
    public const string NeedPrereqsUrl = "424b3211aeda8117b73dd2371390518386163528f78f04027968bac88e919aba";
}
