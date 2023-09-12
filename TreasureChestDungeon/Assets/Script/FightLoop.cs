using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightLoop : MonoBehaviour
{
    public GameObject playersGroup;
    public GameObject enimesGroup;
    public GameObject partical;
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
            all[enimeID].GetComponentInChildren<Slider>().value -= 0.3f;
            all[enimeID].GetComponent<Animator>().enabled = true;
            all[enimeID].GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(1.3f);
            all[enimeID].GetComponent<Animator>().enabled = false;
            all[enimeID].GetComponent<Image>().color = Color.white;
            Destroy(par);
            all[0].GetComponent<RectTransform>().localScale = new Vector3(1,1,1);
            yield return new WaitForSeconds(0.2f);
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
                all.Remove(all[enimeID]);
            }
            if(all[0]!=null)
            {
                GameObject obj = all[0];
                all.Remove(all[0]);
                all.Add(obj);

            }
        }

    }

}
