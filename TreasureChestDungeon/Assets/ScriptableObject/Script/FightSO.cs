using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;



[CreateAssetMenu(fileName = "FightSO", menuName = "ScriptableObject/FightSO", order = 0)]
public class FightSO : ScriptableObject 
{
    public Sprite scenceSprite;
    public EnimeSO[] enimeSOs00;
    public EnimeSO[] enimeSOs01;
    public EnimeSO[] enimeSOs02;
    public EnimeSO[] enimeSOsBoss;
}

