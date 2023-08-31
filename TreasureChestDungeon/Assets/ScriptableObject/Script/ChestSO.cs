using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "ChestSO", menuName = "ScriptableObject/ChestSO", order = 0)]
public class ChestSO : ScriptableObject {
    public static bool canLoop;
    public UnityAction action;
    public UnityAction checkAction;
    public float[] levels = new float[5] {1f,0.6f,0.3f,0.1f,0.05f};
    public void ChestRise()
    {
        action.Invoke();
    }
    public void LoopChestRise()
    {
        if(canLoop)
        {
            action.Invoke();
        }
    }
    public void checkChestRise()
    {
        checkAction.Invoke();
    }
    public void SetLoop(bool canLoop)
    {
        ChestSO.canLoop = canLoop;
    }
    
}

