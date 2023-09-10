using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightGroup : MonoBehaviour
{
    public bool isPlayer;
    public EnimeSO[] enimeSOs;
    public GameObject  perfab;
    private void OnEnable() {
        for (int i = 0; i < enimeSOs.Length; i++)
        {
            GameObject enime = Instantiate(perfab, gameObject.transform);

            enime.GetComponent<SetEnime>().enimeSO = enimeSOs[i];
            enime.GetComponent<Image>().sprite = enimeSOs[i].enimeSprite;
            enime.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,Random.Range(-15f,15f)));
        }
    }
}
