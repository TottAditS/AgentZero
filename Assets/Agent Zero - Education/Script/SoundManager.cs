using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioMixer audioMixer;
    public string masterVolumeParameter = "MasterVolume";
    public AudioClip mainMenuBGM;
    private AudioSource bgmSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            bgmSource = gameObject.AddComponent<AudioSource>();
            bgmSource.loop = true;
            bgmSource.playOnAwake = false;  
            bgmSource.clip = mainMenuBGM;
            bgmSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (!bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }

    public void SetMasterVolume(float volume)
    {
        float mixerVolume = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat(masterVolumeParameter, mixerVolume);
    }

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    public void StartBGM()
    {
        if (bgmSource.clip != null && !bgmSource.isPlaying)
        {
            bgmSource.Play();
        }
    }

}
