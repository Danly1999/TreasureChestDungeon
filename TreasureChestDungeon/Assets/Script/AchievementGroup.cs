using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AchievementGroup : MonoBehaviour
{
    public ChestSO chestSO;
    public GameObject[] Achievements;
    private void OnEnable() {
        chestSO.achievementRiseAction += EnableAchievement;
    }
    private void OnDisable() {
        chestSO.achievementRiseAction -= EnableAchievement;
    }
    void Start()
    {
       EnableAchievement();
    }

    public void EnableAchievement() 
    {
        if(PlayerData.instance.achievementID<Achievements.Length)
        Achievements[PlayerData.instance.achievementID].SetActive(true);
    }
}
