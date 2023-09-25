using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamManager : MonoBehaviour
{
    public int id;
    public Sprite nullSprite;
    public Button[] buttons;
    public ChestSO chestSO;
    private void OnEnable() 
    {
        buttons[0].onClick.AddListener(left);
        buttons[1].onClick.AddListener(right);
    }
    public void left()
    {
        if(chestSO.IboTeamChangeAction != null)
        {
            chestSO.IboTeamChangeRise();
        }
        if(PlayerData.instance.fightibosID[1] == id)
        {
            buttons[1].gameObject.GetComponent<Image>().sprite = nullSprite;
            PlayerData.instance.fightibosID[1] = -1;
        }

        buttons[0].gameObject.GetComponent<Image>().sprite = chestSO.iboSO.ibos[id].enimeSprite;
        PlayerData.instance.fightibosID[0] = id;

    }
    public void right()
    {
        if(chestSO.IboTeamChangeAction != null)
        {
            chestSO.IboTeamChangeRise();
        }
        if(PlayerData.instance.fightibosID[0] == id)
        {
            buttons[0].gameObject.GetComponent<Image>().sprite = nullSprite;
            PlayerData.instance.fightibosID[0] = -1;
        }

            buttons[1].gameObject.GetComponent<Image>().sprite = chestSO.iboSO.ibos[id].enimeSprite;
            PlayerData.instance.fightibosID[1] = id;
        
    }
}
