using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnyKeyDestory : MonoBehaviour
{
    public Canvas canvas;
    public ChestSO chestSO;
    public UnityEvent unityEvent;
    UnityAction unityAction;
    private void OnEnable() 
    {
        chestSO.action += OutFunc;
        
    }
    private void Start()
    {
        if (PlayerData.instance.chestQuantity == 0)
        {
            chestSO.chestQuantityTextRise();
            OutFunc();
        }
    }
    private void OnDisable() 
    {
        chestSO.action -= OutFunc;
        this.unityAction -= OutFunc;
    }
    public void InputAction(UnityAction unityAction)
    {
        this.unityAction = unityAction;
        this.unityAction += OutFunc;
    }
    public void OutFunc()
    {
        if(canvas)
        {
            canvas.sortingLayerName = "Default";
            chestSO.SetBlurRise(false);
        }
        this.unityAction -= OutFunc;
        gameObject.SetActive(false);
    }
    // Update is called once per frame

}
