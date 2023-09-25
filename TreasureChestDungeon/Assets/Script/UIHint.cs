using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIHint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public ChestSO chestSO;
    public string id;
    public void OnPointerEnter(PointerEventData eventData)
    {
        chestSO.createhintAction(id);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        chestSO.overHintAction();
    }


}
