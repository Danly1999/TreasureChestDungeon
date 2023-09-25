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
    public TextMeshProUGUI[] chestLevelTexts;
    public GameObject openKey;
    public GameObject closeKey;
    public GameObject hint;
    public Camera mainCamera;
    private void OnEnable() {
        chestSO.canLoop = false;
        chestSO.action += eve;
        chestSO.chestQuantityTextAction += ChestText;
        chestSO.checkAction += checkChest;
        chestSO.highLightAction += HighLight;
        chestSO.EnbaChestAction += buttonEnb;
        OnEnaEvent.Invoke();
        chestSO.chestLevelUpAction += ChestLevelUp;
        chestSO.createhintAction += Createhint;
        chestSO.overHintAction += Overhint;
        CloseKey();
        for (int i = 0; i < chestLevelTexts.Length; i++)
        {
            chestLevelTexts[i].text = "LV : " + PlayerData.instance.chestLevel;
        }
    }
    private void OnDisable() {
        chestSO.action -= eve;
        chestSO.chestQuantityTextAction -= ChestText;
        chestSO.EnbaChestAction -= buttonEnb;
        chestSO.chestLevelUpAction -= ChestLevelUp;
    }
    public void ChestLevelUp()
    {
        PlayerData.instance.chestLevel=Mathf.Min(PlayerData.instance.chestLevel+1,6);
        for (int i = 0; i < chestLevelTexts.Length; i++)
        {
            chestLevelTexts[i].text = "LV : " + PlayerData.instance.chestLevel;
        }
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
    private void Update()
    {
    }
    private void Createhint(string id)
    {
        if (chestSO.languageDictionarys.TryGetValue(id, out string text))
        {
            hint.SetActive(true);
        RectTransform hintRectTransform = hint.GetComponent<RectTransform>();
        

            int length = text.Length;
            hintRectTransform.sizeDelta = new Vector2(Mathf.Max(Mathf.Min(16f * length, 250), 120), Mathf.Max(Mathf.Min(8f * length, 150),60));
            TextMeshProUGUI textMeshPro = hint.GetComponentInChildren<TextMeshProUGUI>();
            if(textMeshPro.font != chestSO.font)
            {
                textMeshPro.font = chestSO.font;
            }
            textMeshPro.text = text;

        
        
        Vector3 mousePosition = Input.mousePosition;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        hintRectTransform.position = new Vector3(worldPosition.x- (hintRectTransform.sizeDelta.x*0.005f), worldPosition.y- (hintRectTransform.sizeDelta.y*0.005f), hintRectTransform.position.z);
        }
    }
    private void Overhint()
    {
        hint.SetActive(false);
    }

}
