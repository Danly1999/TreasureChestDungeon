using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelOnEnable : MonoBehaviour
{
    Image image;
    public Image EquipmentImage;
    public TextMeshProUGUI text;
    public ChestSO chestSO;
    public LevelSO[] levelSOs;
    private void OnEnable() {
        image = GetComponent<Image>();
        image.color = levelSOs[chestSO.levelStatic].color;
        chestSO.equipmentName = (EquipmentName)Random.Range(0,4);
        float sourceStats = 0;
        float targetStats = 0;
        switch (chestSO.equipmentName)
        {
            case EquipmentName.UpperGarment:
                //targetStats = PlayerData.instance.level*1000*levelSOs[chestSO.levelStatic].scale;
                sourceStats = PlayerData.instance.stats[0];
                break;
            case EquipmentName.Weapon:
                //targetStats = PlayerData.instance.level*50*levelSOs[chestSO.levelStatic].scale;
                sourceStats = PlayerData.instance.stats[1];
                break;
            case EquipmentName.LowerGarment:
                //targetStats = PlayerData.instance.level*20*levelSOs[chestSO.levelStatic].scale;
                sourceStats = PlayerData.instance.stats[2];
                break;
            case EquipmentName.Accessory:
                //targetStats = PlayerData.instance.level * levelSOs[chestSO.levelStatic].scale;
                sourceStats = PlayerData.instance.stats[3];
                break;

        }
        targetStats = chestSO.EquipmentQuantity(chestSO.equipmentName);

        text.text = "LV : "+ PlayerData.instance.level +"\n"+ sourceStats + "--> -->"+targetStats;
        if(sourceStats>targetStats)
        {
            text.fontSize = 25;
        }else if(sourceStats<targetStats)
        {
            text.fontSize = 36;
        }else
        {
            text.fontSize = 30;
        }

        EquipmentImage.sprite = levelSOs[chestSO.levelStatic].sprites[(int)chestSO.equipmentName];
    }

}
