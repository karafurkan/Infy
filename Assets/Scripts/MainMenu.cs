using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using System.Windows.Forms;

public class MainMenu : MonoBehaviour
{
    public Button startGameButton;
    public Button highScoresButton;
    public Button creditsButton;
    public Button howToPlayButton;

    public Image play_image;
    public Image highscore_image;

    public Sprite play_english;
    public Sprite play_turkish;
    public Sprite highscore_english;
    public Sprite highscore_turkish;

    private string language;

    void Start()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            language = PlayerPrefs.GetString("language");
            if(language == "tr")
            {
                toTurkish();
            }
            else
            {
                toEnglish();
            }
        }
        else
        {
            PlayerPrefs.SetString("language", "en");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void startGameButtonClicked() {
        GameController.isGameOver = false;
        SceneManager.LoadScene("GameScene");
    }

    public void highScoresButtonClicked() {
        SceneManager.LoadScene("HighScoresScene");
    }

    
    public void creditsButtonClicked() {
        SceneManager.LoadScene("CreditsScene");
    }

    public void howToPlayButtonClicked() {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void toEnglish()
    {
        PlayerPrefs.SetString("language", "en");
        play_image.sprite = play_english;
        highscore_image.sprite = highscore_english;
    }
    
    public void toTurkish()
    {
        PlayerPrefs.SetString("language", "tr");
        play_image.sprite = play_turkish;
        highscore_image.sprite = highscore_turkish;
    }
}