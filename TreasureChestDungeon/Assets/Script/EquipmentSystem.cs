using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

    public enum EquipmentName
    {
        UpperGarment = 0,
        LowerGarment = 1,
        Weapon = 2,
        Accessory = 3
    }
public class EquipmentSystem : MonoBehaviour
{
    public ChestSO chestSO;
    public LevelSO[] levelSOs;
    public EquipmentName equipmentName;
    
    Image image;
    TextMeshProUGUI text;
    int lv;
    private void OnEnable() {
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        if(PlayerData.instance.EquipmentLV[(int)equipmentName] != 0)
        {
            lv = PlayerData.instance.level;
            text.text = "LV : " + lv;
        }
        if(PlayerData.instance.EquipmentSpriteID[(int)equipmentName] >= 0)
        {
            image.sprite = levelSOs[PlayerData.instance.EquipmentSpriteID[(int)equipmentName]].sprites[(int)equipmentName];
        }
        chestSO.equipmentAction += SetEquipment;
        chestSO.equipmentAction += EquipmentSave;
    }
    private void OnDisable() {
        chestSO.equipmentAction -= SetEquipment;
        chestSO.equipmentAction -= EquipmentSave;
    }
    public void EquipmentSave()
    {
        PlayerData.instance.EquipmentLV[(int)equipmentName] = lv;
        if(this.equipmentName == chestSO.equipmentName)
        {
            PlayerData.instance.EquipmentSpriteID[(int)equipmentName] = chestSO.levelStatic;
        }
    }
    public void SetEquipment()
    {
        
        if(this.equipmentName == chestSO.equipmentName)
        {
            GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range(-15f,15f)));
            PlayerData.instance.EquipmentAchievement[(int)chestSO.equipmentName]++;
            image.sprite = levelSOs[chestSO.levelStatic].sprites[(int)equipmentName];
            lv = PlayerData.instance.level;
            text.text = "LV : " + lv;
            float targetStats = chestSO.EquipmentQuantity(chestSO.equipmentName);
            switch (equipmentName)
            {
                case EquipmentName.UpperGarment:
                    PlayerData.instance.stats[0] = targetStats;
                    break;
                case EquipmentName.Weapon:
                    PlayerData.instance.stats[1] = targetStats;
                    break;
                case EquipmentName.LowerGarment:
                    PlayerData.instance.stats[2] = targetStats;
                    break;
                case EquipmentName.Accessory:
                    PlayerData.instance.stats[3] = targetStats;
                    break;

            }
            chestSO.StatsRise();
        }
    }
}
