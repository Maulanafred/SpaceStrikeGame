
using UnityEngine;
using TMPro;




public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public TMP_Text scoretext;




    // Start is called before the first frame update
    void Start()
    {

        instance = this;
        scoretext.text = score.ToString();
    }

    // Update is called once per frame


    public void AddScore(int value){
        score += value;
        scoretext.text = score.ToString();
        Debug.Log("Tidak bisa");
    }
}

