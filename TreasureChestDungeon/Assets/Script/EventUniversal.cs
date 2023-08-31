using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventUniversal : MonoBehaviour
{
    public ChestSO chestSO;
    public UnityEvent unityEvent;
    public UnityEvent checkEvent;
    private void OnEnable() {
        chestSO.action += eve;
        chestSO.checkAction += checkChest;
    }
    private void OnDisable() {
        chestSO.action -= eve;
    }
    private void eve()
    {
        unityEvent.Invoke();
    }
    private void checkChest()
    {   
        float range = Random.Range(0f,1f);
        for (int i = chestSO.levels.Length-1; i > 0; i--)
        {
            Debug.Log(chestSO.levels[i]);
            if(range<=chestSO.levels[i])
            {
                checkEvent.Invoke();
                Debug.Log(chestSO.levels[i]);
                break;
            }
        }
    }

}
