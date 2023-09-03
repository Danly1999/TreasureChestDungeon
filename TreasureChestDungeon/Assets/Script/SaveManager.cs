using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    string filePath; // 文件路径
    public ChestSO chestSO;
    private void Awake() 
    {
// #if UNITY_EDITOR
//         filePath = Application.dataPath + "/PlayerData.json"; // 文件路径
//         // 从文件加载JSON字符串
//         if (File.Exists(filePath))
//         {
//             string json = File.ReadAllText(filePath);
//             // 将JSON字符串反序列化为PlayerData对象
//             PlayerData.instance = JsonUtility.FromJson<PlayerData>(json);

//         }else
//         {
//             PlayerData.instance = new PlayerData();
//             Save();
//         }
// #else
        
        if(PlayerPrefs.GetString("josn","0")!="0")
        {
            PlayerData.instance = JsonUtility.FromJson<PlayerData>(PlayerPrefs.GetString("josn"));

        }else
        {
            PlayerData.instance = new PlayerData();
        }
        
//#endif


    }
    private void Start() {
        chestSO.LordRise();
    }
    private void OnEnable() {
        chestSO.saveAction += Save;
    }
    private void OnDisable() {
        chestSO.saveAction -= Save;
    }
    public void Save()
    {
// #if UNITY_EDITOR
//         // 将PlayerData对象序列化为JSON字符串
//         string json = JsonUtility.ToJson(PlayerData.instance);

//         // 将JSON字符串保存到文件
//         File.WriteAllText(Application.dataPath + "/PlayerData.json", json);
// #else
        // 将PlayerData对象序列化为JSON字符串
        string json = JsonUtility.ToJson(PlayerData.instance);

        PlayerPrefs.SetString("josn",json);
//#endif

    }

}
