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

    void Start()
    {
        
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
}