using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class LevelDropdown : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public ChestSO chestSO;
    public TMP_FontAsset[] font;
    private void OnEnable() {
        dropdown = GetComponent<TMP_Dropdown>();
        chestSO.dropdownAction += CheckDropdown;
        chestSO.StartdropdownAction += SetStartDropdown;
    }

    private void OnDisable()
    {
        chestSO.dropdownAction -= CheckDropdown;
        chestSO.StartdropdownAction -= SetStartDropdown;
    }
    public void SetStartDropdown()
    {
        dropdown.value = (int)PlayerData.instance.language;
    }
    public void UpdatePlayerData()
    {
        PlayerData.instance.language = (Language)dropdown.value;
    }
    public void CheckDropdown()
    {
        TextMeshProUGUI[] texts = FindObjectsOfType<TextMeshProUGUI>(true);
        chestSO.font = font[(int)PlayerData.instance.language];

        for (int i = 0; i < texts.Length; i++)
        {
            if(texts[i].name.Length>7)
            {
                if(texts[i].name.Substring(0, 7) == "_TextID")
                {
                    string text = "";
                    chestSO.languageDictionarys.TryGetValue(texts[i].gameObject.name,out text);
                    if(texts[i].font != font[(int)PlayerData.instance.language])
                    {
                        texts[i].font = font[(int)PlayerData.instance.language];
                    }
                    
                    texts[i].text = text;
                }

            }
            
        }

    }
}
