using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatMisc : MonoBehaviour
{
    public bool KeyItemHeld = false;
    private string KeyItemName;
    private GameObject GMObj;
    public GameObject Overhead;
    public GameObject Sword;
    public GameObject Player;

    public AnimationClip normHit;
    public AnimationClip upHit;
    public AnimationClip downHit;

    // Start is called before the first frame update
    void Start()
    {
        GMObj = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Player.GetComponent<movement>().isGrounded == false && Input.GetKey(KeyCode.S))
            {
                Sword.GetComponent<Animator>().SetBool("DownHit", true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                Sword.GetComponent<Animator>().SetBool("UpHit", true);
            }
            else
            {
                Sword.GetComponent<Animator>().SetBool("NormHit", true);
            }
        }

        if (KeyItemHeld == true)
        {
            Overhead.SetActive(true);
        }
        else if (KeyItemHeld != true)
        {
            Overhead.SetActive(false);
        }

        AnimatorStateInfo stateInfo = Sword.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Player_Melee_Attack") && stateInfo.normalizedTime >= 1f)
        {
            Sword.GetComponent<Animator>().SetBool("NormHit", false);
        }
        if (stateInfo.IsName("Sword_UpHit") && stateInfo.normalizedTime >= 1f)
        {
            Sword.GetComponent<Animator>().SetBool("UpHit", false);
        }
        if (stateInfo.IsName("sword_DownHit") && stateInfo.normalizedTime >= 1f)
        {
            Sword.GetComponent<Animator>().SetBool("DownHit", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key" && KeyItemHeld == false)
        {
            KeyItemHeld = true;
            KeyItemName = collision.gameObject.name;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "TheCore" && KeyItemHeld == true)
        {
            KeyItemHeld = false;
            GMObj.GetComponent<GM>().CoreState += 1;
        }
    }
}
