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
    public GameObject PlayerGroup;
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
        switch (PlayerData.instance.language)
        {
            case (Language)0:
            enimeStats.GetComponentInChildren<TextMeshProUGUI>().text = enimeSO.enimeNameCN+"\n生命值:"+enimeSO.hp+"\n攻击力:"+enimeSO.act+"\n防御力:"+enimeSO.def+"\n暴击率:"+enimeSO.crit;
            break;
            case (Language)1:
            enimeStats.GetComponentInChildren<TextMeshProUGUI>().text = enimeSO.enimeNameEN+"\nHP:"+enimeSO.hp+"\nAct:"+enimeSO.act+"\nDef:"+enimeSO.def+"\nCrit:"+enimeSO.crit;
            break;
        }
    }
    public void SetfightSO(EnimeSO[] enimeSOs)
    {
        this.enimeSOs = enimeSOs;
        enimeGroup.GetComponent<FightGroup>().enimeSOs = enimeSOs;
        enimeGroup.SetActive(true);

        List<EnimeSO> PlayerenimeSOs = new List<EnimeSO>();
        EnimeSO PlayerenimeSO = ScriptableObject.CreateInstance<EnimeSO>();
        PlayerenimeSO.hp = PlayerData.instance.stats[0];
        PlayerenimeSO.act = PlayerData.instance.stats[1];
        PlayerenimeSO.def = PlayerData.instance.stats[2];
        PlayerenimeSO.crit = PlayerData.instance.stats[3];
        PlayerenimeSO.enimeSprite = chestSO.playerSprite;
        PlayerenimeSOs.Add(PlayerenimeSO);
        PlayerGroup.GetComponent<FightGroup>().enimeSOs = PlayerenimeSOs.ToArray();
        PlayerGroup.SetActive(true);

    }
}
