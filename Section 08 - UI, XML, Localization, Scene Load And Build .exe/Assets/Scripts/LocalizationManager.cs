using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public enum Languages 
{ 
    English,
    French
}

public class LocalizationManager : MonoBehaviour
{
    [SerializeField] private Languages CurrentLanguages = Languages.English;

    private Dictionary<Languages, TextAsset> LocalizationFiles = new Dictionary<Languages, TextAsset>();
    private Dictionary<string, string> LocalizationData = new Dictionary<string, string>();

    public static LocalizationManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        { 
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        SetUpLocalizationFiles();
        SetUpLocalizationData();
    }
    void Start()
    {
    }

    void Update()
    {

    }

    void SetUpLocalizationFiles()
    {
        foreach (Languages language in Languages.GetValues(typeof(Languages)))
        {
            string LocalizationFilePath = "Localization/" + language;
            TextAsset textAsset = (TextAsset)Resources.Load(LocalizationFilePath);
            if (textAsset)
            {
                LocalizationFiles[language] = textAsset;
                Debug.Log(LocalizationFiles[language].name);
            }
            else
            {
                Debug.Log("Text asset not found!");
            }
        }
    }

    void SetUpLocalizationData()
    {
        TextAsset textAsset;
        if (LocalizationFiles.ContainsKey(CurrentLanguages)/* return true or false check if the dictionary LocalizationFiles contains the current language as a key or not. */)
        {
            textAsset = LocalizationFiles[CurrentLanguages];
        }
        else
        {
            Debug.LogError("Couldn't find localization file!");
            textAsset = LocalizationFiles[Languages.English];
        }

        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(textAsset.text);

        XmlNodeList EntryList = xmlDocument.GetElementsByTagName("Entry");

        foreach (XmlNode Entry in EntryList)
        {
            if (!LocalizationData.ContainsKey(Entry.FirstChild.InnerText))
            {
                Debug.Log("Added Key: " + Entry.FirstChild.InnerText + " || Value: " + Entry.LastChild.InnerText);
                LocalizationData.Add(Entry.FirstChild.InnerText, Entry.LastChild.InnerText);
            }
            else
            {
                Debug.LogError("Text Asset not found");
            }
        }
    }

    public string GetLocalizedString(string key)
    {
        string localizedstring = "";

        if (!LocalizationData.TryGetValue(key, out localizedstring)) 
        { 
            localizedstring = "LOC KEY: " + key;
        }

        return localizedstring;
    }
}
