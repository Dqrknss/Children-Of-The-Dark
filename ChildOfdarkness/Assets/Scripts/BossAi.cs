using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public GameObject LightBeam;
    public int phase;
    public int location;
    private int hp;
    private int currenthp;
    public int attack;
    public bool attacking;

    private float duration = 2f;

    public GameObject bossPos1;
    public GameObject bossPos2;
    public GameObject bossPos3;

    // Start is called before the first frame update
    void Start()
    {
        phase = 1;
        attacking = false;
        location = 1;

        attack = 1;
    }



    // Update is called once per frame
    void Update()
    {
        hp = gameObject.GetComponent<Health>().hp;

        if (attack == 1 /*&& location == 1 || location == 3*/)
        {
            LightBeam.SetActive(true);
            attacking = true;
            while (LightBeam.activeInHierarchy == true)
            {
                print("Yippeeee");
            }
        }
    }
}


/*location = Random.Range(1, 3);

if (location == 3)
{
    gameObject.transform.position = bossPos3.transform.position;
    Vector3 newScale = gameObject.transform.localScale;
    newScale.x = -2;
    gameObject.transform.localScale = newScale;
    currenthp = hp;
}
if (location == 2)
{
    gameObject.transform.position = bossPos2.transform.position;
    Vector3 newScale = gameObject.transform.localScale;
    newScale.x = 2;
    gameObject.transform.localScale = newScale;
    currenthp = hp;
}
if (location == 1)
{
    gameObject.transform.position = bossPos1.transform.position;
    Vector3 newScale = gameObject.transform.localScale;
    newScale.x = 2;
    gameObject.transform.localScale = newScale;
    currenthp = hp;
}*/