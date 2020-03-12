using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class GameController : MonoBehaviour
{
    public static bool isPaused;
    public static bool isGameOver;
    
    public Button restartButton;
    public Button returnMainMenuButton;
    public ArrayList highScores = new ArrayList();
    int highScoreIndex;

    public Button PauseButton;

    void Start()
    {
        isGameOver = false;
        isPaused = false;
        restartButton.gameObject.SetActive(false);
        returnMainMenuButton.gameObject.SetActive(false);

        string scoreString = "score";
        for (highScoreIndex = 0; highScoreIndex < 10; ++highScoreIndex)
        {
            if (PlayerPrefs.HasKey(scoreString + highScoreIndex))
            {
                highScores.Add(PlayerPrefs.GetInt(scoreString + highScoreIndex));
            }
            else
            {
                break;
            }
        }

        StartGame();
    }
    void Update()
    {
        /*
        if (isGameOver == true) {          ///////// Bunu burada yapmak yerine aşağıda gameOver fonksiyonu yazıp CollisionController'de oyuncu yandığı zaman çağır
            restartButton.gameObject.SetActive(true);
            returnMainMenuButton.gameObject.SetActive(true);
            PauseGame();
        }
        */
    }

    public void PauseButtonClicked() {
        if (isPaused == false) {
            PauseGame();
        } else {
            ContinueGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    } 
    public void ContinueGame()
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
        Score.score = 0;
        //enable the scripts again
    }

    public void Reload(){
		//Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene("GameScene");
        StartGame();
        isGameOver = false;
	}

    public void GameOver()
    {
        //high score arrangement
        if (highScores.Count > 0)
        {
            if (highScores.Count >= 10) //highScores has 10 elements
            {
                for(int x = 0;x<10;++x)
                {
                    Debug.Log(highScores[x]);
                }
                int minValue = (int)GetMinValue(highScores);
                if (Score.score > minValue)
                {
                    Debug.Log("Min value found: " + minValue + "\nPlayerpref change: score" + highScores.IndexOf(minValue) + "\nhighScores[highScores.IndexOf(minValue)]: " + highScores[highScores.IndexOf(minValue)]);
                    for (int x = 0; x < 10; ++x)
                    {
                        Debug.Log(highScores[x]);
                    }
                    PlayerPrefs.SetInt("score" + highScores.IndexOf(minValue), (int)Score.score);
                    highScores[highScores.IndexOf(minValue)] = (int)Score.score;
                }
            }
            else //highScores has less than 10 elements
            {
                PlayerPrefs.SetInt("score" + highScores.Count, (int)Score.score);
                highScores.Add((int)Score.score);
            }

        }
        else //highScores is empty
        {
            PlayerPrefs.SetInt("score0", (int)Score.score);
            highScores.Add((int)Score.score);
        }
        PlayerPrefs.Save();
        restartButton.gameObject.SetActive(true);
        returnMainMenuButton.gameObject.SetActive(true);
        PauseGame();
        PauseButton.gameObject.SetActive(false);
        

    }
    
   
    public void returnMainMenuClicked() {
        //Debug.Log("returnMainMenuClicked called!");
        SceneManager.LoadScene("MainMenuScene");
    }

    private object GetMinValue(ArrayList arrList)

    {

        ArrayList sortArrayList = new ArrayList(arrList);

        sortArrayList.Sort();

        return sortArrayList[0];

    }

}
