using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetIboManager : MonoBehaviour
{
    public ChestSO chestSO;
    public IboSO iboSO;
    public GameObject iboStats;
    public GameObject[] iboGroup;
    public GameObject ibo;

    private void OnEnable() 
    {
        chestSO.enimestatsAction += SetIboStats;
        chestSO.CreateIboAction += CreateIbo;
    }
    private void OnDisable() 
    {
        chestSO.enimestatsAction -= SetIboStats;
        chestSO.CreateIboAction -= CreateIbo;
    }
    private void Start() {
        for (int i = 0; i < PlayerData.instance.ibosID.Count; i++)
        {
            iboGroup[i].SetActive(true);
            iboGroup[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range(-15f,15f)));
            iboGroup[i].GetComponent<SetIboStats>().enimeSO = iboSO.ibos[PlayerData.instance.ibosID[i]];
            iboGroup[i].GetComponentInChildren<TextMeshProUGUI>().text = chestSO.language == 0? iboSO.ibos[PlayerData.instance.ibosID[i]].enimeNameCN : iboSO.ibos[PlayerData.instance.ibosID[i]].enimeNameEN;
            iboGroup[i].GetComponentsInChildren<Image>()[1].sprite = iboSO.ibos[PlayerData.instance.ibosID[i]].enimeSprite;
        }
    }
    public void SetIboStats(EnimeSO enimeSO)
    {
        iboStats.SetActive(true);
        iboStats.GetComponentsInChildren<Image>()[1].sprite = enimeSO.enimeSprite;
        //设置语言
        iboStats.GetComponentInChildren<TextMeshProUGUI>().text = chestSO.language == 0?
         enimeSO.enimeNameCN+"\n生命值:"+enimeSO.hp+"\n攻击力:"+enimeSO.act+"\n防御力:"+enimeSO.def+"\n暴击率:"+enimeSO.crit :
         enimeSO.enimeNameEN+"\nHP:"+enimeSO.hp+"\nAct:"+enimeSO.act+"\nDef:"+enimeSO.def+"\nCrit:"+enimeSO.crit;

    }
    public void CreateIbo(int ibosID)
    {
        foreach (var ibo in iboGroup)
        {
            if(ibo.activeSelf == false)
            {
                ibo.SetActive(true);
                ibo.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range(-15f,15f)));
                ibo.GetComponent<SetIboStats>().enimeSO = iboSO.ibos[ibosID];
                ibo.GetComponentInChildren<TextMeshProUGUI>().text = chestSO.language == 0? iboSO.ibos[ibosID].enimeNameCN : iboSO.ibos[ibosID].enimeNameEN;
                ibo.GetComponentsInChildren<Image>()[1].sprite = iboSO.ibos[ibosID].enimeSprite;
                PlayerData.instance.ibosID.Add(ibosID);
                return;

            }
            
        }
        Debug.Log("满了");
    }
}
