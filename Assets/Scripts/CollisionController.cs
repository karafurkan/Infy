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
        Debug.Log("HIT!!!!");
        if (col.gameObject.tag == "power-up") {   // CheckobjectMover.speed if the player gets any power-up.
            //if (col.gameObject.name == "shield") {
                Debug.Log("HIT power up!!!!");
                ActivateShield();
                Invoke("DeactivateShield", 5.0f);
           // }
        }
        if (col.gameObject.tag == "left" || col.gameObject.tag == "right") {  // Checks if the player hits to the obstacles.
            if(hasShield == false) {
               GameController.isGameOver = true;
            }
        }

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
