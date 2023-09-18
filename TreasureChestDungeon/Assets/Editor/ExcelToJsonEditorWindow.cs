using UnityEditor;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using OfficeOpenXml;
using UnityEngine.Networking;

public class ExcelToJsonEditorWindow : EditorWindow
{

    // 在Unity菜单中创建一个新的菜单项
    [MenuItem("Window/ExcelToJsonEditorWindow")]
    public static void ShowWindow()
    {
        // 创建窗口实例
        ExcelToJsonEditorWindow window = (ExcelToJsonEditorWindow)EditorWindow.GetWindow(typeof(ExcelToJsonEditorWindow));
        window.titleContent = new GUIContent("ExcelToJsonEditorWindow");
        window.Show();
    }

    // 在窗口内绘制GUI元素
    private void OnGUI()
    {
        GUILayout.Label("ExcelToJsonEditorWindow", EditorStyles.boldLabel);

        // 添加一个按钮
        if (GUILayout.Button("Click Me"))
        {
            // 按下按钮后执行的方法
            ReadExcel();
        }
    }

    // 按钮点击事件的处理方法
 void ReadExcel() {
        string outPutDir = "Assets/Editor/Dictionary.xlsx";
        LanguageSO languageSO_cn = new LanguageSO();
        LanguageSO languageSO_en = new LanguageSO();
        LanguageSO languageSO_jp = new LanguageSO();

        using ( ExcelPackage package = new ExcelPackage(new FileStream(outPutDir, FileMode.Open)) )
        {
            for ( int i = 1; i <= package.Workbook.Worksheets.Count; ++i )
            {
                ExcelWorksheet sheet = package.Workbook.Worksheets[i];
                for ( int j = sheet.Dimension.Start.Row+1, k = sheet.Dimension.End.Row; j <= k; j++ )
                {
                        string key = sheet.GetValue(j, 1).ToString();
                        key = key.Trim();               
                        string value_cn = sheet.GetValue(j, 2).ToString();    
                        value_cn = value_cn.Replace("\\n","\n");               
                        string value_en = sheet.GetValue(j, 3).ToString();  
                        value_en = value_en.Replace("\\n","\n");                   
                        string value_jp = sheet.GetValue(j, 4).ToString();  
                        value_jp = value_jp.Replace("\\n","\n");                   
                        if ( key != null && value_cn != null)
                        {
                            languageSO_cn.languageDictionarys.Add(key,value_cn);
                            languageSO_en.languageDictionarys.Add(key,value_en);
                            languageSO_jp.languageDictionarys.Add(key,value_jp);
                        }
                }
            }
            string json_cn = JsonConvert.SerializeObject(languageSO_cn);
            string json_en = JsonConvert.SerializeObject(languageSO_en);
            string json_jp = JsonConvert.SerializeObject(languageSO_jp);
            // 将JSON字符串保存到文件
            File.WriteAllText(Application.streamingAssetsPath + "/LanguageDictionary_CN.json", json_cn);
            File.WriteAllText(Application.streamingAssetsPath + "/LanguageDictionary_EN.json", json_en);
            File.WriteAllText(Application.streamingAssetsPath + "/LanguageDictionary_JP.json", json_jp);
        }
    }
}
