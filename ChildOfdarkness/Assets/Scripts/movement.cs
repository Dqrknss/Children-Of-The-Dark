using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private GameObject orb;
    private Animator anism;

    private float MoveSpeed = 10f;
    private float Jump = 0f;
    private float xAxis = 0f;
    public bool isGrounded;
    private string direction = "Right";

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        orb = GameObject.Find("FragmentOverhead");
        anism = player.GetComponent<Animator>();
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetAxisRaw("Jump");

        if (xAxis != 0)
        {
            anism.SetInteger("MoveSpeed", 1);
        }
        else
        {

            anism.SetInteger("MoveSpeed", 0);
        }

        if (Input.GetKey(KeyCode.A) && direction != "Left")
        {
            direction = "Left";
            orb.GetComponent<SpriteRenderer>().flipX = true;
            Vector3 newScale = player.transform.localScale;
            newScale.x *= -1;
            player.transform.localScale = newScale;
        }
        if (Input.GetKey(KeyCode.D) && direction != "Right")
        {
            direction = "Right";
            orb.GetComponent<SpriteRenderer>().flipX = false;
            Vector3 newScale = player.transform.localScale;
            newScale.x *= -1;
            player.transform.localScale = newScale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = false;
    }

    private void FixedUpdate()
    {
        rb.velocity += new Vector2(xAxis, 0f).normalized * MoveSpeed * Time.fixedDeltaTime;

        if (Jump >= 1 && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, (Jump * 7f));
        }
    }
}
