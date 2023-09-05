using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnimeGroup : MonoBehaviour, IPointerClickHandler
{
    public ChestSO chestSO;
    public EnimeSO[] enimeSOs;
    public GameObject perfab;
    public void SetSprite()
    {
        for (int i = 0; i < enimeSOs.Length; i++)
        {
            GameObject enime = Instantiate(perfab, gameObject.transform);
            enime.GetComponent<Image>().sprite = enimeSOs[i].enimeSprite;
        }
    }
    private void OnEnable() {
        chestSO.setEnimeSpriteAction += SetSprite;
    }
    private void OnDisable() {
        chestSO.setEnimeSpriteAction -= SetSprite;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(enimeSOs != null)
        {
            chestSO.FightBlackGroundRise();
            chestSO.SetEnimeSOsRise(enimeSOs);
        }
    }
}
