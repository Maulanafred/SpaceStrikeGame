using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManagementMainMenu : MonoBehaviour

{

    public GameObject[]  uiDisplay;

    public GameObject options;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void ShowUI (int index){
        for(int i = 0 ; i < uiDisplay.Length;i++ ){
            uiDisplay[i].SetActive(index == i);
        }
    }
        

    public void NewGame()
    {
        LoadingScene.instance.LoadNewGame(1);
    }

    public void ShowAbout(){
        options.SetActive(true);
        ShowUI(2);
    }

    public void ShowOptions(){
        options.SetActive(true);
        ShowUI(1);
    }

    public void ShowHowToPlay(){
        options.SetActive(true);
        ShowUI(0);
    }

    public void BackMainMenu(){
        options.SetActive(false);

    }
    

    //fungsi untuk load scene 


    
}
