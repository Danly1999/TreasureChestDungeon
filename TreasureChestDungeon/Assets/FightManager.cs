using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class FightManager : MonoBehaviour
{
    public ChestSO chestSO;
    public EnimeSO[] enimeSOs;
    public GameObject enimeStats;
    public GameObject enimeGroup;
    private void OnEnable() 
    {
        chestSO.enimestatsAction += SetEnimeStats;
        chestSO.EnimeSOsSetAction += SetfightSO;
    }
    private void OnDisable() 
    {
        chestSO.enimestatsAction -= SetEnimeStats;
        chestSO.EnimeSOsSetAction -= SetfightSO;
    }
    public void SetEnimeStats(EnimeSO enimeSO)
    {
        enimeStats.SetActive(true);
        enimeStats.GetComponentsInChildren<Image>()[1].sprite = enimeSO.enimeSprite;
        enimeStats.GetComponentInChildren<TextMeshProUGUI>().text = enimeSO.enimeName+"\nHP:"+enimeSO.hp+"\nAct:"+enimeSO.act+"\nDef:"+enimeSO.def+"\nCrit:"+enimeSO.crit;
    }
    public void SetfightSO(EnimeSO[] enimeSOs)
    {
        this.enimeSOs = enimeSOs;
        enimeGroup.GetComponent<FightGroup>().enimeSOs = enimeSOs;

        enimeGroup.SetActive(true);
    }
}
