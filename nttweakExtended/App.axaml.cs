using System;
using System.Globalization;
using System.IO;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using HarfBuzzSharp;
using nttweakExtended.ViewModels;
using System.Text.Json;
using System.Threading.Tasks;

namespace nttweakExtended;

public partial class App : Application
{
    private const string jsonFile = "config.json";
    
    public static AppConfig Config { get; private set; }
    
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public async override void OnFrameworkInitializationCompleted()
    {
        await EnsureConfigFile();
        try
        {

            string jsonContent = File.ReadAllText(jsonFile);
            
            var jsonData = JsonSerializer.Deserialize<AppConfig>(jsonContent);
            
            if (jsonData?.Language == "ru")
            {
                Assets.Resources.Culture = new CultureInfo("ru");
            }

            if (jsonData?.Language == "en")
            {
                Assets.Resources.Culture = new CultureInfo("en-us");
            }
        }
        catch (JsonException)
        {
            Console.WriteLine("[NTTWEAK] Не удалось обработать config.json");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[NTTWEAK] Возникла ошибка при обработке config.json: {ex.Message}");
        }
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new LoadingIntroWindow()
            {
                DataContext = new LoadingIntroWindowViewModel(),
            };
        }

        
        base.OnFrameworkInitializationCompleted();
        await Task.Delay(2000);
    }
    
    private async Task EnsureConfigFile()
    {
        if (!File.Exists(jsonFile))
        {
            Config = new AppConfig { Language = "ru", ColorScheme = "blue" };
            SaveConfig();
        }
        else
        {
            try
            {
                var configData = await File.ReadAllTextAsync(jsonFile);
                Config = JsonSerializer.Deserialize<AppConfig>(configData) ?? new AppConfig();
            }
            catch
            {
                Config = new AppConfig { Language = "en", ColorScheme = "blue" };
                SaveConfig();
            }
        }
        
        
    }


    
    public static void SaveConfig()
    {
        var configData = JsonSerializer.Serialize(Config, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(jsonFile, configData);
    }
}


public class AppConfig
{
    public string Language { get; set; } = "en";
    public string ColorScheme { get; set; } = "blue";
}

