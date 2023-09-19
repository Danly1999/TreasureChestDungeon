using System.Collections;
using System.Collections.Generic;
using TMPro;
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
public enum Language
{
    中文 = 0,
    English = 1,
    日本語 = 2
}
[CreateAssetMenu(fileName = "ChestSO", menuName = "ScriptableObject/ChestSO", order = 0)]
public class ChestSO : ScriptableObject {
    public ChestLevel chestLevel;
    public bool canLoop;
    public FightSO[] fightSOs;
    public LanguageSO[] languageSOs;
    public UnityAction action;
    public UnityAction checkAction;
    public UnityAction dropdownAction;
    public UnityAction equipmentAction;
    public UnityAction saveAction;
    public UnityAction lordAction;
    public UnityAction<float> expAction;
    public UnityAction statsAction;
    public UnityAction<EnimeSO> enimestatsAction;
    public UnityAction<EnimeSO[]> EnimeSOsSetAction;
    public UnityAction fightBlackGroundAction;
    public UnityAction setEnimeSpriteAction;
    public UnityAction<Canvas> highLightAction;
    public UnityAction<string> setDescriptionTestAction;
    public UnityAction setNormalTestAction;
    public UnityAction resetEnimeGroupAction;
    public UnityAction goldAction;
    public UnityAction<int> CreateIboAction;
    public UnityAction StartdropdownAction;
    public UnityAction LordLanguageJsonAction;
    public UnityAction chestQuantityTextAction;
    public int levelStatic;
    public EquipmentName equipmentName;
    public ChestLevelSO[] chestLevelSO;
    public Sprite playerSprite;
    public Dictionary<string, string> languageDictionarys = new Dictionary<string, string>();
    public TMP_FontAsset font;
    public IboSO iboSO;

    public void ChestRise()
    {
        if(PlayerData.instance.chestQuantity>0)
        {
            PlayerData.instance.chestQuantity--;
            PlayerData.instance.chestNub++;
            chestQuantityTextRise();
            action.Invoke();
            ExpRise(PlayerData.instance.level * 100);

        }
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
        SaveRise();
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
    public void SetEnimeSOsRise(EnimeSO[] enimeSOs)
    {
        EnimeSOsSetAction.Invoke(enimeSOs);
    }
    public void FightBlackGroundRise()
    {
        fightBlackGroundAction.Invoke();
    }
    public void SetEnimeSpriteRise()
    {
        setEnimeSpriteAction.Invoke();
    }
    public void SetBlurRise(bool isBlur)
    {
        ChestRenderPipeline.isBlur = isBlur;
    }
    public void SetChestLevel(int Level)
    {
        chestLevel = (ChestLevel)Level;
    }
    public void highLightRise(Canvas canvas)
    {
        highLightAction.Invoke(canvas);
    }
    public void SetLanguageRise(int LanguageID)
    {

    }

    public void SetDescriptionTestRise(string testsID)
    {
        setDescriptionTestAction.Invoke(testsID);
    }
    public void SetNormalTestRise()
    {
        setNormalTestAction.Invoke();
    }
    public void ResetEnimeGroupRise()
    {
        resetEnimeGroupAction.Invoke();
    }
    public void SetGoldRise()
    {
        goldAction.Invoke();
    }
    public void CreateIboRise(int iboID)
    {
        CreateIboAction.Invoke(iboID);
    }
    public void StartdropdownActionRise()
    {
        StartdropdownAction.Invoke();
    }
    
    public void LordLanguageJsonRise()
    {
        LordLanguageJsonAction.Invoke();
    }
    public void chestQuantityTextRise()
    {
        chestQuantityTextAction.Invoke();
    }
    

    IEnumerator DelayedExecute()
    {
        yield return new WaitForSeconds(0.1f);
        action.Invoke();
    }
    
}

