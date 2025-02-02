using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpBack : MonoBehaviour
{
    GameObject respawn;

    private void Start()
    {
        respawn = GameObject.Find("RespawnPoint");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = respawn.transform.position;
        }
    }
}
