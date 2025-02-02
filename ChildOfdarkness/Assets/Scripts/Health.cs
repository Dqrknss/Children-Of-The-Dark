using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hp;
    private GameObject entity;
    private GameObject respawnPoint;
    public GameObject Fragment;
    private string heldFragment;
    private GameObject PlrFragment;
    public GameObject Border;
    public bool Immune;

    // Start is called before the first frame update
    void Start()
    {
        entity = gameObject;
        respawnPoint = GameObject.Find("RespawnPoint");

        if (entity.tag == "Player")
        {
            hp = 5;
        }
        else if (entity.tag == "Enemy")
        {
            hp = 2;
        }
        else if (entity.tag == "Boss")
        {
            hp = 20;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            if (entity.tag == "Player")
            {
                heldFragment = entity.GetComponent<combatMisc>().KeyItemName;
               if (GameObject.Find(heldFragment))
                {
                    GameObject.Find(heldFragment).transform.position = entity.transform.position;
                }
                entity.GetComponent<combatMisc>().KeyItemName = "";
                entity.GetComponent<combatMisc>().KeyItemHeld = false;

                entity.transform.position = respawnPoint.transform.position;
                hp = 5;
            }
            else if (entity.tag == "Enemy")
            {
                Destroy(entity);
            }
            else if (entity.tag == "Boss")
            {
                Fragment.SetActive(true);
                Fragment.transform.position = entity.transform.position;
                Border.SetActive(false);
                Destroy(entity);
            }
        }
    }
}
