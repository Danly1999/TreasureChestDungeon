using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AchievementFightSystem : MonoBehaviour
{
    Button button;
    public ChestSO chestSO;
    public GameObject particel;
    public int addChest;
    public int actionID;
    public bool isResetGroup;
    public int achievementID;

    public void Start()
    {

        button = GetComponent<Button>();
        chestSO.goldAction += Achievement;
        Achievement();
    }
    private void OnDisable()
    {
        chestSO.goldAction -= Achievement;
    }

    public void Achievement()
    {
        if(isResetGroup)
        {
            if(PlayerData.instance.fightSOID >= actionID)
            {
                chestSO.goldAction -= Achievement;
                button.onClick.AddListener(AddChest);
                button.interactable = true;
                particel.SetActive(true);
            }

        }else
        {
            if (PlayerData.instance.goldQuantity >= actionID)
            {
                chestSO.goldAction -= Achievement;
                button.onClick.AddListener(AddChest);
                button.interactable = true;
                particel.SetActive(true);
            }

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
