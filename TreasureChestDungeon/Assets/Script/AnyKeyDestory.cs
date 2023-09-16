using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKeyDestory : MonoBehaviour
{
    public Canvas canvas;
    public ChestSO chestSO;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            if(canvas)
            {
                canvas.sortingLayerName = "Default";
                chestSO.SetBlurRise(false);
            }
            gameObject.SetActive(false);
        }
    }
}
