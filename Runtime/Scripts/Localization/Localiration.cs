using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Localization", menuName = "Tools/Localization", order = 1)]
public class Localiration : ScriptableObject
{
    public Language lang;
    [Serializable]
    public struct NamedImage {
        public string key;
        public string translate;
    }
    public NamedImage[] translations;

    public Dictionary<string, string> dict;

    private void Awake()
    {
        dict = new Dictionary<string, string>();
        foreach (var VARIABLE in translations)
        {
            dict.Add(VARIABLE.key,VARIABLE.translate);
        }
        translations[0].translate = "ti Pidoras";
    }
}