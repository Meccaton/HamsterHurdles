using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public int high;
    public TMP_Text curScore;
    public TMP_Text highScore;

    void Start()
    {
        high = PlayerPrefs.GetInt("high", 0);
        curScore.text = "Score\n" + score;
        highScore.text = "High Score\n" + high;
    }

    void Update()
    {
        
    }

    public void UpdateCurScore()
    {
        score++;
        curScore.text = "Score\n" + score;
        if(score > high)
        {
            high = score;
            highScore.text = "High Score\n" + high;
        }
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetInt("high", high);
        PlayerPrefs.Save();
    }
}
