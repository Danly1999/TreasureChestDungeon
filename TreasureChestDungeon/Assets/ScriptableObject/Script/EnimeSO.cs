using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnimeSO", menuName = "ScriptableObject/EnimeSO", order = 0)]
public class EnimeSO : ScriptableObject 
{
    public string nameID;
    public Sprite enimeSprite;
    public int lv = 1;
    public float hp;
    public float act;
    public float def;
    public float crit;

}

