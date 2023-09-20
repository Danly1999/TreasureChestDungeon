using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class AchievementEquipmentSystem : MonoBehaviour
{
    Button button;
    public ChestSO chestSO;
    public GameObject particel;
    public int addChest;
    private int[] ints = new int[4] { 0, 0, 0, 0 };
    public int achievementID;
    public void Start() {

        button = GetComponent<Button>();
        chestSO.equipmentAction += Achievement;
        Achievement();
    }
    private void OnDisable()
    {
        chestSO.equipmentAction -= Achievement;
    }

    public void Achievement()
    {
        int checkID = 0;
        for (int i = 0; i < PlayerData.instance.EquipmentAchievement.Length; i++)
        {
            if (PlayerData.instance.EquipmentAchievement[i] >= 1)
            {
                checkID++;
            }
        }
        if (checkID == 4)
        {
            chestSO.equipmentAction -= Achievement;
            button.onClick.AddListener(AddChest);
            button.interactable = true;
            particel.SetActive(true);
        }
    }
    public void AddChest()
    {
        PlayerData.instance.achievementID = achievementID + 1;
        chestSO.AchievementRise();
        PlayerData.instance.chestQuantity += addChest;
        chestSO.chestQuantityTextRise();
        gameObject.SetActive(false);
    }
}
