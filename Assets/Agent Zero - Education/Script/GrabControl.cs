using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabControl : MonoBehaviour
{
    public Transform detect;
    public Transform holder;
    public float raydist;
    public bool full;
    private GameObject bawaan;

    private bool grabPressed = false;

    public void Grab()
    {
        grabPressed = true;
        grabbing();
    }

    void Start()
    {
        full = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            grabPressed = true;
        }
        else
        {
            grabPressed = false;
        }

        //RaycastHit2D grabcek = Physics2D.Raycast(detect.position, Vector2.right * transform.localScale, raydist);

        //if (grabcek.collider != null && grabcek.collider.tag == "Object")
        //{
        //    if (grabPressed && full == false)
        //    {
        //        grabcek.collider.gameObject.transform.parent = holder;
        //        grabcek.collider.gameObject.transform.position = holder.position;
        //        grabcek.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
        //        grabcek.collider.isTrigger = true;
        //        full = true;
        //        //Debug.Log("angkat");
        //    }

        //    else if (grabPressed && full != false)
        //    {
        //        grabcek.collider.gameObject.transform.parent = null;
        //        grabcek.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        //        grabcek.collider.isTrigger = false;
        //        full = false;
        //        //Debug.Log("turun");
        //    }

        //    grabPressed = false; // Reset grabPressed
        //}

        grabbing();
    }
    void grabbing()
    {
        RaycastHit2D grabcek = Physics2D.Raycast(detect.position, Vector2.right * transform.localScale, raydist);

        if (grabcek.collider != null && grabcek.collider.tag == "Object")
        {
            if (grabPressed && full == false)
            {
                grabcek.collider.gameObject.transform.parent = holder;
                grabcek.collider.gameObject.transform.position = holder.position;
                grabcek.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabcek.collider.isTrigger = true;
                full = true;
                //Debug.Log("angkat");
            }

            else if (grabPressed && full != false)
            {
                grabcek.collider.gameObject.transform.parent = null;
                grabcek.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabcek.collider.isTrigger = false;
                full = false;
                //Debug.Log("turun");
            }

            grabPressed = false; // Reset grabPressed
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashcan"))
        {
            full = false;
            //Debug.Log("buang");
        }
    }
}
