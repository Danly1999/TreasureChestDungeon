using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class EventManager : MonoBehaviour
{
    public ChestSO chestSO;
    public UnityEvent unityEvent;
    public UnityEvent checkEvent;
    public UnityEvent OnEnaEvent;
    public GameObject black;
    public Button button;
    public TextMeshProUGUI chestText;
    public TextMeshProUGUI chestLevelText;
    public GameObject openKey;
    public GameObject closeKey;
    private void OnEnable() {
        chestSO.canLoop = false;
        chestSO.action += eve;
        chestSO.chestQuantityTextAction += ChestText;
        chestSO.checkAction += checkChest;
        chestSO.highLightAction += HighLight;
        chestSO.EnbaChestAction += buttonEnb;
        OnEnaEvent.Invoke();
        chestSO.chestLevelUpAction += ChestLevelUp;
        CloseKey();
        chestLevelText.text = "LV : " + PlayerData.instance.chestLevel;
    }
    private void OnDisable() {
        chestSO.action -= eve;
        chestSO.chestQuantityTextAction -= ChestText;
        chestSO.EnbaChestAction -= buttonEnb;
        chestSO.chestLevelUpAction -= ChestLevelUp;
    }
    public void ChestLevelUp()
    {
        PlayerData.instance.chestLevel++;
        chestLevelText.text = "LV : " + PlayerData.instance.chestLevel;
    }
    public void CloseKey()
    {
        if(PlayerData.instance.achievementID>=5)
        {
            openKey.SetActive(true);
            closeKey.SetActive(false);

        }
    }
    public void buttonEnb(bool ena)
    {
        button.enabled = ena;
    }
    private void eve()
    {
        unityEvent.Invoke();
    }
    void ChestText()
    {
        string text;
        chestSO.languageDictionarys.TryGetValue("_TextID_ChestQuantity", out text);
        chestText.text = text + PlayerData.instance.chestQuantity;
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
