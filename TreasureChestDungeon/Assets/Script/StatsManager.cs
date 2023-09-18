using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StatsManager : MonoBehaviour
{
    public ChestSO chestSO;
    public Vector3 vector3;
    public Vector3 Starvector3;
    public TextMeshProUGUI[] text;
    private void OnEnable() 
    {
        for (int i = 0; i < PlayerData.instance.stats.Length; i++)
        {
            text[i].text = PlayerData.instance.stats[i].ToString();
        }
        chestSO.statsAction += SetStats;

    }
    private void OnDisable() {
        chestSO.statsAction -= SetStats;

    }
    public void SetStats()
    {
        for (int i = 0; i < PlayerData.instance.stats.Length; i++)
        {
            text[i].text = PlayerData.instance.stats[i].ToString();
        }
    }

    //void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    //{
    //    rectTransform.localPosition = vector3;
    //}

    //void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    //{
    //    rectTransform.localPosition = Starvector3;
    //    //rectTransform = starRectTransform;
    //}
}
