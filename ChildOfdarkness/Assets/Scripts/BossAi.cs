using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAi : MonoBehaviour
{
    public int phase;
    public int location;
    [SerializeField] private int newLoc;
    [SerializeField] private int hp;
    [SerializeField] private int reqhp = 15;
    public int attack;
    public bool attacking;
    public float dura;
    public int oldLoc;
    public bool locChange;
    [SerializeField] private GameObject plr;

    public GameObject DMGBlock;
    public GameObject DMGBlock2;

    public GameObject bossPos1;
    public GameObject bossPos2;
    public GameObject bossPos3;

    // Start is called before the first frame update
    void Start()
    {
        phase = 1;
        attacking = false;
        location = 1;
        hp = gameObject.GetComponent<Health>().hp;
        plr = GameObject.Find("Player");
    }



    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo stateInfo = DMGBlock.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        hp = gameObject.GetComponent<Health>().hp;
        if (attacking == false && dura <= 0)
        {
            attack = Random.Range(1, 3);

            if (attack == 1)
            {
                DMGBlock.SetActive(true);
                DMGBlock.GetComponent<Animator>().SetBool("Slam", true);
                
            }
            if (attack == 2)
            {
                DMGBlock.SetActive(true);
                DMGBlock.GetComponent<Animator>().SetBool("Push", true);
                
            }
            if (attack == 3 && location == 2)
            {
                DMGBlock.SetActive(true);
                gameObject.GetComponent<Health>().Immune = true;
                DMGBlock.GetComponent<Animator>().SetBool("Nova", true);
            }
        }

        if (hp <= reqhp)
        {
            locChange = true;
            oldLoc = location;
            DMGBlock.SetActive(true);
            gameObject.GetComponent<Health>().Immune = true;
            DMGBlock.GetComponent<Animator>().SetBool("Nova", true);
            newLoc = Random.Range(1, 3);
            if (newLoc != location)
            {
                location = newLoc;
                reqhp = (hp - 5);
            }
            if (newLoc == location) newLoc = Random.Range(1, 3);
        }

        if (location == 1)
        {
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x = 1.03016f;
            gameObject.transform.localScale = newScale;
            gameObject.transform.position = bossPos1.transform.position;
        }
        if (location == 2)
        {
            gameObject.transform.position = bossPos2.transform.position;
            if (oldLoc == 1)
            {
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x = -1.03016f;
                gameObject.transform.localScale = newScale;
                gameObject.transform.position = bossPos3.transform.position;
            }
            if (oldLoc == 3)
            {
                Vector3 newScale = gameObject.transform.localScale;
                newScale.x = 1.03016f;
                gameObject.transform.localScale = newScale;
                gameObject.transform.position = bossPos3.transform.position;
            }
        }
        if (location == 3)
        {
            Vector3 newScale = gameObject.transform.localScale;
            newScale.x = -1.03016f;
            gameObject.transform.localScale = newScale;
            gameObject.transform.position = bossPos3.transform.position;
        }

        if (stateInfo.IsName("BossSlam") && stateInfo.normalizedTime >= 1f)
        {
            DMGBlock.GetComponent<Animator>().SetBool("Slam", false);
            DMGBlock.SetActive(false);
            dura = 2.5f;
        }
        if (stateInfo.IsName("BossPush") && stateInfo.normalizedTime >= 1f)
        {
            DMGBlock.GetComponent<Animator>().SetBool("Push", false);
            DMGBlock.SetActive(false);
            dura = 3f;
        }
        if (stateInfo.IsName("BossNova") && stateInfo.normalizedTime >= 1f)
        {
            gameObject.GetComponent<Health>().Immune = false;

            if (locChange != true)
            {
                newLoc = Random.Range(1, 3);
                if (newLoc != location)
                {
                    location = newLoc;
                    reqhp = (hp - 5);
                }
                if (newLoc == location) newLoc = Random.Range(1, 3);
                DMGBlock.GetComponent<Animator>().SetBool("Nova", false);
                DMGBlock.SetActive(false);
                dura = 8f;
            }
            else
            {
                locChange = false;
                DMGBlock.GetComponent<Animator>().SetBool("Nova", false);
                DMGBlock.SetActive(false);
                dura = 8f;
            }
            
        }

        dura -= Time.deltaTime;
    }
}