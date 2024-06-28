using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class Savemenege : MonoBehaviour
{
    public TempatSampah buang;
    public Nameinput nama;
    public Timer waktu;

    public int jumlahpemain = 0;

    public string taronama;
    public int tarojumlah;
    public float tarotimer;

    public TextMeshProUGUI playername;
    public Slider trashslider;
    public TextMeshProUGUI timertext;

    private void Awake()
    {
        jumlahpemain++;
    }

    private void Start()
    {
        load();
    }

    public class PemainSetruk
    {
        public string name;
        public float times;
        public int kebersihan;
    }
    
    public void save()
    {

        //Debug.Log("SAVE");

        PemainSetruk pemain = new PemainSetruk();

        if (SceneManager.GetActiveScene().buildIndex == 1) //MAIN MENU
        {
            //Debug.Log("SAVE 1");

            pemain.name = nama.namaku;

            string fasta = JsonUtility.ToJson(pemain);
            File.WriteAllText(Application.dataPath + "/JanganDibuka.json", fasta);

            Debug.Log(fasta);
            taronama = nama.namaku;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 0) //SCENE PROLOG
        {
            //Debug.Log("SAVE 2");
            pemain.kebersihan = buang.kebersihankita;
            pemain.name = taronama;

            string fasta = JsonUtility.ToJson(pemain);
            File.WriteAllText(Application.dataPath + "/JanganDibuka.json", fasta);

            Debug.Log(fasta);

            tarojumlah = buang.kebersihankita;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 2) //SCENE STAGE1
        {
            //Debug.Log("SAVE 3");

            pemain.kebersihan = buang.kebersihankita;
            pemain.times = waktu.mengalir;
            pemain.name = taronama;

            string fasta = JsonUtility.ToJson(pemain);
            File.WriteAllText(Application.dataPath + "/JanganDibuka.json", fasta);

            Debug.Log(fasta);
        }
    }
    public void load()
    {
        //Debug.Log("LOAD");

        string dataload = File.ReadAllText(Application.dataPath + "/JanganDibuka.json");
        PemainSetruk loaddata = JsonUtility.FromJson<PemainSetruk>(dataload);

        if (SceneManager.GetActiveScene().buildIndex == 0) //load prolog
        {
            //Debug.Log("NLOD RPOLOG");
            Debug.Log(dataload);

            taronama = loaddata.name;
            playername.text = taronama;
        }

        else if (SceneManager.GetActiveScene().buildIndex == 2) //load scene 1
        {
            //Debug.Log("NLOD STAGE1");
            taronama = loaddata.name;
            tarotimer = loaddata.times;
            tarojumlah = loaddata.kebersihan;

            Debug.Log(dataload);

            playername.text = taronama;
            trashslider.value = tarojumlah;
            timertext.text = tarotimer.ToString();
        }

        else if (SceneManager.GetActiveScene().buildIndex == 1) //load menu
        {
            //Debug.Log("NLOD STAGE3");
            taronama = loaddata.name;
            tarotimer = loaddata.times;
            tarojumlah = loaddata.kebersihan;

            Debug.Log(dataload);

            playername.text = taronama;
            trashslider.value = tarojumlah;

            int minutes = Mathf.FloorToInt(tarotimer / 60);
            int seconds = Mathf.FloorToInt(tarotimer % 60);
            float mili = (tarotimer % 1) * 100;

            timertext.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, mili);
        }
    }
}
