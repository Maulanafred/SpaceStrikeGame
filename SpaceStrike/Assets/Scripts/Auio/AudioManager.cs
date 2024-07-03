using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioMixer audioMixer;

    public AudioSource[] bgMusic;

    public AudioSource[] sfx;

    public 
    // Start is called before the first frame update
    void Start()
    {
        if(instance != null){
            Destroy(this.gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(this.gameObject);

        }
        // biar ga hilang
        

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

    public void PlayBGM(int i){
        
        bgMusic[i].Play();
    }

    public void StopBGM(int i){
        
        bgMusic[i].Stop();
    }
}
