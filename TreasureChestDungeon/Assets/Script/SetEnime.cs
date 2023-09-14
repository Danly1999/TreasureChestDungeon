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
    public Slider slider;
    public GameObject pa;
    public GameObject boomPa;
    public GameObject die;
    public GameObject particle;
    private void OnEnable() 
    {
        slider = GetComponentInChildren<Slider>();
        slider.value = 1;
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
