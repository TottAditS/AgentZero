using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabControl : MonoBehaviour
{
    public Transform detect;
    public Transform holder;
    public float raydist;
    private bool full;
    private GameObject bawaan;

    void Start()
    {
        full = false;
    }
    void Update()
    {
        RaycastHit2D grabcek = Physics2D.Raycast(detect.position, Vector2.right * transform.localScale, raydist);

        if (grabcek.collider != null && grabcek.collider.tag == "Object")
        {
            if (Input.GetKeyDown(KeyCode.G) && full == false)
            {
                grabcek.collider.gameObject.transform.parent = holder;
                grabcek.collider.gameObject.transform.position = holder.position;
                grabcek.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabcek.collider.isTrigger = true;
                full = true;
                Debug.Log("angkat");
            }

            else if (Input.GetKeyDown(KeyCode.G) && full != false)
            {
                grabcek.collider.gameObject.transform.parent = null;
                grabcek.collider.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabcek.collider.isTrigger = false;
                full = false;
                Debug.Log("turun");
            }
        }
    }
}
