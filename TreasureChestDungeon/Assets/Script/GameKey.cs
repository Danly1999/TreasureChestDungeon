using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKey : MonoBehaviour
{
    public ChestSO chestSO;
    public GameObject obj;
    private int[] ints = new int[4]{0,0,0,0};

    private void Start() {
        chestSO.equipmentAction += Check;
        Check();
    }

    private void OnDisable() {
        chestSO.equipmentAction -= Check;
        
    }
    private void Check()
    {

        int checkID = 0;
        for (int i = 0; i < PlayerData.instance.EquipmentAchievement.Length; i++)
        {
            if(PlayerData.instance.EquipmentAchievement[i] >= 1)
            {
                checkID++;
            }
        }
        if(checkID == 4)
        {
            obj.SetActive(true);
        }

    }

}
