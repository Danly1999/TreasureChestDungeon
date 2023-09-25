using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class SetEnime : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public ChestSO chestSO;
    public EnimeSO enimeSO;
    public Slider slider;
    public GameObject pa;
    public GameObject boomPa;
    public GameObject die;
    public GameObject particle;
    public GameObject text;
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


    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        chestSO.EnimestatsRise(enimeSO);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        chestSO.OverEnimestatsRise();
    }
}
