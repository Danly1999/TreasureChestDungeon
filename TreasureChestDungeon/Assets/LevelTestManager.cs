using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelTestManager : MonoBehaviour
{
    public ChestSO chestSO;
    public TextMeshProUGUI description;
    public TextMeshProUGUI[] equipmentTests;
    public TextMeshProUGUI[] NormalTests;
    public void SetDescriptionTest(int id)
    {
        chestSO.SetTestRise(id,description);
    }
    public void SetNormalTests()
    {
        for (int i = 0; i < equipmentTests.Length; i++)
        {
            chestSO.SetTestRise(5+i,equipmentTests[i]);
        }
        for (int i = 0; i < NormalTests.Length; i++)
        {
            chestSO.SetTestRise(9+i,NormalTests[i]);
        }
    }
    private void OnEnable() {
        chestSO.setDescriptionTestAction += SetDescriptionTest;
        chestSO.setNormalTestAction += SetNormalTests;
    }
    private void OnDisable() {
        chestSO.setDescriptionTestAction -= SetDescriptionTest;
        chestSO.setNormalTestAction -= SetNormalTests;
    }
}
