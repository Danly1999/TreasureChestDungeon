using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AchievementSystem : MonoBehaviour
{
    Button button;
    public ChestSO chestSO;
    public GameObject particel;
    public int actionID;
    public int addChest;
    public int achievementID;
    public bool isKey;
    public void Start() {
        if (PlayerData.instance.achievementID > achievementID)
        {
            gameObject.SetActive(false);
            return;
        }
        button = GetComponent<Button>();
        if(isKey)
        {
            chestSO.action += OpenKey;
        }
        else
        {
            chestSO.action += Achievement;

        }
    }
    private void OnDisable()
    {
        if (isKey)
        {
            chestSO.action -= OpenKey;
        }
        else
        {
            chestSO.action -= Achievement;

        }
    }

    public void Achievement()
    {
        if(PlayerData.instance.chestNub >= actionID)
        {
            chestSO.action -= Achievement;
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
    public void AddChest()
    {
        PlayerData.instance.achievementID = achievementID + 1;
        PlayerData.instance.chestQuantity += addChest;
        chestSO.chestQuantityTextRise();
        gameObject.SetActive(false);
    }
}
