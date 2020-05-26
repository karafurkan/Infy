using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Net;
using System;
using UnityEngine.Networking;

public class GameController : MonoBehaviour
{
    public static bool isPaused;
    public static bool isGameOver;
    
    public Button restartButton;
    public Button returnMainMenuButton;
    public Button resumeButton;
    public Image menuBackground;
    public Image pausedText;
    public Image blurImage;

    public GameObject[] GameOverArray = new GameObject[12];
    

    public Text backgroundScoreText;
    public int highScore;

    public Button PauseButton;

    private const string API_KEY = "PrGvxpGqaHhRUWSxh70zq43ExqhIXhhW";

    void Start()
    {
        isGameOver = false;
        isPaused = false;
        restartButton.gameObject.SetActive(false);
        returnMainMenuButton.gameObject.SetActive(false);
        menuBackground.gameObject.SetActive(false);
        pausedText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        returnMainMenuButton.gameObject.SetActive(false);
        backgroundScoreText.gameObject.SetActive(false);
        foreach (GameObject go in GameOverArray)
        {
            go.gameObject.SetActive(false);
        }

        if (PlayerPrefs.HasKey("score"))
        {
            highScore = PlayerPrefs.GetInt("score");
        }
        else
        {
            highScore = 0;
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
        }
    }

    public void ContinueButtonClicked()
    {
        ContinueGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        //resumeButton.transform.position = new Vector3(resumeButton.transform.position.x, 378.2429f, 0);
        //restartButton.transform.position = new Vector3(restartButton.transform.position.x, 311.4257f, 0);
        blurImage.gameObject.SetActive(true);
        menuBackground.gameObject.SetActive(true);
        pausedText.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        returnMainMenuButton.gameObject.SetActive(true);

    } 
    public void ContinueGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        blurImage.gameObject.SetActive(false);
        menuBackground.gameObject.SetActive(false);
        pausedText.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        returnMainMenuButton.gameObject.SetActive(false);
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
        if(Score.score > highScore)
        {
            PlayerPrefs.SetInt("score", (int)Score.score);
            highScore = (int)Score.score;
            if (PlayerPrefs.HasKey("player_name") && (Application.internetReachability != NetworkReachability.NotReachable))
            {
                List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
                UnityWebRequest www = UnityWebRequest.Post(String.Format("http://infy-app.herokuapp.com/api/score?name={0}&score={1}&key={2}", PlayerPrefs.GetString("player_name"), highScore, API_KEY),formData);
                www.SendWebRequest();
            }
        }
        /*
        backgroundScoreText.text = "SCORE: " + (int)Score.score;
        menuBackground.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        returnMainMenuButton.gameObject.SetActive(true);
        isPaused = true;
        PauseButton.gameObject.SetActive(false);
        backgroundScoreText.gameObject.SetActive(true);
        Time.timeScale = 0;
        */

        blurImage.gameObject.SetActive(true);
        foreach(GameObject go in GameOverArray)
        {
            go.gameObject.SetActive(true);
        }
        GameOverArray[6].GetComponent<Text>().text = ((int)Score.score).ToString();
        GameOverArray[9].GetComponent<Text>().text = highScore.ToString();
        isPaused = true;
        Time.timeScale = 0;
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
