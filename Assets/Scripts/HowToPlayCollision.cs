using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayCollision : MonoBehaviour
{

    public Text guideText;
    
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
        } else {
            col.gameObject.transform.position = new Vector3(transform.position.x, -5.4f, 0f);
        }
    }
}
