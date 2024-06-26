using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public AudioSource[] bgMusic;

    public AudioSource[] sfx;

    public 
    // Start is called before the first frame update
    void Start()
    {
        // biar ga hilang
        DontDestroyOnLoad(this.gameObject);

        //Load save savean le
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        SetMasterVolume(savedVolume);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // set slider master volumeee
    public void SetMasterVolume(float value){
        audioMixer.SetFloat("master",Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("MasterVolume", value);
        PlayerPrefs.Save();
        
    }

    public void PlaySFX(int i){
        sfx[i].Play();
    }
}
