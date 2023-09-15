using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetIboStats : MonoBehaviour,IPointerClickHandler
{
    public ChestSO chestSO;
    public EnimeSO enimeSO;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        chestSO.EnimestatsRise(enimeSO);
    }
    private void OnEnable() 
    {

    }
}
