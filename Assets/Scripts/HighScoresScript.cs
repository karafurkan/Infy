using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Net;
using System;
using System.IO;
using UnityEngine.Networking;

public class HighScoresScript : MonoBehaviour
{
    
    public Button backButton;
    public Text highScoreNameText;
    public Text highScoreScoreText;
    public HighScoreInfo highScores;
    public InputField inputField;
    public Button SubmitButton;
    private const string API_KEY = "PrGvxpGqaHhRUWSxh70zq43ExqhIXhhW";

    void Start()
    {
        if(PlayerPrefs.HasKey("player_name"))
        {
            inputField.gameObject.SetActive(false);
            SubmitButton.gameObject.SetActive(false);
            DisplayHighScores();
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButtonClicked() {
        SceneManager.LoadScene("MainMenuScene");
    }

    private HighScoreInfo GetHighScores()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://infy-app.herokuapp.com/api/scores?key={0}",API_KEY));
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        HighScoreInfo highScores = JsonUtility.FromJson<HighScoreInfo>(jsonResponse);

        return highScores;
    }

    private bool CheckPlayerName(string name)
    {
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format("http://infy-app.herokuapp.com/api/player?name={0}&key={1}", name, API_KEY));
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string jsonResponse = reader.ReadToEnd();
            NameInfo nameInfo = JsonUtility.FromJson<NameInfo>(jsonResponse);
            if (nameInfo.statusCode == 200)
                return true;
            return false;
        }
        catch(WebException e)
        {
            return false;
        }
        
    }

    [Serializable]
    public class Player
    {
        public string name;
        public int score;
    }

    [Serializable]
    public class HighScoreInfo
    {
        public int statusCode;
        public bool error;
        public List<Player> message;
    }

    [Serializable]
    public class NameInfo
    {
        public int statusCode;
        public bool error;
        public Player message;
    }

    public void Submit()
    {
        string userInput = inputField.text;
        if(userInput.Length > 20 || userInput.Length == 0)
        {
            inputField.text = "";
            inputField.placeholder.GetComponent<Text>().text = "Enter a valid username";
        }
        else if(CheckPlayerName(userInput))
        {
            inputField.text = "";
            inputField.placeholder.GetComponent<Text>().text = "User name already exists";
        }
        else
        {
            PlayerPrefs.SetString("player_name", inputField.text);
            inputField.gameObject.SetActive(false);
            SubmitButton.gameObject.SetActive(false);
            DisplayHighScores();
        }
    }

    public void DisplayHighScores()
    {
        string localName = PlayerPrefs.GetString("player_name");
        
        int localHighScore = PlayerPrefs.GetInt("score",0);

        if ((Application.internetReachability != NetworkReachability.NotReachable))
        {
            List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
            UnityWebRequest www = UnityWebRequest.Post(String.Format("http://infy-app.herokuapp.com/api/score?name={0}&score={1}&key={2}", localName, localHighScore, API_KEY), formData);
            www.SendWebRequest();
        }
        
        int i = 0;
        highScoreNameText.text = "NAME\n\n";
        highScoreScoreText.text = "SCORE\n\n";

        highScores = GetHighScores();

        foreach (Player p in highScores.message)
        {
            if (i > 10)
            {
                break;
            }
            highScoreNameText.text += (i + 1) + ") " + p.name + "\n";
            highScoreScoreText.text += p.score + "\n";
            ++i;
        }
        highScoreNameText.text += "\n" + localName + "\n";
        highScoreScoreText.text += "\n" + localHighScore + "\n";
    }

}
