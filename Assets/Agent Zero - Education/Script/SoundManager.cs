using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioMixer audioMixer;
    public string masterVolumeParameter = "MasterVolume";

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetMasterVolume(float volume)
    {
        float mixerVolume = Mathf.Log10(volume) * 20;
        audioMixer.SetFloat(masterVolumeParameter, mixerVolume);
    }
}
