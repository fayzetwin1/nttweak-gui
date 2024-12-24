using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace nttweakExtended.GUI.Windows;

public partial class AppsMessageBoxWindow : Window
{
    private string _appName;
    
    public AppsMessageBoxWindow(string message, string appName)
    {
        InitializeComponent();
        MessageText.Text = message;
        
        _appName = appName;
    }
    
    private void WinGetButtonOnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
        
        
        string currentExePath = AppDomain.CurrentDomain.BaseDirectory;

        // Указываем имя .exe файла (например, "example.exe")
        string exeFileName = "NTTweakCore.exe";

        // Полный путь к исполняемому файлу
        string exepath = Path.Combine(currentExePath, exeFileName);

        // Указываем аргументы, которые нужно передать .exe файлу
        string arguments = $"--installApp winget {_appName}";  // замените на необходимые аргументы

        // Создаем новый процесс
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = exepath,
            Arguments = arguments,
            UseShellExecute = true, // Используем оболочку для запуска
            CreateNoWindow = false // Создаем новое окно
        };

        // Запускаем процесс
        Process.Start(startInfo);
        
    }

    private void ChocolateyButtonOnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
        
        string currentExePath = AppDomain.CurrentDomain.BaseDirectory;

        // Указываем имя .exe файла (например, "example.exe")
        string exeFileName = "NTTweakCore.exe";

        // Полный путь к исполняемому файлу
        string exepath = Path.Combine(currentExePath, exeFileName);

        // Указываем аргументы, которые нужно передать .exe файлу
        string arguments = $"--installApp chocolatey {_appName}";  // замените на необходимые аргументы

        // Создаем новый процесс
        ProcessStartInfo startInfo = new ProcessStartInfo
        {
            FileName = exepath,
            Arguments = arguments,
            UseShellExecute = true, // Используем оболочку для запуска
            CreateNoWindow = false // Создаем новое окно
        };

        // Запускаем процесс
        Process.Start(startInfo);
    }

    public static async Task Show(string message, string appName, Window? parent = null)
    {
        var messageBox = new AppsMessageBoxWindow(message, appName);
        if (parent != null)
        {
            await messageBox.ShowDialog(parent); // Открыть окно как модальное
        }
        else
        {
            messageBox.Show(); // Открыть окно немодально
        }
    }
}