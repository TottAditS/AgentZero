using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

    private bool jumpPressed = false;
    private bool uiInputActive = false;
    public bool isButtonPressed = false;

    // Fungsi untuk gerakan kiri dan kanan berdasarkan tombol UI
    public void MoveLeft()
    {
        uiInputActive = true;
        horizontal = -1f;
    }

    public void MoveRight()
    {
        horizontal = 1f; // Gerak kanan
        uiInputActive = true;
    }
    public void StopMove()
    {
        horizontal = 0f; // Berhenti gerak
    }
    public void Jump()
    {
        jumpPressed = true;
    }

    void Update()
    {
        if (!uiInputActive)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            uiInputActive = false; // Reset UI input state after one frame
        }

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

        if ((Input.GetKeyDown(KeyCode.Space) || jumpPressed) && isground())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumppower);
            jumpPressed = false; // Reset jump state
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
