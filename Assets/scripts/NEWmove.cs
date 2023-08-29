using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWmove : MonoBehaviour
{
    private float horizontal;
    public float speed = 0f;
    public float jumpingPower = 0f;
    private bool isFacingRight = true;
    public GameObject ui;
    public GameObject player;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private void Start()
    {
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            player.GetComponent<Animator>().SetInteger("Event",0);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.5f);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal*speed,rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag=="Enemy")
        {
            ui.SetActive(true);
            player.GetComponent<Animator>().SetInteger("Event",3);
        }
    }
}
