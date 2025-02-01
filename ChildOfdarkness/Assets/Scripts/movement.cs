using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;

    private float MoveSpeed = 10f;
    private float Jump = 0f;
    private float xAxis = 0f;
    public bool isGrounded;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xAxis = Input.GetAxisRaw("Horizontal");
        Jump = Input.GetAxisRaw("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = true;
    }

    private void FixedUpdate()
    {
        rb.velocity += new Vector2(xAxis, 0f).normalized * MoveSpeed * Time.fixedDeltaTime;

        if (Jump >= 1 && isGrounded == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, (Jump * 7f));
            isGrounded = false;
        }
    }
}
