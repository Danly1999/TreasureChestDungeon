using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    //public GameObject partical;
    //public GameObject diePartical;
    //public GameObject PaPartical;
    //public GameObject BoomPaPartical;
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
            //GameObject par = Instantiate(partical, all[0].transform);
            int enimeID = 1;
            if(isplayers)
            {
                enimeID = all.IndexOf(enimes[0]);
            }else
            {
                enimeID = all.IndexOf(players[0]);
            }
            
            SetEnime setEnimeAct = all[0].      GetComponent<SetEnime>();
            SetEnime setEnimeDef = all[enimeID].GetComponent<SetEnime>();
            //GameObject die = null;

            all[0].GetComponent<RectTransform>().localScale *= 1.3f;
            setEnimeAct.particle.SetActive(true);
            EnimeSO enimeSOAct = setEnimeAct.enimeSO;
            EnimeSO enimeSODef = setEnimeDef.enimeSO;
            float crit = enimeSOAct.crit>Random.Range(0f,100f)?2:1;
            float hit = Mathf.Max(enimeSOAct.act-enimeSODef.def,0)*crit/enimeSODef.hp;
            Debug.Log(hit);
            if(all[enimeID].GetComponentInChildren<Slider>().value-hit <= 0)
            {
                //die = Instantiate(diePartical, all[enimeID].transform);
                setEnimeDef.die.SetActive(true);
            }
            all[enimeID].GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(0.6f);//µôÑªÊ±
            //GameObject pa = Instantiate(PaPartical, all[enimeID].transform);
            setEnimeDef.text.SetActive(true);
            setEnimeDef.text.GetComponent<TextMeshProUGUI>().text = "-" + (int)Mathf.Min(hit * 100,100) + "%";
            if (crit == 2)
            {
                setEnimeDef.text.GetComponent<TextMeshProUGUI>().color = Color.red;
            }else
            {
                setEnimeDef.text.GetComponent<TextMeshProUGUI>().color = Color.black;
            }
            setEnimeDef.pa.SetActive(true);
            //GameObject BoomPa = null;
            if(crit == 2)
            {
                //BoomPa = Instantiate(BoomPaPartical, all[enimeID].transform);
                setEnimeDef.boomPa.SetActive(true); 
            }
            all[enimeID].GetComponentInChildren<Slider>().value -= hit;
            yield return new WaitForSeconds(0.6f);
            all[enimeID].GetComponent<Animator>().enabled = false;
            all[enimeID].GetComponent<Image>().color = Color.white;
            setEnimeAct.particle.SetActive(false);
            
            //Destroy(par);
            all[0].GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            yield return new WaitForSeconds(0.2f);
            //Destroy(pa);
            setEnimeDef.text.SetActive(false);
            setEnimeDef.pa.SetActive(false);
            if(crit == 2)
            {
                //Destroy(BoomPa);
                setEnimeDef.boomPa.SetActive(false);
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
                //Destroy(die);
                setEnimeDef.die.SetActive(false);
                all.Remove(all[enimeID]);
            }
            if(all[0]!=null)
            {
                GameObject obj = all[0];
                all.Remove(all[0]);
                all.Add(obj);

            }
            if (players.Count == 0)
            {
                blackGround.SetActive(false);
                returnButton.onClick.Invoke();
                 yield return null;
            }
        }
        pass[GroupID].SetActive(true);
        if(pass.Length-1>GroupID)
        {
            pass[GroupID+1].SetActive(false);
            PlayerData.instance.goldQuantity += 20*(PlayerData.instance.fightSOID+1)/2;
            chestSO.SetGoldRise();
        }else
        {
            //change scene;
            pass[0].SetActive(false);
            PlayerData.instance.goldQuantity += 80*(PlayerData.instance.fightSOID+1)/2;
            PlayerData.instance.fightSOID = Mathf.Min(PlayerData.instance.fightSOID+1,chestSO.fightSOs.Length-1);
            chestSO.SetGoldRise();
            chestSO.ResetEnimeGroupRise();
        }
        blackGround.SetActive(false);
        returnButton.onClick.Invoke();


    }

}
