using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    const int resolutionX = 9;
    const int resolutionY = 16;
    public static bool isPaused;
    public static bool isGameOver;
    
    public Button restartButton;
    public Button returnMainMenuButton;

    void Start()
    {
        float screenRatio = Screen.width*1f / Screen.height;
        float bestRatio = resolutionX*1f / resolutionY;
        if (screenRatio <= bestRatio)
        {
            GetComponent<Camera>().rect = new Rect(0,(1f- screenRatio / bestRatio)/2f, 1, screenRatio / bestRatio);
        }else if(screenRatio > bestRatio)
        {
            GetComponent<Camera>().rect = new Rect((1f- bestRatio / screenRatio) /2f, 0, bestRatio / screenRatio, 1);
        }

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
            //Debug.Log("Esc is pressed!");
            if (isPaused == false) {
                PauseGame();
            } else {
                continueGame();
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
    public void continueGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    } 
    public void StartGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        objectMover.speed = objectMover.initialSpeed;
        objectMover.speedDirection = -1;
        BallController.verticalDirection = -1;
        //enable the scripts again
    }

    public void Reload(){
		//Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("GameScene");
        StartGame();
        isGameOver = false;
	}

    
   
    public void returnMainMenuClicked() {
        Debug.Log("returnMainMenuClicked called!");
        SceneManager.LoadScene("MainMenuScene");
    }

}
