using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buangsampah : MonoBehaviour
{
    public bool buang;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trashcan"))
        {
            Invoke("buangin", 0.5f);
            buang = true;
        }
    }

    public void buangin()
    {
        Destroy(gameObject);
    }
}
