using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour
{
    public int CoreState = 0;
    public GameObject core;

    void Start()
    {
        
    }
    void Update()
    {
        if (CoreState >= 2)
        {
            core.GetComponent<SpriteRenderer>().color = new Color(250, 250, 0, 255);
        }
    }
}
