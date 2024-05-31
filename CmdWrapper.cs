using System.Diagnostics;

namespace CmdWrapper
{
    public static class CmdWrapper
    {
        private static void Main(string[] args)
        {
            try {
                // 如果参数个数小于 1，以内部错误的方式退出程序。
                if (args.Length < 1)
                {
                    Console.WriteLine("Internal error.");
                    Environment.Exit(1);
                }

                // 创建一个新的ProcessStartInfo对象。
                ProcessStartInfo startInfo = new ProcessStartInfo();

                // 获取第 0 个参数，作为要启动的程序的路径。
                startInfo.FileName = args[0];

                // 循环 args， 为每个 arg 添加一对双引号，arg 之间添加空格。
                // 从第一个参数循环至 args 结尾，为每个 args 添加一对双引号，arg 之间添加空格，作为命令行参数。
                bool firstArg = true;
                string arguments = "";
                for (int i = 1; i < args.Length; i++)
                {
                    string arg = args[i];
                    arg = arg.Trim();
                    arg = "\"" + arg + "\"";
                    if (firstArg)
                    {
                        firstArg = false;
                    }
                    else
                    {
                        arguments += " ";
                    }
                    arguments += arg;
                }

                // 添加命令行参数。
                startInfo.Arguments = arguments;

                // 不使用操作系统外壳程序启动。
                startInfo.UseShellExecute = false;

                // 不创建新窗口。
                startInfo.CreateNoWindow = true;

                // 启动进程。
                using Process? process = Process.Start(startInfo);

                // 如果进程为 null，以内部错误的方式退出程序。
                if (process == null)
                {
                    Console.WriteLine("Internal error.");
                    Environment.Exit(1);
                }

                // 等待程序执行完成。
                process.WaitForExit();

                // 获取退出代码。
                int exitCode = process.ExitCode;

                // 以 exitCode 退出程序。
                Environment.Exit(exitCode);
            }
            catch (Exception)
            {
                // 以内部错误的方式退出程序。
                Console.WriteLine("Internal error.");
                Environment.Exit(1);
            }
        }
    }
}