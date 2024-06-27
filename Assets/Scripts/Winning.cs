using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    public GameObject player;
    public GameObject winpanel;
    public ButtonScript scriptbut;
    public Savemenege saveme;
    public Slider lifeslide;
    private float life = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PintuKemenangan"))
        {
            saveme.save();
            winpanel.SetActive(true);
            scriptbut.pause();
        }

        if (collision.gameObject.CompareTag("PintuKemajuan"))
        {
            saveme.save();
            SceneManager.LoadScene("Stage1");
            
        }

        if (collision.gameObject.CompareTag("banjir"))
        {
            Debug.Log("kena air");
            if (life > 0)
            {
                life -= Time.deltaTime;
                lifeslide.value = life;
            }

            else
            {
                saveme.save();
                winpanel.SetActive(true);
                scriptbut.pause();
            }
        }
    }
}
