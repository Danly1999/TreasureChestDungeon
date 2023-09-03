using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSO", menuName = "ScriptableObject/LevelSO", order = 0)]
public class LevelSO : ScriptableObject {
    public string levelName = "green";
    public Sprite[] sprites;
    public Color color = Color.green;
    public float scale = 1;
}

