using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using nttweakExtended.Tweaker;

namespace nttweakExtended.GUI.Pages;

public partial class AppearanceMenuPage : UserControl
{
    public Action<Type> NavigateToPage { get; set; }
    
    public AppearanceMenuPage()
    {
        InitializeComponent();
    }

    private void EnableSecondsTaskbar(object? sender, RoutedEventArgs e)
    {
        string commands =
            "reg add \"HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v ShowSecondsInSystemClock /t REG_DWORD /d 1 /f";
        TweakInitializeComponent.ExecuteCommand(commands);
    }

    private void DisableSecondsTaskbar(object? sender, RoutedEventArgs e)
    {
        string commands =
            "reg add \"HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Explorer\\Advanced\" /v ShowSecondsInSystemClock /t REG_DWORD /d 0 /f";
        TweakInitializeComponent.ExecuteCommand(commands);
    }
}