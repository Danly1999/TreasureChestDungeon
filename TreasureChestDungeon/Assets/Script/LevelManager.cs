using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    TextMeshProUGUI text;
    public TextMeshProUGUI goldText;
    public Slider slider;
    public ChestSO chestSO;
    private void OnEnable() {
        text = GetComponent<TextMeshProUGUI>();
        chestSO.lordAction += SetLevel;
        chestSO.lordAction += SetExp;
        chestSO.lordAction += SetGold;
        chestSO.expAction += AddExperience;
        chestSO.goldAction += SetGold;

    }
    private void OnDisable() {
        chestSO.lordAction -= SetLevel;
        chestSO.lordAction -= SetExp;
        chestSO.lordAction -= SetGold;
        chestSO.expAction -= AddExperience;
        chestSO.goldAction -= SetGold;
    }
    public void SetLevel()
    {
        text.text = "LV : "+PlayerData.instance.level.ToString();
    }
    public void SetGold()
    {
        goldText.text = "$ : "+PlayerData.instance.goldQuantity.ToString();
    }
    public void SetExp()
    {
        float experience = (PlayerData.instance.Experience)/(PlayerData.instance.level*PlayerData.instance.level*500);
        slider.value = Mathf.Max(0,experience);
    }
    public void AddExperience(float value)
    {
        float exp = PlayerData.instance.Experience+value*(PlayerData.instance.chestLevel+1);
        float experience = (exp)/(PlayerData.instance.level*PlayerData.instance.level*500);

        if(experience<1)
        {
            slider.value = Mathf.Max(0,experience);
            PlayerData.instance.Experience = exp;
        }
        else
        {
            PlayerData.instance.Experience = (exp)-(PlayerData.instance.level*PlayerData.instance.level*500);
            PlayerData.instance.level++;
            slider.value = Mathf.Max(0,PlayerData.instance.Experience);
        }
        SetLevel();
    }
}
