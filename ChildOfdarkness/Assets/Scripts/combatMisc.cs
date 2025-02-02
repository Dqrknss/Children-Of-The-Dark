using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatMisc : MonoBehaviour
{
    public bool KeyItemHeld = false;
    public string KeyItemName;
    private GameObject GMObj;
    public GameObject Overhead;
    public GameObject Player;
    public GameObject Sword;
    public Animator anims;

    // Start is called before the first frame update
    void Start()
    {
        GMObj = GameObject.Find("GameManager");
        anims = Sword.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            
               anims.SetBool("NormHit", true);
            
        }

        if (KeyItemHeld == true)
        {
            Overhead.SetActive(true);
        }
        else if (KeyItemHeld != true)
        {
            Overhead.SetActive(false);
        }

        AnimatorStateInfo stateInfo = anims.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("SwordAttackReal") && stateInfo.normalizedTime >= 1f)
        {
           anims.SetBool("NormHit", false);
        }
        if (stateInfo.IsName("SwordBlock") && stateInfo.normalizedTime >= 1f)
        {
           anims.SetBool("TrueBlock", true);
           anims.SetBool("Block", false);
            Player.GetComponent<Health>().Immune = true;
        }

        if (Input.GetButton("Fire2"))
        {
            anims.SetBool("Block", true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Player.GetComponent<Health>().Immune = false;
            anims.SetBool("Block", false);
            anims.SetBool("TrueBlock", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key" && KeyItemHeld == false)
        {
            KeyItemHeld = true;
            KeyItemName = collision.gameObject.name;
            collision.gameObject.transform.position = new Vector2(9999999999999999999, 999999999999999);
        }

        if (collision.gameObject.tag == "TheCore" && KeyItemHeld == true)
        {
            KeyItemHeld = false;
            KeyItemName = "";
            GMObj.GetComponent<GM>().CoreState += 1;
        }
    }
}
