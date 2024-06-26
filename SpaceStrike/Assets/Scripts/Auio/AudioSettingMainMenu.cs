using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingMainMenu : MonoBehaviour
{


    public Slider mastervolume;
    private AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        //cari objek 
        audioManager = FindObjectOfType<AudioManager>();


        // set value berdasarkan value sebelumnya
        mastervolume.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);

        // addd listener biar bisa di settings
        mastervolume.onValueChanged.AddListener(audioManager.SetMasterVolume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton(){
        audioManager.PlaySFX(0);
    }


}
