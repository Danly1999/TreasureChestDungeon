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
    private void OnEnable() {
        chestSO.action += eve;
        chestSO.checkAction += checkChest;
    }
    private void OnDisable() {
        chestSO.action -= eve;
    }
    private void eve()
    {
        unityEvent.Invoke();
    }
    private void checkChest()
    {   
        float range = UnityEngine.Random.Range(0f,1f);
        if(range<=chestSO.levels[(int)chestSO.chestLevel])//获取当前选择等级是否开到了宝箱
        {
            for (int i = chestSO.levels.Length-1; i >= 0; i--)//从最高级开始探查开到的是哪个等级的宝箱
            {
                if(range<=chestSO.levels[i])
                {
                    chestSO.levelStatic = i;
                    checkEvent.Invoke();
                    Debug.Log(Enum.GetName(typeof(ChestLevel), i)+range);
                    break;
                }
            }
        }

    }

}
