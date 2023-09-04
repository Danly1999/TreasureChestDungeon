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
    private void OnEnable() 
    {
        chestSO.enimestatsAction += SetEnimeStats;
    }
    private void OnDisable() 
    {
        chestSO.enimestatsAction -= SetEnimeStats;
    }
    public void SetEnimeStats(EnimeSO enimeSO)
    {
        enimeStats.SetActive(true);
        enimeStats.GetComponentsInChildren<Image>()[1].sprite = enimeSO.enimeSprite;
        enimeStats.GetComponentInChildren<TextMeshProUGUI>().text = enimeSO.enimeName+"\nHP:"+enimeSO.hp+"\nAct:"+enimeSO.act+"\nDef:"+enimeSO.def+"\nCrit:"+enimeSO.crit;
    }
}
