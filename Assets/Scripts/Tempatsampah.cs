using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempatSampah : MonoBehaviour
{
    public int kebersihankita;
    public Savemenege saveme;
    public Slider trashilder;

    private void Start()
    {
        saveme.load();
        kebersihankita = saveme.tarojumlah;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Object"))
        {
            kebersihankita++;
            trashilder.value = kebersihankita;
            saveme.save();
        }
    }
}
