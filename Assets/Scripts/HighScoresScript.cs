using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoresScript : MonoBehaviour
{
    
    public Button backButton;
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void backButtonClicked() {
        SceneManager.LoadScene("MainMenuScene");
    }

}
