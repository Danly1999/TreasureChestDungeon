using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using UnityEngine;
using UnityEngine.Networking;





public class MyData
{
    public Dictionary<string, string> languageDictionary = new Dictionary<string, string>();
}
public class LanguageSave : MonoBehaviour
{
    string[] filePath; // 文件路径

    public ChestSO chestSO;
    private void Start() {
        chestSO.StartdropdownActionRise();
    }
    private void OnEnable() {
        chestSO.LordLanguageJsonAction += LoadJson;
    }
    private void OnDisable() {
        chestSO.LordLanguageJsonAction -= LoadJson;
    }
    public void LoadJson()
    {
        StartCoroutine(LoadJsonFiles());
    }
    public IEnumerator LoadJsonFiles()
    {
        filePath = new string[3];
        filePath[0] = Path.Combine(Application.streamingAssetsPath, "LanguageDictionary_CN.json");
        filePath[1] = Path.Combine(Application.streamingAssetsPath, "LanguageDictionary_EN.json");
        filePath[2] = Path.Combine(Application.streamingAssetsPath, "LanguageDictionary_JP.json");
        // 创建 UnityWebRequest 对象来读取本地文件
        UnityWebRequest www = UnityWebRequest.Get(filePath[(int)PlayerData.instance.language]);

        // 发送网络请求并等待响应
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
            string fileContents = www.downloadHandler.text;
            chestSO.languageDictionarys = JsonConvert.DeserializeObject<LanguageSO>(fileContents).languageDictionarys;


            //Debug.Log("从本地文件中读取的内容：" + fileContents);
        }
        // 记得释放 UnityWebRequest 对象
        www.Dispose();
        chestSO.DropdownRise();
    }


    public void Save()
    {
#if UNITY_EDITOR
        MyData data = new MyData();
        data.languageDictionary.Add("_change_language","语言");
        data.languageDictionary.Add("_change_weapon","武器");
        // 将PlayerData对象序列化为JSON字符串
        string json = JsonConvert.SerializeObject(data);

        // 将JSON字符串保存到文件
        File.WriteAllText(Application.dataPath + "/LanguageDictionary.json", json);
#endif
    }
}
