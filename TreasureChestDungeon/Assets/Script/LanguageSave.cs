using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OfficeOpenXml;
using UnityEngine;
using UnityEngine.Networking;





public class MyData
{
    public Dictionary<string, string> languageDictionary = new Dictionary<string, string>();
}
public class LanguageSave : MonoBehaviour
{
    string filePath_CN; // 文件路径
    string filePath_EN; // 文件路径
    string filePath_JP; // 文件路径
    public ChestSO chestSO;
    private void Start() {
        StartCoroutine(LoadJsonFiles());
    }
IEnumerator LoadJsonFiles()
{
    
    filePath_CN = Path.Combine(Application.streamingAssetsPath, "Super_LanguageDictionary.json");


    // 创建 UnityWebRequest 对象来读取本地文件
    UnityWebRequest www_cn = UnityWebRequest.Get(filePath_CN);


    // 发送网络请求并等待响应
    yield return www_cn.SendWebRequest();

    if (www_cn.result == UnityWebRequest.Result.Success)
    {
        string fileContents = www_cn.downloadHandler.text;
        Dictionary<string, string>[] languageDictionarys = JsonConvert.DeserializeObject<LanguageSO>(fileContents).languageDictionarys;
        chestSO.languageDictionary_CN = languageDictionarys[0];
        chestSO.languageDictionary_EN = languageDictionarys[1];
        chestSO.languageDictionary_JP = languageDictionarys[2];
        //Debug.Log("从本地文件中读取的内容：" + fileContents);
    }


    // 记得释放 UnityWebRequest 对象
    www_cn.Dispose();

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
