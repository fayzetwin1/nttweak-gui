using System;
using System.Globalization;
using System.IO;
using System.Resources;
using System.Text.Json;
using Avalonia.Controls;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Markup.Xaml;
using Avalonia.Markup.Xaml.Styling;
using nttweakExtended.GUI.Windows;

namespace nttweakExtended;

public partial class LoadingIntroWindow : Window
{
    
    
    
    
    public LoadingIntroWindow()
    {
        InitializeComponent();
        Initialize();
    }

    public async void Initialize()
    {
        await Task.Delay(3000);
        openMainMenu(); 
    }

    

    private void openMainMenu()
    {
        var mainMenu = new MainMenuWindow();
        mainMenu.Show();
        this.Close();
    }
    
    
}
