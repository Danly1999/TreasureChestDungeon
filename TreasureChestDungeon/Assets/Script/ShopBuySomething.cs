using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ShopBuySomething : MonoBehaviour,IPointerClickHandler
{
    public ChestSO chestSO;
    public TextMeshProUGUI goldText;
    public UnityEvent unityEvent;
    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        int gold;
        int.TryParse(goldText.text.Replace("$:",""),out gold);
        Debug.Log(gold);
        if(PlayerData.instance.goldQuantity>=gold)
        {
            PlayerData.instance.goldQuantity -= gold;
            chestSO.SetGoldRise();
            unityEvent.Invoke();
        }else
        {
            chestSO.createhintAction("_TextID_Hint08");
        }
    }
}
