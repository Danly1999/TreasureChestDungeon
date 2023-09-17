using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTestManager : MonoBehaviour
{
    public ChestSO chestSO;
    public TextMeshProUGUI description;
    public void SetDescriptionTest(String id)
    {
        string text = "";
        switch (PlayerData.instance.language)
        {
            case Language.中文:
            chestSO.languageDictionary_CN.TryGetValue(id,out text);
            description.text = text;
            break;
            case Language.English:
            chestSO.languageDictionary_EN.TryGetValue(id,out text);
            description.text = text;
            break;
            case Language.日本語:
            chestSO.languageDictionary_JP.TryGetValue(id,out text);
            description.text = text;
            break;
        }
        
    }

    private void OnEnable() {
        chestSO.setDescriptionTestAction += SetDescriptionTest;

    }
    private void OnDisable() {
        chestSO.setDescriptionTestAction -= SetDescriptionTest;

    }
}
