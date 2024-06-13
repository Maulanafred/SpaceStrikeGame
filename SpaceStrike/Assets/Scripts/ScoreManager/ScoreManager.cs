using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score;

    public TMP_Text textscore;





    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        textscore.text = score.ToString();
    
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int amount)
    {
        score += amount;
        textscore.text = score.ToString();
    }
}

