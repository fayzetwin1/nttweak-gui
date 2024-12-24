using System;
using System.Diagnostics;
using System.Text;


// DEPRECATED CLASS!!! 
namespace nttweakExtended.Tweaker;

public class TweakInitializeComponent
{
    public static void ExecuteCommand(string commands)
    {
        if (string.IsNullOrWhiteSpace(commands))
        {
            Console.WriteLine("Нет команд для выполнения.");
            return;
        }

        try
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = $"/c {commands}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = false,
                StandardOutputEncoding = Encoding.UTF8, // Устанавливаем кодировку для стандартного вывода
                StandardErrorEncoding = Encoding.UTF8,  // Устанавливаем кодировку для вывода ошибок
                UseShellExecute = false,
                CreateNoWindow = true,
                Verb = "runas"
            };

            using (var process = new Process { StartInfo = processInfo })
            {
                process.Start();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                process.WaitForExit();

                Console.WriteLine("Вывод:");
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine(output);

                if (!string.IsNullOrWhiteSpace(error))
                {
                    Console.WriteLine("Ошибки:");
                    Console.OutputEncoding = Encoding.UTF8;
                    Console.WriteLine(error);
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}