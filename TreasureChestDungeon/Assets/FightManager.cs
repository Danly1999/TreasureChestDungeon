using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public ChestSO chestSO;
    public FightSO fightSO;
    public GameObject enimeStats;
    public GameObject enimeGroup;
    private void OnEnable() 
    {
        chestSO.enimestatsAction += SetEnimeStats;
        chestSO.fightSOSetAction += SetfightSO;
    }
    private void OnDisable() 
    {
        chestSO.enimestatsAction -= SetEnimeStats;
        chestSO.fightSOSetAction -= SetfightSO;
    }
    public void SetEnimeStats(EnimeSO enimeSO)
    {
        enimeStats.SetActive(true);
        enimeStats.GetComponentsInChildren<Image>()[1].sprite = enimeSO.enimeSprite;
        enimeStats.GetComponentInChildren<TextMeshProUGUI>().text = enimeSO.enimeName+"\nHP:"+enimeSO.hp+"\nAct:"+enimeSO.act+"\nDef:"+enimeSO.def+"\nCrit:"+enimeSO.crit;
    }
    public void SetfightSO(FightSO fightSO,int id)
    {
        this.fightSO = fightSO;
        switch (id)
        {
            case 0:
            enimeGroup.GetComponent<FightGroup>().enimeSOs = fightSO.enimeSOs00;
            break;
            case 1:
            enimeGroup.GetComponent<FightGroup>().enimeSOs = fightSO.enimeSOs01;
            break;
            case 2:
            enimeGroup.GetComponent<FightGroup>().enimeSOs = fightSO.enimeSOs02;
            break;
            case 3:
            enimeGroup.GetComponent<FightGroup>().enimeSOs = fightSO.enimeSOsBoss;
            break;
        }
        enimeGroup.SetActive(true);
    }
}
