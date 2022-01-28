# .NET Runtime 仓库补丁说明

## AppHost.exe 编译方法

### 应用代码补丁

1. 克隆 dotnet/runtime 仓库
2. 切换到文件夹名对应的 Tag（例如切换到 v6.0.1 的 Tag）
3. 在 dotnet/runtime 工作路径下，使用命令应用 git 补丁文件
    * `git am <patch_file>`

### 修改与生成代码补丁

1. 修改并提交代码（建议合并提交，减少补丁个数，以便此仓库里的 Patches 文件夹更易读）
2. 使用命令创建补丁文件
    * `git format-patch <tag>`（此命令会创建当前分支与指定 Tag 之间所有提交的补丁）

### 编译 AppHost

1. 使用这些命令编译各不同版本的 AppHost（完全编译用时大约 15 分钟，但前 2 分钟就可以得到 AppHost 的所有输出文件）
    * x64: `.\build.cmd -a x64 -c Release`
    * x86: `.\build.cmd -a x86 -c Release`
2. 去这些路径找到 AppHost 输出文件
    * x64: `.\artifacts\bin\win-x64.Release\corehost`
    * x86: `.\artifacts\bin\win-x86.Release\corehost`
3. 将找到的输出文件拷贝到本项目的 Assets\template 对应的框架文件夹下
