using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightLoop : MonoBehaviour
{
    public int GroupID;
    public ChestSO chestSO;
    public Button returnButton;
    public GameObject[] pass;
    public GameObject blackGround;
    public GameObject playersGroup;
    public GameObject enimesGroup;
    public GameObject partical;
    public GameObject diePartical;
    public GameObject PaPartical;
    public GameObject BoomPaPartical;
    public List<GameObject> players;
    public List<GameObject> enimes;
    public List<GameObject> all;
    private void OnEnable() {
        players = playersGroup.GetComponent<FightGroup>().enimes;
        enimes  = enimesGroup. GetComponent<FightGroup>().enimes;
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        all = new List<GameObject>();
        int maxCount = Mathf.Max(players.Count,enimes.Count);
        for (int i = 0; i < maxCount; i++)
        {
            if(players.Count > i)
            {
                all.Add(players[i]);
            }
            if(enimes.Count > i)
            {
                all.Add(enimes[i]);
            }

        }
        while (players.Count != 0 || enimes.Count != 0)
        {
            if(players.Count == 0)
            {
                break;
            }
            if(enimes.Count == 0)
            {
                break;
            }
            bool isplayers = players.Contains(all[0]);
            all[0].GetComponent<RectTransform>().localScale *= 1.3f;
            GameObject par = Instantiate(partical, all[0].transform);
            int enimeID = 1;
            if(isplayers)
            {
                while (players.Contains(all[enimeID]))
                {
                    enimeID++;
                }
            }else
            {
                while (enimes.Contains(all[enimeID]))
                {
                    enimeID++;
                }
            }
            
            GameObject die = null;
            EnimeSO enimeAct = all[0].      GetComponent<SetEnime>().enimeSO;
            EnimeSO enimeDef = all[enimeID].GetComponent<SetEnime>().enimeSO;
            float crit = enimeAct.crit>Random.Range(0f,100f)?2:1;
            float hit = Mathf.Max(enimeAct.act-enimeDef.def,0)*crit/enimeDef.hp;
            Debug.Log(hit);
            if(all[enimeID].GetComponentInChildren<Slider>().value-hit <= 0)
            {
                die = Instantiate(diePartical, all[enimeID].transform);
            }
            all[enimeID].GetComponent<Animator>().enabled = true;
            all[enimeID].GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(0.6f);
            GameObject pa = Instantiate(PaPartical, all[enimeID].transform);
            GameObject BoomPa = null;
            if(crit == 2)
            {
                BoomPa = Instantiate(BoomPaPartical, all[enimeID].transform);
            }
            all[enimeID].GetComponentInChildren<Slider>().value -= hit;
            yield return new WaitForSeconds(0.6f);
            all[enimeID].GetComponent<Animator>().enabled = false;
            all[enimeID].GetComponent<Image>().color = Color.white;
            Destroy(par);
            all[0].GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            yield return new WaitForSeconds(0.2f);
            Destroy(pa);
            if(crit == 2)
            {
                Destroy(BoomPa);
            }
            if(all[enimeID].GetComponentInChildren<Slider>().value <= 0)
            {
                if(isplayers)
                {
                    enimes.Remove(all[enimeID]);
                }else
                {
                    players.Remove(all[enimeID]);
                }
                Destroy(all[enimeID]);
                Destroy(die);
                all.Remove(all[enimeID]);
            }
            if(all[0]!=null)
            {
                GameObject obj = all[0];
                all.Remove(all[0]);
                all.Add(obj);

            }
        }
        pass[GroupID].SetActive(true);
        if(pass.Length-1>GroupID)
        {
            pass[GroupID+1].SetActive(false);
        }else
        {
            //change scene;
            PlayerData.instance.fightSOID = Mathf.Min(PlayerData.instance.fightSOID+1,chestSO.fightSOs.Length-1);
            chestSO.ResetEnimeGroupRise();
        }
        blackGround.SetActive(false);
        returnButton.onClick.Invoke();


    }

}
