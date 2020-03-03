using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    bool hasShield;

    void Start() {

        powerUpInit(); // Initializes all the power-up flags to false.
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Hit!");
        if (col.gameObject.tag == "shield") {   
            Debug.Log("Hit Shield!");
            ActivateShield();
            Invoke("DeactivateShield", 5.0f);
        }
        else if (col.gameObject.tag == "reverse") {  
            Debug.Log("Hit reverse!");
            ActivateReverseMode();
            Invoke("DeactivateReverseMode", 5.0f);
        }
        else if (col.gameObject.tag == "test") { 

        }
        if (col.gameObject.tag == "left" || col.gameObject.tag == "right") {  // Checks if the player hits to the obstacles.
            if(hasShield == false) {
               GameController.isGameOver = true;
            }
        }

    }

    void ActivateReverseMode() {
        Debug.Log("ACTIVATED REVERSE MODE");
        BallController.isReversed = true;
    }

    void DeactivateReverseMode() {
        BallController.isReversed = false;
    }


    void DeactivateShield() {
        hasShield = false;
        Debug.Log("Deactivated!");
    }

    void ActivateShield() {
        hasShield = true;
    }


    void powerUpInit() {
        hasShield = false;
    }

}
