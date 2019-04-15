// Modified from https://unity3d.com/learn/tutorials/topics/scripting/localization-manager

using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalizationManager : MonoBehaviour
{
    public static LocalizationManager instance;

    public enum Languages
    {
        English,
        French,
        Spanish
    }

    public Languages selectedLanguage = Languages.English;

    private Dictionary<string, string> localizedText;
    private string missingTextString = "Localized text not found";

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            changeLanguage(selectedLanguage);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
    
    public void changeLanguage(Languages newLanguage)
    {
        selectedLanguage = newLanguage;

        string file;
        switch (newLanguage)
        {
            case Languages.English:
                file = "en.lang";
                break;
            case Languages.French:
                file = "fr.lang";
                break;
            case Languages.Spanish:
                file = "es.lang";
                break;
            default:
                Debug.LogError("Language not found: " + newLanguage.ToString());
                file = "en.lang";
                break;
        }

        loadLocalizedText(file);
    }

    private void loadLocalizedText(string fileName)
    {
        localizedText = new Dictionary<string, string>();
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);

        if (File.Exists(filePath))
        {
            string unparsedData = File.ReadAllText(filePath);

            string[] lines = unparsedData.Split(("\r\n").ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < lines.Length; i++)
            {
                string[] parsedLine = lines[i].Split(new string[] { ":::" }, System.StringSplitOptions.RemoveEmptyEntries);
                if(parsedLine.Length != 2)
                {
                    Debug.LogError("Error parsing dictionary " + fileName);
                }
                else
                {
                    localizedText.Add(parsedLine[0], parsedLine[1]);
                }
            }

            //Debug.Log("Data loaded, dictionary contains: " + localizedText.Count + " entries");
        }
        else
        {
            Debug.LogError("Cannot find file: " + filePath);
        }
    }

    public string getLocalizedString(string key)
    {
        string result = missingTextString;
        if (localizedText.ContainsKey(key))
        {
            result = localizedText[key];
        }

        return result;

    }
}
