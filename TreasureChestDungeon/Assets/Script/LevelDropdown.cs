using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LevelDropdown : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public ChestSO chestSO;
    public TMP_FontAsset font_CN;
    public TMP_FontAsset font_JP;
    private void OnEnable() {
        dropdown = GetComponent<TMP_Dropdown>();
        chestSO.dropdownAction += CheckDropdown;
    }

    private void OnDisable()
    {
        chestSO.dropdownAction -= CheckDropdown;
    }
    private void Start() {
        dropdown.value = (int)PlayerData.instance.language;
    }
    public void CheckDropdown()
    {
        PlayerData.instance.language = (Language)dropdown.value;
        //chestSO.SetDescriptionTestRise((int)chestSO.chestLevel);
        //chestSO.SetNormalTestRise();
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>(true);

        for (int i = 0; i < texts.Length; i++)
        {
            if(texts[i].name.Length>7)
            {
                if(texts[i].name.Substring(0, 7) == "_TextID")
                {
                    string text = "";
                    switch (PlayerData.instance.language)
                    {
                        case Language.中文:
                        chestSO.languageDictionary_CN.TryGetValue(texts[i].gameObject.name,out text);
                        if(texts[i].font != font_CN)
                        {
                            texts[i].font = font_CN;
                        }
                        break;
                        case Language.English:
                        chestSO.languageDictionary_EN.TryGetValue(texts[i].gameObject.name,out text);
                        if(texts[i].font != font_CN)
                        {
                            texts[i].font = font_CN;
                        }
                        break;
                        case Language.日本語:
                        chestSO.languageDictionary_JP.TryGetValue(texts[i].gameObject.name,out text);
                        if(texts[i].font != font_JP)
                        {
                            texts[i].font = font_JP;
                        }
                        break;
                    }
                    texts[i].text = text;
                }

            }
            
        }

    }
}
