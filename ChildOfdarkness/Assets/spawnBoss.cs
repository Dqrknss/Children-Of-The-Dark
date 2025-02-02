using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBoss : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Border;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
            Boss.SetActive(true);
            Border.SetActive(true);
        }
    }
}
