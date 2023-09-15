using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public ChestSO chestSO;
    public UnityEvent unityEvent;
    public UnityEvent checkEvent;
    public UnityEvent OnEnaEvent;
    public GameObject black;
    private void OnEnable() {
        chestSO.canLoop = false;
        chestSO.action += eve;
        chestSO.checkAction += checkChest;
        chestSO.highLightAction += HighLight;
        OnEnaEvent.Invoke();
    }
    private void OnDisable() {
        chestSO.action -= eve;
    }
    private void eve()
    {
        unityEvent.Invoke();
    }
    private void HighLight(Canvas canvas)
    {
        black.GetComponent<AnyKeyDestory>().canvas = canvas;
        black.SetActive(true);
        canvas.sortingLayerName = "OtherDraw";
    }

    private void checkChest()
    {   
        float range = UnityEngine.Random.Range(0f,1f);
        float[] chestLevels = chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels;
        if(range<=chestLevels[(int)chestSO.chestLevel])//获取当前选择等级是否开到了宝箱
        {
            for (int i = chestLevels.Length-1; i >= 0; i--)//从最高级开始探查开到的是哪个等级的宝箱
            {
                if(range<=chestLevels[i])
                {
                    chestSO.levelStatic = i;
                    checkEvent.Invoke();
                    break;
                }
            }
        }

    }

}
