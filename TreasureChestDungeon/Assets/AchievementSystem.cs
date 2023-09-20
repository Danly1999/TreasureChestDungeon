using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum AchievementName
{
    Chest,
    OpenKey,
    Equipment,
    Fight,
    ResetFight

}

public class AchievementSystem : MonoBehaviour
{
    Button button;
    public AchievementName achievementName;
    public ChestSO chestSO;
    public GameObject particel;
    public int actionID;
    public int addChest;
    public int achievementID;
    public void Start() {
        button = GetComponent<Button>();
        switch (achievementName)
        {
            case AchievementName.Chest :
            chestSO.action += Chest;
            Chest();
            break;
            case AchievementName.OpenKey :
            chestSO.action += OpenKey;
            OpenKey();
            break;
            case AchievementName.Equipment :
            chestSO.equipmentAction += Equipment;
            Equipment();
            break;
            case AchievementName.Fight :
            chestSO.goldAction += Fight;
            OpenKey();
            break;
            case AchievementName.ResetFight :
            chestSO.goldAction += ResetFight;
            ResetFight();
            break;
        }
    }
    private void OnDisable()
    {

    }

    public void Chest()
    {
        if(PlayerData.instance.chestNub >= actionID)
        {
            chestSO.action -= Chest;
            button.onClick.AddListener(AddChest);
            button.interactable = true;
            particel.SetActive(true);
        }
    }
    public void OpenKey()
    {
        if (chestSO.canLoop == true)
        {
            chestSO.action -= OpenKey;
            button.onClick.AddListener(AddChest);
            button.interactable = true;
            particel.SetActive(true);
        }
    }
    public void Equipment()
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
            chestSO.equipmentAction -= Equipment;
            button.onClick.AddListener(AddChest);
            button.interactable = true;
            particel.SetActive(true);
        }
    }
    public void Fight()
    {
            if (PlayerData.instance.goldQuantity >= actionID)
            {
                chestSO.goldAction -= Fight;
                button.onClick.AddListener(AddChest);
                button.interactable = true;
                particel.SetActive(true);
            }
    }
        public void ResetFight()
    {
            if(PlayerData.instance.fightSOID >= actionID)
            {
                chestSO.goldAction -= ResetFight;
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
