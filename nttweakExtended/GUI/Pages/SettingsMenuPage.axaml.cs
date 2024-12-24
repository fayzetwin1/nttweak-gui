using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using ActiproSoftware.UI.Avalonia.Controls;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia.Enums;
using MsBox.Avalonia.Models;
using nttweakExtended.GUI.Components;
using nttweakExtended.GUI.Windows;

namespace nttweakExtended.GUI.Pages;

public partial class SettingsMenuPage : UserControl
{
    public Action<Type> NavigateToPage { get; set; }
    
    public SettingsMenuPage()
    {
        InitializeComponent();
    }

    private async void RULanguageOnClick(object? sender, RoutedEventArgs e)
    {
        await MessageBoxWindow.Show("// ENG\nBefore changing the localization, you will need to restart the tweaker. Do you want to do it right now?\n\n// RU\nПрежде чем менять язык, вам нужно будет перезапустить твикер. Хотите сделать это прямо сейчас?");
        ChangeLanguageComponent.ChangeLanguage("ru");
    }

    async private void ENLanguageOnClick(object? sender, RoutedEventArgs e)
    {

            //var result = await box.ShowAsync();
            await MessageBoxWindow.Show("// ENG\nBefore changing the localization, you will need to restart the tweaker. Do you want to do it right now?\n\n// RU\nПрежде чем менять язык, вам нужно будет перезапустить твикер. Хотите сделать это прямо сейчас?");
            ChangeLanguageComponent.ChangeLanguage("en");
    }

    private void DonationAlertsOnClick(object? sender, RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://www.donationalerts.com/r/fayzetwin",
            UseShellExecute = true
        });
    }

    private void GithubOnClick(object? sender, RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/fayzetwin1",
            UseShellExecute = true
        });
    }
}