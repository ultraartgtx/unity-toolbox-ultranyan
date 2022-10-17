using System;
using System.Collections.Generic;
using UnityEngine;

public class Localizator
{
    public static Language activeLanguage;

    private static readonly Dictionary<Language, Dictionary<string, string>> _localizedTexts =
        new Dictionary<Language, Dictionary<string, string>>
        {
            {
                Language.RUSSIAN, new Dictionary<string, string>
                {
                    {"privacy_policy_text", "Я прочитал политику конфиденциальности и условия использования"},
                    {"privacy_policy_readBtn", "Читать политику кофниденциальности"},
                    {"privacy_policy_aceptBtn", "Принять и продолжить"},
                    {"clickToContinue", "нажмите чтобы продолжить"},
                    {"level", "Уровень"},
                    {"passed", "пройден!"},
                    {"shopTitleColors", "ЦВЕТ"},
                    {"shopTitleTrails", "СЛЕД"},
                    {"shopTitleMaterials", "ШАРЫ"},
                    {"shopActive", "АКТИВНО"},
                    {"shopActivate", "АКТИВИРОВАТЬ"},
                    {"shopBuy", "КУПИТЬ"},
                    {"settingsTitle", "НАСТРОЙКИ"},
                    {"settingsSound", "МУЗЫКА"},
                    {"settingsEffects", "ЭФФЕКТЫ"},
                    {"color_1", "цвет 1"},
                    {"color_2", "цвет 2"},
                    {"color_3", "цвет 3"},
                    {"material_1", "шар 1"},
                    {"material_2", "шар 2"},
                    {"material_3", "шар 3"},
                    {"trail_1", "след 1"},
                    {"trail_2", "след 2"},
                    {"trail_3", "след 3"},

                    
                }
            },
            {
                Language.ENGLISH, new Dictionary<string, string>
                {
                    {"privacy_policy_text", "I have read the privacy policy and terms of use"},
                    {"privacy_policy_readBtn", "Read privacy policy"},
                    {"privacy_policy_aceptBtn", "Accept and continue"},
                    {"clickToContinue", "click to continue"},
                    {"level", "Level"},
                    {"passed", "passed!"},
                    {"shopTitleColors", "1111"},
                    {"shopTitleTrails", "1111"},
                    {"shopTitleMaterials", "1111"},
                    {"shopActive", "1111"},
                    {"shopActivate", "1111"},
                    {"shopBuy", "1111"},
                    {"settingsTitle", "SETTINGS"},
                    {"settingsSound", "Sound"},
                    {"settingsEffects", "Effects"},
                    {"color_1", "1111"},
                    {"color_2", "1111"},
                    {"color_3", "1111"},
                    {"material_1", "1111"},
                    {"material_2", "1111"},
                    {"material_3", "1111"},
                    {"trail_1", "1111"},
                    {"trail_2", "1111"},
                    {"trail_3", "1111"},
                }
            }
        };


    private static readonly Dictionary<Language, Dictionary<string, Sprite>> _localizedSprites =
        new Dictionary<Language, Dictionary<string, Sprite>>
        {
            {Language.RUSSIAN, new Dictionary<string, Sprite>()},
            {Language.ENGLISH, new Dictionary<string, Sprite>()}
        };

    public static string GetTextValue(string key)
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Russian:
                activeLanguage = Language.RUSSIAN;
                break;
            case SystemLanguage.English:
                activeLanguage = Language.ENGLISH;
                break;
            default:
                activeLanguage = Language.ENGLISH;
                break;
        }

        var _res = "";
        try
        {
            _res = _localizedTexts[activeLanguage][key];
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }

        return _res;
    }

    public static string GetTextValueForLanguage(string key, Language language)
    {
        var _res = "";
        try
        {
            _res = _localizedTexts[language][key];
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
        }

        return _res;
    }

    public static Sprite GetSpriteValue(string key)
    {
        try
        {
            return _localizedSprites[activeLanguage][key];
        }
        catch (Exception e)
        {
            Debug.Log(e.StackTrace);
            return null;
        }
    }
}

public enum Language
{
    ENGLISH = 0,
    RUSSIAN = 1,
    PORTUGUESE = 2,
    SPANISH = 3,
    FRENCH = 4,
    INDONESIAN = 5,
    GERMAN = 6,
    ITALIAN = 7,
    POLISH = 8
}