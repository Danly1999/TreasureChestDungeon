using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EnimeGroup : MonoBehaviour, IPointerClickHandler
{
    public FightLoop fightloop;
    public int GroupID;
    public ChestSO chestSO;
    public EnimeSO[] enimeSOs;
    public GameObject perfab;
    List<GameObject> enimes = new List<GameObject>();
    public void SetSprite()
    {
        for (int i = 0; i < enimeSOs.Length; i++)
        {
            GameObject enime = Instantiate(perfab, gameObject.transform);
            enime.GetComponent<Image>().sprite = enimeSOs[i].enimeSprite;
            enime.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0,0,Random.Range(-15f,15f)));
            enimes.Add(enime);
        }
    }

    private void OnEnable() {
        chestSO.setEnimeSpriteAction += SetSprite;

    }
    private void OnDisable() {
        chestSO.setEnimeSpriteAction -= SetSprite;
        foreach (GameObject item in enimes)
        {
            Destroy(item);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(enimeSOs != null)
        {
            fightloop.GroupID = GroupID;
            chestSO.FightBlackGroundRise();
            chestSO.SetEnimeSOsRise(enimeSOs);
            chestSO.SetBlurRise(true);
        }
    }
}
