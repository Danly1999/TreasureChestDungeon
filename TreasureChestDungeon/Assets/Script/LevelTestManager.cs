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
        chestSO.languageDictionarys.TryGetValue(id,out text);
        description.text = text;
        
    }

    private void OnEnable() {
        chestSO.setDescriptionTestAction += SetDescriptionTest;

    }
    private void OnDisable() {
        chestSO.setDescriptionTestAction -= SetDescriptionTest;

    }
}
