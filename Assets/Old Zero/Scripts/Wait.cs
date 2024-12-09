using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Wait : MonoBehaviour
{
    void Start()
    {
        Invoke("change", 2);
    }

    void change()
    {
        SceneManager.LoadScene("Prologue");
    }
}
