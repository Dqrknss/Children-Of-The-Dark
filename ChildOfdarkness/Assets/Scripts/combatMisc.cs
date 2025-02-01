using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combatMisc : MonoBehaviour
{
    public bool KeyItemHeld = false;
    private string KeyItemName;
    private GameObject GMObj;
    public GameObject Overhead;
    
    // Start is called before the first frame update
    void Start()
    {
        GMObj = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyItemHeld == true)
        {
            Overhead.SetActive(true);
        }
        else if (KeyItemHeld != true)
        {
            Overhead.SetActive(false);
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
