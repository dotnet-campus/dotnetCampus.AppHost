# dotnetCampus.AppHost

| Build | NuGet |
|--|--|
|![](https://github.com/dotnet-campus/dotnetCampus.AppHost/workflows/.NET%20Build/badge.svg)|[![](https://img.shields.io/nuget/v/dotnetCampus.AppHost.svg)](https://www.nuget.org/packages/dotnetCampus.AppHost)|

Starting with .NET 9, the official team has introduced the `AppHostRelativeDotNet` mechanism, which fully encompasses all the functionality provided by this library. For more details, please refer to: https://github.com/dotnet/runtime/issues/64430

After upgrading to .NET 9, you can modify your `.csproj` file as shown in the example below to enable support for locating the .NET runtime via relative paths:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <AppHostDotNetSearch>AppRelative;Global;</AppHostDotNetSearch>
    <AppHostRelativeDotNet>../relative/path/to/runtime</AppHostRelativeDotNet>
  </PropertyGroup>

</Project>
```

**Note:** After publishing your application, you will need to place the .NET runtime files in a folder located at `../relative/path/to/runtime`. You can extract these runtime files from the .NET SDK, locate them in your NuGet package cache, or download and unzip the runtime files from the official .NET website.

Since all features of this repository have been integrated into .NET 9, this repository will be archived.

---

在 dotnet 9 时，官方已经添加了 AppHostRelativeDotNet 机制，完全包含了本库提供的所有功能。详细请参阅：https://github.com/dotnet/runtime/issues/64430

更新到 .NET 9 之后，可更改 csproj 代码为如下示例内容，从而获取寻找相对路径的 dotnet runtime 能力

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net9.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
    <AppHostDotNetSearch>AppRelative;Global;</AppHostDotNetSearch>
    <AppHostRelativeDotNet>../relative/path/to/runtime</AppHostRelativeDotNet>
  </PropertyGroup>

</Project>
```

注： 你需要在发布之后，在相对路径为 `../relative/path/to/runtime` 的文件夹里放入 dotnet runtime 的文件。你可以从 dotnet SDK 里面提取 dotnet runtime 的文件，或者从你的 NuGet 包缓存里面查找，或者从 dotnet 官方下载运行时 zip 包解压缩

详细请参阅 [dotnet 9 通过 AppHostRelativeDotNet 指定自定义的运行时路径](https://blog.lindexi.com/post/dotnet-9-%E9%80%9A%E8%BF%87-AppHostRelativeDotNet-%E6%8C%87%E5%AE%9A%E8%87%AA%E5%AE%9A%E4%B9%89%E7%9A%84%E8%BF%90%E8%A1%8C%E6%97%B6%E8%B7%AF%E5%BE%84.html )

由于本代码仓库所有功能已经被 .NET 9 引入，本仓库将归档