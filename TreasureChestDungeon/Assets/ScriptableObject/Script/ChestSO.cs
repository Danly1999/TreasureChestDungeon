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
    public bool canLoop;
    public FightSO fightSO;
    public UnityAction action;
    public UnityAction checkAction;
    public UnityAction dropdownAction;
    public UnityAction equipmentAction;
    public UnityAction saveAction;
    public UnityAction lordAction;
    public UnityAction<float> expAction;
    public UnityAction statsAction;
    public UnityAction<EnimeSO> enimestatsAction;
    public UnityAction<FightSO,int> fightSOSetAction;
    public int levelStatic;
    public EquipmentName equipmentName;
    public float[] levels = new float[5] {1f,0.6f,0.3f,0.1f,0.05f};
    public void ChestRise()
    {
        action.Invoke();
        ExpRise(PlayerData.instance.level*100);
    }
    public void LoopChestRise()
    {
        if(canLoop)
        {
            //DelayedExecute();
            ChestRise();
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
        this.canLoop = canLoop;
    }
    public void SaveRise()
    {
        saveAction.Invoke();
    }
    public void LordRise()
    {
        lordAction.Invoke();
    }
    public void ExpRise(float value)
    {
        expAction.Invoke(value);
    }
    public void StatsRise()
    {
        statsAction.Invoke();
    }
    public void EnimestatsRise(EnimeSO enimeSO)
    {
        enimestatsAction.Invoke(enimeSO);
    }
    public void SetFightSORise(int id)
    {
        fightSOSetAction.Invoke(fightSO,id);
    }
    IEnumerator DelayedExecute()
    {
        yield return new WaitForSeconds(0.1f);
        action.Invoke();
    }
    
}

