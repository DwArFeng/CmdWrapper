# CmdWrapper

CmdWrapper 是一个十分简单的可执行程序，使用者可以通过它执行一个 bat 脚本。

CmdWrapper 在执行脚本时，会使用静默模式执行，即不会弹出 cmd 窗口。

## 编译方法

CmdWrapper 使用 Visual Studio 2022 编写，可以使用 Visual Studio 2022 打开 CmdWrapper.sln，然后编译即可。

Tips: 可以使用 Publish 功能将 CmdWrapper 发布为单个可执行文件，并且可以选择发布为 x86 或 x64 版本。

## 使用方法

CmdWrapper.exe 接受至少一个参数，即要执行的 bat 脚本的路径。如果 bat 脚本需要参数，可以在后面添加。

例如：

```batch
CmdWrapper.exe "C:\path\to\your\script.bat" arg1 arg2
```