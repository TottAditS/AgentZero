using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private float horizontal;
    public float jumppower;
    public float speed;
    private bool isfacingright = true;
    public Animator animator;
    public AudioSource audiosorce;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundcek;
    [SerializeField] private LayerMask groundlayer;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(horizontal));

        //if (Mathf.Abs(horizontal) > 0)
        //{
        //    audiosorce.loop = true;
        //    audiosorce.Play();
        //}
        //else
        //{
        //    audiosorce.Stop();
        //    audiosorce.loop = false;
        //}

        flip();

        if (Input.GetKeyDown(KeyCode.Space) && isground())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
        }

        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isground()
    {
        return Physics2D.OverlapCircle(groundcek.position, 0.2f, groundlayer);
    }

    private void flip()
    {
        if (isfacingright && horizontal < 0f || !isfacingright && horizontal > 0f)
        {
            isfacingright = !isfacingright;
            Vector3 localscale = transform.localScale;
            localscale.x *= -1f;
            transform.localScale = localscale;
        }
    }
}
