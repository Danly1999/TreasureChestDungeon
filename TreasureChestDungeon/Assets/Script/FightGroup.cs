using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightGroup : MonoBehaviour
{
    public bool isPlayer;
    public EnimeSO[] enimeSOs;
    public GameObject  perfab;
    public List<GameObject> enimes;
    private void OnEnable() {
        enimes = new List<GameObject>();
        for (int i = 0; i < enimeSOs.Length; i++)
        {
            GameObject enime = Instantiate(perfab, gameObject.transform);
            EnimeSO enimeSO = ScriptableObject.CreateInstance<EnimeSO>();
            enimeSO.enimeNameCN = enimeSOs[i].enimeNameCN;
            enimeSO.enimeNameEN = enimeSOs[i].enimeNameEN;
            enimeSO.enimeSprite = enimeSOs[i].enimeSprite;
            enimeSO.hp          = enimeSOs[i].hp         ;
            enimeSO.act         = enimeSOs[i].act        ;
            enimeSO.def         = enimeSOs[i].def        ;
            enimeSO.crit        = enimeSOs[i].crit       ;
            enime.GetComponent<SetEnime>().enimeSO = enimeSO;
            enime.GetComponent<Image>().sprite = enimeSOs[i].enimeSprite;
            enime.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,Random.Range(-10f,10f)));
            enimes.Add(enime);
        }
    }

}
