using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetIboStats : MonoBehaviour,IPointerClickHandler
{
    public ChestSO chestSO;
    public int id;
    public GameObject key;
    
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        chestSO.SetIboTeamIDRise(id);
        chestSO.EnimestatsRise(chestSO.iboSO.ibos[id]);
    }
    private void OnEnable() 
    {
    }
}
