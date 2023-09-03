using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelDropdown : MonoBehaviour
{
    TMP_Dropdown dropdown;
    public ChestSO chestSO;
    private void OnEnable() {
        dropdown = GetComponent<TMP_Dropdown>();
        chestSO.dropdownAction += CheckDropdown;
        chestSO.DropdownRise();
    }
    private void OnDisable()
    {
        chestSO.dropdownAction -= CheckDropdown;
    }
    public void CheckDropdown()
    {
        chestSO.chestLevel = (ChestLevel)dropdown.value;
    }
}
