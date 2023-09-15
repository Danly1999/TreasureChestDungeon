using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "chestLevelSO", menuName = "ScriptableObject/chestLevelSO", order = 0)]
public class ChestLevelSO : ScriptableObject 
{
    public float[] levels = new float[5] {1f,0.6f,0.3f,0.1f,0.05f};
}
