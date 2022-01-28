using dotnetCampus.AppHosting.Utils;
using dotnetCampus.MSBuildUtils;

namespace dotnetCampus.AppHosting.Tasks;

internal class AppHostPatcher
{
    private readonly FileInfo _appHostExeFile;
    private readonly string _placeholder;
    private readonly string _placeholderName;

    public AppHostPatcher(string appHostExeFilePath, string placeholder, string placeholderName)
    {
        if (string.IsNullOrWhiteSpace(appHostExeFilePath))
        {
            throw new ArgumentException($"“{nameof(appHostExeFilePath)}”不能为 null 或空白。", nameof(appHostExeFilePath));
        }

        if (string.IsNullOrWhiteSpace(placeholder))
        {
            throw new ArgumentException($"“{nameof(placeholder)}”不能为 null 或空白。", nameof(placeholder));
        }

        if (string.IsNullOrWhiteSpace(placeholderName))
        {
            throw new ArgumentException($"“{nameof(placeholderName)}”不能为 null 或空白。", nameof(placeholderName));
        }

        _appHostExeFile = new FileInfo(appHostExeFilePath);
        _placeholder = placeholder;
        _placeholderName = placeholderName;
    }

    public void Patch(string dotnetRootPath)
    {
        if (string.IsNullOrWhiteSpace(dotnetRootPath))
        {
            throw new ArgumentException($"“{nameof(dotnetRootPath)}”不能为 null 或空白。", nameof(dotnetRootPath));
        }

        if (!File.Exists(_appHostExeFile.FullName))
        {
            throw new MSBuildException(new MSBuildMessage($"指定的 AppHost 文件路径不存在。路径：“{_appHostExeFile.FullName}”。"));
        }

        var (patternSequence, valueSequence) = VerifyPlaceholder(dotnetRootPath);

        PatchCore(_appHostExeFile, patternSequence, valueSequence);
    }

    private void PatchCore(FileInfo appHostExeFile, byte[] oldBytes, byte[] newBytes)
    {
        using var fs = appHostExeFile.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
        if (fs.TryMoveToBytes(oldBytes))
        {
            fs.Write(newBytes);
            fs.WriteByte(0);
        }
        else
        {
            throw new MSBuildException(new MSBuildMessage($"无法在 AppHost “{_appHostExeFile.FullName}” 中找到 {_placeholderName} 的序列 {_placeholder}。这应该是 {typeof(Program).Namespace} 的 bug，传入了错误的 AppHost 路径。"));
        }
    }

    private (byte[] placeholder, byte[] value) VerifyPlaceholder(string value)
    {
        // 这里有 1024 个 byte 空间用来容纳占位符。
        // 详情请看 dotnet runtime\src\installer\corehost\corehost.cpp 的注释。
        const int maxPathBytes = 1024;
        var placeholderBytes = Encoding.UTF8.GetBytes(_placeholder);
        var length = placeholderBytes.Length;
        return (length <= maxPathBytes
            ? placeholderBytes
            : throw new MSBuildException(new MSBuildMessage($"设置的 {_placeholderName} 的值 {value} 超出允许设置的 1024 个 UTF8 字节数上限。请减少字符个数，可以考虑用相对路径替代绝对路径。")),
            Encoding.UTF8.GetBytes(value));
    }
}
