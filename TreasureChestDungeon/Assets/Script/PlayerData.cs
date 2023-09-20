using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerData
{
    public int level;
    public float hp;
    public float Experience;
    public float[] stats;
    public int[] EquipmentSpriteID;
    public int[] EquipmentLV;
    public int[] EquipmentAchievement;
    public int chestNub;
    public int fightSOID;
    public int chestQuantity;
    public int chestLevel;
    public int goldQuantity;
    public int[] ibosID;
    public int achievementID;
    public int[] fightibosID;
    public Language language;

    //public float 
    // 私有构造函数，在类初始化的时候进行调用
    public PlayerData()
    {
        level = 1;
        hp = 1;
        Experience = 0;
        stats = new float[4]{100,10,5,1};
        EquipmentSpriteID = new int[4]{-1,-1,-1,-1};
        EquipmentLV = new int[4]{0,0,0,0};
        EquipmentAchievement = new int[4]{0,0,0,0};
        chestNub = 0;
        fightSOID = 0;
        chestQuantity = 300;
        chestLevel = 0;
        goldQuantity = 0;
        ibosID = new int[18]{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        achievementID = 0;
        fightibosID = new int[2]{-1,-1};
        language = Language.中文;
    }
    // 使用单例模式，设置一个全局单例对象
    public static PlayerData instance = new PlayerData();

}