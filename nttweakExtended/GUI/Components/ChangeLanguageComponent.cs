using System;
using System.IO;
using System.Text.Json;

namespace nttweakExtended.GUI.Components;

public class ChangeLanguageComponent
{
    private const string configFile = "config.json";

    public static void ChangeLanguage(string newLanguage)
    {
        if (!File.Exists(configFile))
        {
            Console.WriteLine("[NTTWEAK] Файл конфига не был найден.");
            return;
        }

        try
        {
            string configContent = File.ReadAllText(configFile);

            var config = JsonSerializer.Deserialize<AppConfig>(configContent);

            if (config == null)
            {
                Console.WriteLine("[NTTWEAK] Не удалось выполнить десериализование config.json .");
            }

            config.Language = newLanguage;

            var updatedConfig = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(configFile, updatedConfig);


        }
        catch (JsonException)
        {
            Console.WriteLine("[NTTWEAK] Ошибка обработки конфига (config.json). Код ошибки: JsonException.");
        }
        catch (Exception e)
        {
            Console.WriteLine($"[NTTWEAK] Возникла ошибка: {e.Message}");
        }
    }
}