using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    TextMeshProUGUI text;
    public Slider slider;
    public ChestSO chestSO;
    private void OnEnable() {
        text = GetComponent<TextMeshProUGUI>();
        chestSO.lordAction += SetLevel;
        chestSO.lordAction += SetExp;
        chestSO.expAction += AddExperience;

    }
    private void OnDisable() {
        chestSO.lordAction -= SetLevel;
        chestSO.lordAction -= SetExp;
        chestSO.expAction -= AddExperience;
    }
    public void SetLevel()
    {
        text.text = "LV : "+PlayerData.instance.level.ToString();
    }
    public void SetExp()
    {
        float experience = (PlayerData.instance.Experience)/(PlayerData.instance.level*PlayerData.instance.level*500);
        slider.value = Mathf.Max(0,experience);
    }
    public void AddExperience(float value)
    {
        float experience = (PlayerData.instance.Experience+value)/(PlayerData.instance.level*PlayerData.instance.level*500);

        if(experience<1)
        {
            slider.value = Mathf.Max(0,experience);
            PlayerData.instance.Experience = PlayerData.instance.Experience+value;
        }
        else
        {
            PlayerData.instance.Experience = (PlayerData.instance.Experience+value)-(PlayerData.instance.level*PlayerData.instance.level*500);
            PlayerData.instance.level++;
            slider.value = Mathf.Max(0,PlayerData.instance.Experience);
        }
        SetLevel();
    }
}
