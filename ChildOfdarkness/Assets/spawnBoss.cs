using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBoss : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Border;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Boss.SetActive(true);
            Border.SetActive(true);
        }
    }
}
