using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class GameSence : MonoBehaviour
{
    public ChestSO chestSO;
    public FightSO fightSO;
    public GameObject[] enimeGroup;
    List<EnimeSO[]> enimeSOs = new List<EnimeSO[]>();
    public GameObject fightBlackGround;

public void RiseFightBlackGround()
{
    fightBlackGround.SetActive(true);
}
    private void Start()
    {
        chestSO.SetEnimeSpriteRise();
    }
    private void OnEnable() {
    chestSO.fightBlackGroundAction += RiseFightBlackGround;
    enimeSOs.Add(fightSO.enimeSOs00);
    enimeSOs.Add(fightSO.enimeSOs01);
    enimeSOs.Add(fightSO.enimeSOs02);
    enimeSOs.Add(fightSO.enimeSOsBoss);
    for (int i = 0; i < enimeGroup.Length; i++)
    {
        enimeGroup[i].GetComponent<EnimeGroup>().enimeSOs = enimeSOs[i];
    }
       
}
private void OnDisable() {
    chestSO.fightBlackGroundAction -= RiseFightBlackGround;
}
}
