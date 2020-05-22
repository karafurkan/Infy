using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayCollision : MonoBehaviour
{

    public Text guideText;
    public GameObject[] powerUpHints = new GameObject[5];
    public GameObject seperator;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "shield") {
            col.gameObject.SetActive(false);
            guideText.text = "Now check out all the powerups!";
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
