using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChestUpText : MonoBehaviour
{

    public ChestSO chestSO;
    TextMeshProUGUI text;
    private void OnEnable() {
        if(PlayerData.instance.chestLevel+1<chestSO.chestLevelSO.Length)
        {
            text = GetComponent<TextMeshProUGUI>();
            text.text = "<color=#0000ff>Blur     </color>"+ 
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[1]*100f).ToString() + "% ->->" + (chestSO.chestLevelSO[PlayerData.instance.chestLevel+1].levels[1]*100f).ToString() + "%" + "\n<color=#ff00ff>Purple   </color>"+
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[2]*100f).ToString() + "% ->->" + (chestSO.chestLevelSO[PlayerData.instance.chestLevel+1].levels[2]*100f).ToString() + "%" + "\n<color=#eeb422>Yellow   </color>"+
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[3]*100f).ToString() + "% ->->" + (chestSO.chestLevelSO[PlayerData.instance.chestLevel+1].levels[3]*100f).ToString() + "%" + "\n<color=#ff3030>Red     </color>"+
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[4]*100f).ToString() + "% ->->" + (chestSO.chestLevelSO[PlayerData.instance.chestLevel+1].levels[4]*100f).ToString() + "%" ;
        }else
        {
            text = GetComponent<TextMeshProUGUI>();
            text.text = "<color=#0000ff>Blur     </color>" +
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[1] * 100f).ToString()+ "%(MAX)" + "\n<color=#ff00ff>Purple   </color>"+
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[2] * 100f).ToString()+ "%(MAX)" + "\n<color=#eeb422>Yellow   </color>"+
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[3] * 100f).ToString()+ "%(MAX)" + "\n<color=#ff3030>Red     </color>"+
            (chestSO.chestLevelSO[PlayerData.instance.chestLevel].levels[4] * 100f).ToString() + "%(MAX)";
        }

    }


}
