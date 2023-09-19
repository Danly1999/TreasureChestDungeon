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
    public int actionID;
    public int addChest;
    public void OnEnable() {
        button = GetComponent<Button>();
        chestSO.action += Achievement;
    }
    private void OnDisable()
    {
        chestSO.action -= Achievement;
    }

    public void Achievement()
    {
        if(PlayerData.instance.chestNub >= actionID)
        {
            chestSO.action -= Achievement;
            button.onClick.AddListener(AddChest);
            button.interactable = true;
        }
    }
    public void AddChest()
    {
        PlayerData.instance.chestQuantity += addChest;
        chestSO.chestQuantityTextRise();
        gameObject.SetActive(false);
    }
}
