using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManagementMainMenu : MonoBehaviour

{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGame()
    {
        LoadingScene.instance.LoadNewGame(1);
    }

    //fungsi untuk load scene 


    
}
