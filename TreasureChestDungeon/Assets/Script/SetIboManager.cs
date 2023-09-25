using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetIboManager : MonoBehaviour
{
    public ChestSO chestSO;
    public GameObject iboStats;
    public GameObject[] iboGroup;
    public GameObject ibo;
    public TeamManager teamManager;

    private void OnEnable() 
    {
        chestSO.enimestatsAction += SetIboStats;
        chestSO.CreateIboAction += CreateIbo;
        chestSO.SetIboTeamIDAction += SetIboTeamID;
    }
    private void OnDisable() 
    {
        chestSO.enimestatsAction -= SetIboStats;
        chestSO.CreateIboAction -= CreateIbo;
        chestSO.SetIboTeamIDAction -= SetIboTeamID;
    }
    private void Start() {
        for (int i = 0; i < PlayerData.instance.ibosID.Length; i++)
        {
            if(PlayerData.instance.ibosID[i] == 1)
            {
                iboGroup[i].GetComponent<SetIboStats>().enabled = true;
                iboGroup[i].GetComponent<SetIboStats>().key.SetActive(false);
            } 
            iboGroup[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range(-15f,15f)));
        }
    }
    public void SetIboTeamID(int id)
    {
        teamManager.id = id;
    }
    public void SetIboStats(EnimeSO enimeSO)
    {
        iboStats.SetActive(true);
        iboStats.GetComponentsInChildren<Image>()[1].sprite = enimeSO.enimeSprite;
        //设置语言
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
        iboStats.GetComponentInChildren<TextMeshProUGUI>().font = chestSO.font;
        float scale = (1f+(PlayerData.instance.level*0.1f));
        iboStats.GetComponentInChildren<TextMeshProUGUI>().text = name+"\n" + hp +enimeSO.hp*scale+"\n" + act +enimeSO.act*scale+"\n" + def +enimeSO.def*scale+"\n" + crit +enimeSO.crit*scale;

    }
    public void CreateIbo(int ibosID)
    {
        iboGroup[ibosID].GetComponent<SetIboStats>().enabled = true;
        iboGroup[ibosID].GetComponent<SetIboStats>().key.SetActive(false);
        PlayerData.instance.ibosID[ibosID] = 1;

    }
}
