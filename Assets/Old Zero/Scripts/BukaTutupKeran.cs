using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BukaTutupKeran : MonoBehaviour
{
    public GameObject air_partikel;
    public Transform kerandimana;
    public Transform kerandimana2;
    public Transform kerandimana3;

    public void ngalir()
    {
        Instantiate(air_partikel, kerandimana);
        Instantiate(air_partikel, kerandimana2);
        Instantiate(air_partikel, kerandimana3);
    }

    public void bukakeran()
    {
        ngalir();
        ngalir();
        ngalir();
        ngalir();
        ngalir();
    }
}
