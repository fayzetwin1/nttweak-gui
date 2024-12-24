using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace nttweakExtended.GUI.Windows;

public partial class MessageBoxWindow : Window
{
    public MessageBoxWindow(string message)
    {
        InitializeComponent();
        MessageText.Text = message;
    }
    
    private void YesButtonOnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close();
        
        Console.WriteLine("Программа запущена. Через 2 секунд она перезапустится.");

        // Задержка перед перезапуском
        Thread.Sleep(2000);

        // Получаем текущий исполняемый файл
        string exePath = Assembly.GetExecutingAssembly().Location;

        // Запускаем новый процесс
        Process.Start(exePath);

        // Закрываем текущий процесс
        Environment.Exit(0);
        
    }

    private void NoButtonOnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(); 
    }

    public static async Task Show(string message, Window? parent = null)
    {
        var messageBox = new MessageBoxWindow(message);
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