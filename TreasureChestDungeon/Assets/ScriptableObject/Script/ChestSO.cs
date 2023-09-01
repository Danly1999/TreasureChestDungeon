using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ChestLevel
{
    green = 0,
    blur = 1,
    purple = 2,
    yellow = 3,
    red = 4

}
[CreateAssetMenu(fileName = "ChestSO", menuName = "ScriptableObject/ChestSO", order = 0)]
public class ChestSO : ScriptableObject {
    public ChestLevel chestLevel;
    public static bool canLoop;
    public UnityAction action;
    public UnityAction checkAction;
    public UnityAction dropdownAction;
    public UnityAction equipmentAction;
    public int levelStatic;
    public EquipmentName equipmentName;
    public float[] levels = new float[5] {1f,0.6f,0.3f,0.1f,0.05f};
    public void ChestRise()
    {
        action.Invoke();
    }
    public void LoopChestRise()
    {
        if(canLoop)
        {
            //DelayedExecute();
            action.Invoke();
        }
    }
    public void checkChestRise()
    {
        checkAction.Invoke();
    }
    public void DropdownRise()
    {
        dropdownAction.Invoke();
    }
    public void EquipmentRise()
    {
        equipmentAction.Invoke();
    }
    public void SetLoop(bool canLoop)
    {
        ChestSO.canLoop = canLoop;
    }
    IEnumerator DelayedExecute()
    {
        yield return new WaitForSeconds(0.1f);
        action.Invoke();
    }
    
}

