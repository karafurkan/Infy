using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayCollision : MonoBehaviour
{

    public Text guideText;
    public GameObject[] powerUpHints = new GameObject[5];
    public Text[] powerUpTexts = new Text[5];
    public Text tapLeft;
    public Text tapRight;
    public Text guidanceText;
    public GameObject seperator;
    public Button backButton;

    void Start()
    {
        if (PlayerPrefs.GetString("language") == "tr")
        {
            
            powerUpTexts[0].text = "Kalkan seni 5 saniye boyunca engellere karşı korur";
            powerUpTexts[1].text = "Gemiyi 2 saniye boyunca hızlandırır";
            powerUpTexts[2].text = "5 saniye boyunca kontrolleri tersine çevirir";
            powerUpTexts[3].text = "Oyunun akış yönünü tersine çevirir";
            powerUpTexts[4].text = "Ekrandaki tüm engelleri patlatır";
            tapLeft.text = "Tıkla";
            tapRight.text = "Tıkla";
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "shield") {
            col.gameObject.SetActive(false);
            if (PlayerPrefs.GetString("language") == "tr")
            {
                guideText.text = "Şimdi bütün güçlendirmelere göz at!";
            }
            else
            {
                guideText.text = "Now check out all the powerups!";
            }
            backButton.gameObject.SetActive(true);
            ShowPowerUpHints();
        } else {
            col.gameObject.transform.position = new Vector3(transform.position.x, -5.4f, 0f);
        }
    }

    private void ShowPowerUpHints()
    {
        foreach (GameObject go in powerUpHints)
        {
            go.gameObject.SetActive(true);
        }
        seperator.gameObject.SetActive(false);
    }
}
