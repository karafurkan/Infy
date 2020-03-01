using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    bool isPaused;
    public static bool isGameOver;

    public Button restartButton;
    public Button returnMainMenuButton;

    void Start()
    {
        isGameOver = false;
        isPaused = false;
        restartButton.gameObject.SetActive(false);
        returnMainMenuButton.gameObject.SetActive(false);
        StartGame();
    }
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Escape)) 
        {
            Debug.Log("Esc is pressed!");
            if (isPaused == false) {
                PauseGame();
            } else {
                StartGame();
            }
        }  
        if (isGameOver == true) {          ///////// Bunu burada yapmak yerine aşağıda gameOver fonksiyonu yazıp CollisionController'de oyuncu yandığı zaman çağır
            restartButton.gameObject.SetActive(true);
            returnMainMenuButton.gameObject.SetActive(true);
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        //Disable scripts that still work while timescale is set to 0
    } 
    public void StartGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        //enable the scripts again
    }

    public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
        StartGame();
        isGameOver = false;
	}

    
   
    public void returnMainMenuClicked() {
        Debug.Log("returnMainMenuClicked called!");
        SceneManager.LoadScene("MainMenuScene");
    }

}
