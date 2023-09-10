using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnyKeyDestory : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKey)
        {
            canvas.sortingLayerName = "Default";
            Destroy(gameObject);
        }
    }
}
