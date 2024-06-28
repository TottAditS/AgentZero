using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Stordata : MonoBehaviour
{
    public Savemenege saveme;

    public string taronama;
    public int tarojumlah;
    public float tarotimer;

    public TextMeshProUGUI playername;
    public Slider trashslider;
    public TextMeshProUGUI timertext;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex != 1)
        {
            melakukanload();
        }
    }

    private void Update()
    {
        
    }

    public void melakukansave()
    {
        Debug.Log("BODOLAH LAKUINSAVE");
        taronama = saveme.nama.namaku;
        tarojumlah = saveme.buang.kebersihankita;
        tarotimer = saveme.waktu.mengalir;

        Debug.Log("ngesave");
        Debug.Log(taronama);
        Debug.Log(tarojumlah);
        Debug.Log(tarotimer);
    }
    public void melakukanload()
    {
        Debug.Log("BODOLAH LAKUINLOAD");
        playername.text = taronama;
        trashslider.value = tarojumlah;
        timertext.text = tarotimer.ToString();

        Debug.Log("ngeload");
        Debug.Log(taronama);
        Debug.Log(tarojumlah);
        Debug.Log(tarotimer);
    }
}
