using System.Collections;
using System.Collections.Generic;
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
    private void OnEnable() {
        image = GetComponent<Image>();
        chestSO.equipmentAction += SetEquipment;
    }
    private void OnDisable() {
        chestSO.equipmentAction -= SetEquipment;
    }
    public void SetEquipment()
    {
        if(this.equipmentName == chestSO.equipmentName)
        {
            image.color = levelSOs[chestSO.levelStatic].color;

        }
    }
}
