using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour
{
    public int Dmg;

    // Start is called before the first frame update
    void Start()
    {
        Dmg = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss" && collision.gameObject.GetComponent<Health>().Immune != true)
        {
            collision.gameObject.GetComponent<Health>().hp -= Dmg;
        }
    }
}
