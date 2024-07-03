using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score;
    public TMP_Text scoreText;

    void Start()
    {
        instance = this;
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            // Reset score to 0 when starting Level1
            score = 0;
            PlayerPrefs.SetInt("Score", score); // Save score to PlayerPrefs (optional)
            PlayerPrefs.Save(); // Save changes immediately (optional)
        }
        else
        {
            // Load score from PlayerPrefs for other levels
            score = PlayerPrefs.GetInt("Score", 0);
        }
        
        // Update score text
        scoreText.text = score.ToString();
    }

    void Update()
    {
        // Example: Add score when some action happens (for testing)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddScore(10);
        }
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("Score", score); // Save score to PlayerPrefs
        PlayerPrefs.Save(); // Save changes immediately
    }
}
