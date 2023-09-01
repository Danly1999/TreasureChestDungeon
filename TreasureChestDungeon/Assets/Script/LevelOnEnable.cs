using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelOnEnable : MonoBehaviour
{
    Image image;
    public TextMeshProUGUI text;
    public ChestSO chestSO;
    public LevelSO[] levelSOs;
    private void OnEnable() {
        image = GetComponent<Image>();
        image.color = levelSOs[chestSO.levelStatic].color;
        chestSO.equipmentName = (EquipmentName)Random.Range(0,4);
        text.text = chestSO.equipmentName.ToString();
    }

}
