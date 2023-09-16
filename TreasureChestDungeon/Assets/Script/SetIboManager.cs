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
        for (int i = 0; i < PlayerData.instance.ibosID.Length; i++)
        {
            Debug.Log(i);
            if(PlayerData.instance.ibosID[i] == 1)
            {
                iboGroup[i].GetComponent<SetIboStats>().enabled = true;
                iboGroup[i].GetComponent<SetIboStats>().key.SetActive(false);
            } 
            iboGroup[i].GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,UnityEngine.Random.Range(-15f,15f)));
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
        iboGroup[ibosID].GetComponent<SetIboStats>().enabled = true;
        iboGroup[ibosID].GetComponent<SetIboStats>().key.SetActive(false);
        PlayerData.instance.ibosID[ibosID] = 1;

    }
}
