using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using nttweakExtended.GUI.Windows;
using nttweakExtended.Tweaker;

namespace nttweakExtended.GUI.Pages;

public partial class MainMenuPage : UserControl
{
    
    public Action<Type> NavigateToPage { get; set; }
    
    public MainMenuPage()
    {
        InitializeComponent();
        
    }

    private void GoToAppearancePage(object sender, RoutedEventArgs e)
    {
        NavigateToPage?.Invoke(typeof(AppearanceMenuPage));
    }

    private void GoToAppsPage(object sender, RoutedEventArgs e)
    {
        NavigateToPage?.Invoke(typeof(AppsMenuPage));
        //ParentWindow?.GoToAppsPage(sender, e);
    }


    private void ReloadExplorer(object? sender, RoutedEventArgs e)
    {
        string commands = "echo Минутку... && taskkill /f /im explorer.exe && timeout /t 2 && start explorer.exe";
        TweakInitializeComponent.ExecuteCommand(commands);
    }
}