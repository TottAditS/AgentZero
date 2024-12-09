using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Nameinput : MonoBehaviour
{
    public InputField input;
    public string namaku;
    public Savemenege saveme;
    [SerializeField] public string inputext;

    public void narobaliknama()
    {
        input.text = namaku;
    }
    public void grabinput(string input)
    {
        inputext = input;
        namaku = inputext;
        //Debug.Log("NAMAKU : " + namaku);
    }
}
