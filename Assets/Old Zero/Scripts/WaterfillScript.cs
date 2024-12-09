using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kenaairmati : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Waterfill")
        {
            Destroy(gameObject);
        }
    }
}
