using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SetEnime : MonoBehaviour,IPointerClickHandler
{
    public ChestSO chestSO;
    public EnimeSO enimeSO;
    private void OnEnable() 
    {
        // image = GetComponent<Image>();
        // image.sprite = enimeSO.enimeSprite;
    }
    private void OnDisable() 
    {
        Destroy(gameObject);
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        chestSO.EnimestatsRise(enimeSO);
    }
}
