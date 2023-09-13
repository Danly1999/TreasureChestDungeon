using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public int level;
    public float hp;
    public float Experience;
    public float[] stats;
    public Sprite[] EquipmentSprite;
    public int[] EquipmentLV;
    public int[] EquipmentAchievement;
    public int fightSOID;

    //public float 
    // 私有构造函数，在类初始化的时候进行调用
    public PlayerData()
    {
        level = 1;
        hp = 1;
        Experience = 0;
        stats = new float[4]{100,10,5,1};
        EquipmentSprite = new Sprite[4]{null,null,null,null};
        EquipmentLV = new int[4]{0,0,0,0};
        EquipmentAchievement = new int[4]{0,0,0,0};
        fightSOID = 0;
    }
    // 使用单例模式，设置一个全局单例对象
    public static PlayerData instance = new PlayerData();

}