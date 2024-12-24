using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using nttweakExtended.GUI.Windows;

namespace nttweakExtended.GUI.Pages;

public partial class AppsMenuPage : UserControl
{
    public Action<Type> NavigateToPage { get; set; }
    
    public AppsMenuPage()
    {
        InitializeComponent();
    }

    async private void DiscordOnClick(object? sender, RoutedEventArgs e)
    {
        await AppsMessageBoxWindow.Show("Через какой пакетный менеджер вы бы хотели установить это приложение?",
            "discord");
        
    }

    async private void TelegramOnClick(object? sender, RoutedEventArgs e)
    {
        await AppsMessageBoxWindow.Show("Через какой пакетный менеджер вы бы хотели установить это приложение?",
            "telegram");
    }
    
    async private void ChromeOnClick(object? sender, RoutedEventArgs e)
    {
        await AppsMessageBoxWindow.Show("Через какой пакетный менеджер вы бы хотели установить это приложение?",
            "Chrome");
    }
    
    async private void SpotifyOnClick(object? sender, RoutedEventArgs e)
    {
        await AppsMessageBoxWindow.Show("Через какой пакетный менеджер вы бы хотели установить это приложение?",
            "spotify");
    }
    
    
}