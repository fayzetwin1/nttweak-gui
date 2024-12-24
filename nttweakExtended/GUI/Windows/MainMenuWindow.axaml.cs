using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using nttweakExtended.GUI.Pages;
using Avalonia.Animation;
using ActiproSoftware.UI.Avalonia.Controls;
using nttweakExtended.GUI.Windows;

namespace nttweakExtended;

public partial class MainMenuWindow : Window
{
    private MainMenuPage? MainMenuPage;
    private AppsMenuPage? AppsMenuPage;
    private AppearanceMenuPage? AppearanceMenuPage;
    private SettingsMenuPage? SettingsMenuPage;
    
    public MainMenuWindow()
    {
        InitializeComponent();
        
        var mainMenuPage = this.FindControl<MainMenuPage>("MainMenuPage");
        if (mainMenuPage != null)
        {
            // Подписываемся на событие или передаем делегат
            mainMenuPage.NavigateToPage = GoToPage;
        }
        
        GoToMainPage(null, null);
    }
    
    public void GoToPage(Type pageType)
    {
        // Создаем страницу только при необходимости
        if (pageType == typeof(MainMenuPage))
        {
            if (MainMenuPage == null)
            {
                MainMenuPage = new MainMenuPage();
                MainMenuPage.NavigateToPage = GoToPage;  // Передаем делегат
            }
            PageContentPanel.Content = MainMenuPage;
        }
        else if (pageType == typeof(AppsMenuPage))
        {
            if (AppsMenuPage == null)
            {
                AppsMenuPage = new AppsMenuPage();
                AppsMenuPage.NavigateToPage = GoToPage;  // Передаем делегат
            }
            PageContentPanel.Content = AppsMenuPage;
        }
        else if (pageType == typeof(AppearanceMenuPage))
        {
            if (AppearanceMenuPage == null)
            {
                AppearanceMenuPage = new AppearanceMenuPage();
                AppearanceMenuPage.NavigateToPage = GoToPage;  // Передаем делегат
            }
            PageContentPanel.Content = AppearanceMenuPage;
        }
        else if (pageType == typeof(SettingsMenuPage))
        {
            if (SettingsMenuPage == null)
            {
                SettingsMenuPage = new SettingsMenuPage();
                SettingsMenuPage.NavigateToPage = GoToPage;
            }

            PageContentPanel.Content = SettingsMenuPage;
        }
    }

    public void GoToMainPage(object? sender, RoutedEventArgs? e)
    {
        GoToPage(typeof(MainMenuPage));  // Вызов для отображения главной страницы
        //var transition = new CrossFade(TimeSpan.FromMilliseconds(1000));
    }

    public async void GoToAppsPage(object? sender, RoutedEventArgs? e)
    {
        GoToPage(typeof(AppsMenuPage));  // Вызов для отображения страницы приложений
        //var transition = new CrossFade(TimeSpan.FromMilliseconds(1000));
        //await MessageBoxWindow.Show("its just example", this);
    }

    public void GoToAppearancePage(object? sender, RoutedEventArgs? e)
    {
        GoToPage(typeof(AppearanceMenuPage));  // Вызов для отображения страницы внешнего вида
        //var transition = new CrossFade(TimeSpan.FromMilliseconds(1000));
    }

    public void GoToSettingsPage(object? sender, RoutedEventArgs? e)
    {
        GoToPage(typeof(SettingsMenuPage));
    }
    
    

    
    
}