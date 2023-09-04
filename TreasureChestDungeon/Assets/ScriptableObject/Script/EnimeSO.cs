using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnimeSO", menuName = "ScriptableObject/EnimeSO", order = 0)]
public class EnimeSO : ScriptableObject 
{
    public string enimeName;
    public Sprite enimeSprite;
    public float hp;
    public float act;
    public float def;
    public float crit;

}

