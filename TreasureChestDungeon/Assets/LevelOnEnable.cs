using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOnEnable : MonoBehaviour
{
    Image image;
    public ChestSO chestSO;
    public LevelSO[] levelSOs;
    private void OnEnable() {
        image = GetComponent<Image>();
        image.color = levelSOs[chestSO.levelStatic].color;
    }


}
