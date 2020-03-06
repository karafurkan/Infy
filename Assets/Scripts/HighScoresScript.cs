using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresScript : MonoBehaviour
{
    
    public Button backButton;
    public Text highScoreText;
    public ArrayList highScores = new ArrayList();

    void Start()
    {
        int i;
        highScoreText.text = "HIGHSCORES";
        string scoreString = "score";
        for(i=0;i<10;++i)
        {
            if(PlayerPrefs.HasKey(scoreString+i))
            {
                highScores.Add(PlayerPrefs.GetInt(scoreString + i));
            }
            else
            {
                break;
            }
        }
        highScores.Sort();
        highScores.Reverse();
        foreach(int score in highScores)
        {
            highScoreText.text = highScoreText.text + "\n" + score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButtonClicked() {
        SceneManager.LoadScene("MainMenuScene");
    }

}
