using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public int phase;
    public int location;
    private int hp;
    private int currenthp;
    public int attack;
    public bool attacking;
    public float dura;

    public GameObject DMGBlock;

    public GameObject bossPos1;
    public GameObject bossPos2;
    public GameObject bossPos3;

    // Start is called before the first frame update
    void Start()
    {
        phase = 1;
        attacking = false;
        location = 3;
        hp = gameObject.GetComponent<Health>().hp;
    }



    // Update is called once per frame
    void Update()
    {
        if (attacking == false && dura <= 0)
        {
            attack = Random.Range(1, 3);

            if (attack == 1)
            {
                DMGBlock.SetActive(true);
                DMGBlock.GetComponent<Animator>().SetBool("Slam", true);
                dura = 2.5f;
            }
            if (attack == 2)
            {
                DMGBlock.SetActive(true);
                DMGBlock.GetComponent<Animator>().SetBool("Push", true);
                dura = 3f;
            }
            if (attack == 3 && location == 2)
            {
                DMGBlock.SetActive(true);
                DMGBlock.GetComponent<Animator>().SetBool("Nova", true);
                dura = 8f;
            }
        }

        if (location == 1)
        {
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x = -4;
            gameObject.transform.localScale = newScale;
            gameObject.transform.position = bossPos1.transform.position;
        }
        if (location == 3)
        {
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x = 4;
            gameObject.transform.localScale = newScale;
            gameObject.transform.position = bossPos3.transform.position;
        }

        AnimatorStateInfo stateInfo = DMGBlock.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("BossSlam") && stateInfo.normalizedTime >= 1f)
        {
            DMGBlock.GetComponent<Animator>().SetBool("Slam", false);
            DMGBlock.SetActive(false);
        }
        if (stateInfo.IsName("BossPush") && stateInfo.normalizedTime >= 1f)
        {
            DMGBlock.GetComponent<Animator>().SetBool("Push", false);
            DMGBlock.SetActive(false);
        }
        if (stateInfo.IsName("BossNova") && stateInfo.normalizedTime >= 1f)
        {
            DMGBlock.GetComponent<Animator>().SetBool("Nova", false);
            DMGBlock.SetActive(false);
        }

        dura -= Time.deltaTime;
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