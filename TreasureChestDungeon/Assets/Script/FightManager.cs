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
        chestSO.overEnimestatsAction += OverEnimeStats;
    }
    private void OnDisable() 
    {
        chestSO.enimestatsAction -= SetEnimeStats;
        chestSO.EnimeSOsSetAction -= SetfightSO;
        chestSO.overEnimestatsAction -= OverEnimeStats;
    }
    public void OverEnimeStats()
    {
        enimeStats.SetActive(false);
    }
        public void SetEnimeStats(EnimeSO enimeSO)
    {
        enimeStats.SetActive(true);
        enimeStats.GetComponentsInChildren<Image>()[1].sprite = enimeSO.enimeSprite;
        
        string name;
        string hp;
        string act;
        string def;
        string crit;
        chestSO.languageDictionarys.TryGetValue(enimeSO.nameID,out name);
        chestSO.languageDictionarys.TryGetValue("_TextID_HP",out hp);
        chestSO.languageDictionarys.TryGetValue("_TextID_Act",out act);
        chestSO.languageDictionarys.TryGetValue("_TextID_Def",out def);
        chestSO.languageDictionarys.TryGetValue("_TextID_Crit",out crit);
        enimeStats.GetComponentInChildren<TextMeshProUGUI>().font = chestSO.font;
        enimeStats.GetComponentInChildren<TextMeshProUGUI>().text = name+"\n" + hp +enimeSO.hp+"\n" + act +enimeSO.act+"\n" + def +enimeSO.def+"\n" + crit +enimeSO.crit;
    }
    public void SetfightSO(EnimeSO[] enimeSOs)
    {
        this.enimeSOs = enimeSOs;
        enimeGroup.GetComponent<FightGroup>().enimeSOs = enimeSOs;
        enimeGroup.SetActive(true);

        List<EnimeSO> PlayerenimeSOs = new List<EnimeSO>();
        EnimeSO PlayerenimeSO = ScriptableObject.CreateInstance<EnimeSO>();
        PlayerenimeSO.nameID = "_TextID_Player";
        PlayerenimeSO.hp = PlayerData.instance.stats[0];
        PlayerenimeSO.act = PlayerData.instance.stats[1];
        PlayerenimeSO.def = PlayerData.instance.stats[2];
        PlayerenimeSO.crit = PlayerData.instance.stats[3];
        PlayerenimeSO.enimeSprite = chestSO.playerSprite;
        PlayerenimeSOs.Add(PlayerenimeSO);
        for (int i = 0; i < PlayerData.instance.fightibosID.Length; i++)
        {
            
            if( PlayerData.instance.fightibosID[i] >= 0)
            {
                float scale = (1f+(PlayerData.instance.level*0.1f));
                EnimeSO iboSO = chestSO.iboSO.ibos[PlayerData.instance.fightibosID[i]];
                EnimeSO newIboSO = ScriptableObject.CreateInstance<EnimeSO>();
                newIboSO.nameID = iboSO.nameID;
                newIboSO.hp   = iboSO.hp*scale;
                newIboSO.act  = iboSO.act*scale;
                newIboSO.def  = iboSO.def*scale;
                newIboSO.crit = iboSO.crit*scale;
                newIboSO.enimeSprite = iboSO.enimeSprite;
                PlayerenimeSOs.Add(newIboSO);
            }
        }
        PlayerGroup.GetComponent<FightGroup>().enimeSOs = PlayerenimeSOs.ToArray();
        PlayerGroup.SetActive(true);

    }
}
