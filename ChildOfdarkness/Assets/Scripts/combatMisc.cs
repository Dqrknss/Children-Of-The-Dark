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
            
            
                Player.GetComponent<Animator>().SetBool("NormHit", true);
            
        }

        if (KeyItemHeld == true)
        {
            Overhead.SetActive(true);
        }
        else if (KeyItemHeld != true)
        {
            Overhead.SetActive(false);
        }

        AnimatorStateInfo stateInfo = Player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("PlayerAttack") && stateInfo.normalizedTime >= 1f)
        {
            
        }

        if (Input.GetButton("Fire2"))
        {
            
        }
        if (!Input.GetButton("Fire2"))
        {
            
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
