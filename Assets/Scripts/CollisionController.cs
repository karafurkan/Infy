using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{

    public Text powerUpTimer;

    void Start() {


    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Hit!");
        if (col.gameObject.tag == "shield") {   
            setPowerUpTimer(5);
            Debug.Log("Hit Shield!");
            ActivateShield();
            Invoke("DeactivateShield", 5.0f);
            col.gameObject.SetActive(false);
        }
        else if (col.gameObject.tag == "reverse") {  
            setPowerUpTimer(5);
            Debug.Log("Hit reverse!");
            ActivateReverseMode();
            Invoke("DeactivateReverseMode", 5.0f);
            col.gameObject.SetActive(false);
        }
        else if (col.gameObject.tag == "test") { 

        }
        if (col.gameObject.tag == "left" || col.gameObject.tag == "right") {  // Checks if the player hits to the obstacles.
            if(PowerUp.hasShield == false) {
               GameController.isGameOver = true;
            }
        }

    }

    void decreasePowerUpTimer(){
        if(powerUpTimer.text != "0") {
            powerUpTimer.text = (int.Parse(powerUpTimer.text) - 1).ToString();
            Invoke("decreasePowerUpTimer",1.0f);
        } 
    }


    void setPowerUpTimer(int t) {
        powerUpTimer.text = t.ToString();
        Debug.Log(powerUpTimer.text);
        powerUpTimer.gameObject.SetActive(true);
        Invoke("decreasePowerUpTimer",1.0f);
    }

    void ActivateReverseMode() {
        Debug.Log("ACTIVATED REVERSE MODE");
        BallController.isReversed = true;
    }

    void DeactivateReverseMode() {
        BallController.isReversed = false;
        powerUpTimer.gameObject.SetActive(false);
    }


    void DeactivateShield() {
        PowerUp.hasShield = false;
        Debug.Log("Deactivated!");
        powerUpTimer.gameObject.SetActive(false);
    }

    void ActivateShield() {
        PowerUp.hasShield = true;
    }



}
