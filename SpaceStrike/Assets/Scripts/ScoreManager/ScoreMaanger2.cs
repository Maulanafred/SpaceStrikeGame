using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager2 : MonoBehaviour
{
    public static ScoreManager2 instance;
    public int score;
    public int enemyDefeats;
    public int bonus;
    public float time;

    public int totalScore;

    public TMP_Text timeText;
    public TMP_Text scoreText;
    public TMP_Text enemyDefeatsText;
    public TMP_Text bonusText;
    public TMP_Text totalScoreText;

    void Awake()
    {

    }

    void Start()
    {
        if(instance==null){
            instance = this;
        }

        // Load score, enemy defeats, bonus, and total score from PlayerPrefs for other levels
        score = PlayerPrefs.GetInt("Score", 0);


        // Update score, enemy defeats, bonus, and total score text
        UpdateScoreText();
        UpdateEnemyDefeatsText();
        UpdateBonusText();
        UpdateTotalScoreText();

        // Initialize time
        time = 0f;
        UpdateTimeText();
    }

    void Update()
    {
        // Update time and display it
        time += Time.deltaTime;
        UpdateTimeText();


        // Example: Simulate enemy defeat (for testing)
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnemyDefeated();
        }

        // Example: Simulate bonus (for testing)
        if (Input.GetKeyDown(KeyCode.B))
        {
            AddBonus(50);
        }

        if(time<= 60f)
        {
            bonus =  10000;

        }
        else if(time > 60f && time <= 120F  ){
            bonus =  7000;
        }
        else if(time > 120f){
            bonus = 5000;
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
        UpdateTotalScore();
        PlayerPrefs.SetInt("Score", score); // Save score to PlayerPrefs
        PlayerPrefs.Save(); // Save changes immediately
    }

    public void EnemyDefeated()
    {
        enemyDefeats++;
        AddScore(100); // Example: Add 100 points for each enemy defeated
        UpdateEnemyDefeatsText();
        UpdateTotalScore();
    }

    public void AddBonus(int value)
    {
        bonus += value;
        AddScore(value); // Example: Add bonus value to the score
        UpdateBonusText();
        UpdateTotalScore();
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    void UpdateEnemyDefeatsText()
    {
        enemyDefeatsText.text =  enemyDefeats.ToString();
    }

    void UpdateBonusText()
    {
        bonusText.text = bonus.ToString();
    }

    void UpdateTotalScoreText()
    {
        totalScoreText.text =  totalScore.ToString();
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(time / 60F);
        int seconds = Mathf.FloorToInt(time % 60F);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void UpdateTotalScore()
    {
        totalScore = score + (enemyDefeats * 100) + bonus; // Example calculation
        UpdateTotalScoreText();
    }
}
