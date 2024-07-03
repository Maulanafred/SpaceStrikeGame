using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextStage : MonoBehaviour
{
    public GameObject nextstage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            nextstage.SetActive(true);
            StartCoroutine(NextLagi());
            

        }
    }

    IEnumerator NextLagi(){
        yield return new WaitForSeconds(5f);
        LoadingScene.instance.LoadNewGame(2);
        AudioManager.instance.StopBGM(1);
        AudioManager.instance.PlayBGM(2);


    }
}
