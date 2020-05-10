﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionController : MonoBehaviour
{
    public Text powerUpTimer;
    public GameObject topLimitObject;

    public PowerUp PowerUpControl;
    public GameController gameController;
    public float currentSpeed;

    public Sprite shieldAura;
    public Sprite reverseControlsAura;
    //public Sprite reverseDirectionAura;

    public SpriteRenderer leftBallAura;
    public SpriteRenderer rightBallAura;

    void Start() {
        PowerUpControl = topLimitObject.GetComponent<PowerUp>();
        gameController = topLimitObject.GetComponent<GameController>();
    }

    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) {
        //Debug.Log("Hit!");
        if (col.gameObject.tag == "shield") {   
            setPowerUpTimer(5);
            leftBallAura.sprite = shieldAura;
            rightBallAura.sprite = shieldAura;
            leftBallAura.gameObject.SetActive(true);
            rightBallAura.gameObject.SetActive(true);
            //Debug.Log("Hit Shield!");
            ActivateShield();
            Invoke("DeactivateShield", 5.0f);
            StartCoroutine(fadeOut(leftBallAura, 5f));
            StartCoroutine(fadeOut(rightBallAura, 5f));
            col.gameObject.SetActive(false);
        } else if (col.gameObject.tag == "reverse") {  
            setPowerUpTimer(5);
            leftBallAura.sprite = reverseControlsAura;
            rightBallAura.sprite = reverseControlsAura;
            leftBallAura.gameObject.SetActive(true);
            rightBallAura.gameObject.SetActive(true);
            StartCoroutine(fadeOut(leftBallAura, 5f));
            StartCoroutine(fadeOut(rightBallAura, 5f));
            //Debug.Log("Hit reverse!");
            ActivateReverseMode();
            Invoke("DeactivateReverseMode", 5.0f);
            col.gameObject.SetActive(false);
        } else if (col.gameObject.tag == "explosive") { 
            //Debug.Log("Hit explosive");
            col.gameObject.SetActive(false);
            PowerUpControl.ActivateExplosive();
            PowerUpControl.Invoke("CreatePowerUp", 7f); //change spawn time
        } else if (col.gameObject.tag == "reverse-direction") {
            //Debug.Log("Hit reverse direction");
            //leftBallAura.sprite = reverseDirectionAura;
            //rightBallAura.sprite = reverseDirectionAura;
            col.gameObject.SetActive(false);
            ActivateReverseDirection();
            
        } else if (col.gameObject.tag == "boost") { 
            col.gameObject.SetActive(false);
            leftBallAura.gameObject.SetActive(true);
            rightBallAura.gameObject.SetActive(true);
            leftBallAura.sprite = shieldAura;
            rightBallAura.sprite = shieldAura;
            ActivateBoost();
            Invoke("DeactivateBoost", 2.0f);
            
        }
        if (col.gameObject.tag == "left" || col.gameObject.tag == "right") {  // Checks if the player hits to the obstacles.
            if(PowerUp.hasShield == false) {
                GameController.isGameOver = true;
                gameController.GameOver();
            }
        }

    }

    void ActivateBoost() {
        PowerUp.hasShield = true;
        currentSpeed = objectMover.speed;
        objectMover.speed = 20f;
    }

    void DeactivateBoost() {
        Invoke("SetShieldOff", 1.0f);
        objectMover.speed = currentSpeed;
        PowerUpControl.Invoke("CreatePowerUp", 7f); 
    }

    void ActivateReverseDirection() {
        PowerUpControl.Invoke("CreatePowerUp", 10f); //change spawn time

        objectMover.speedDirection = -objectMover.speedDirection;
        if (BallController.verticalDirection == -1) {
            PowerUpControl.pooling.InitializeObstacles(22f);
            PowerUpControl.pooling.leftLastObject = PowerUpControl.pooling.leftObstacleArray[0];
            PowerUpControl.pooling.rightLastObject = PowerUpControl.pooling.rightObstacleArray[0];
        } else {
            PowerUpControl.pooling.InitializeObstacles(-15f);
        }

        BallController.isReversedDirection = true;
        if (BallController.verticalDirection == -1) {
            topLimitObject.transform.position = new Vector3(topLimitObject.transform.position.x, -7.56f, 0f);
        } else {
            topLimitObject.transform.position = new Vector3(topLimitObject.transform.position.x, 7.56f, 0f);
        }

    }


    void decreasePowerUpTimer() {
        if(powerUpTimer.text != "0") {
            powerUpTimer.text = (int.Parse(powerUpTimer.text) - 1).ToString();
            Invoke("decreasePowerUpTimer",1.0f);
        } 
    }


    void setPowerUpTimer(int t) {
        powerUpTimer.text = t.ToString();
        powerUpTimer.gameObject.SetActive(true);
        Invoke("decreasePowerUpTimer",1.0f);
    }

    void ActivateReverseMode() {
        BallController.isReversedController = true;
    }

    void DeactivateReverseMode() {
        BallController.isReversedController = false;
        powerUpTimer.gameObject.SetActive(false);
        leftBallAura.gameObject.SetActive(false);
        rightBallAura.gameObject.SetActive(false);
        PowerUpControl.Invoke("CreatePowerUp", 7f); //change spawn time
    }


    void DeactivateShield() {
        SetShieldOff();
        powerUpTimer.gameObject.SetActive(false);
        PowerUpControl.Invoke("CreatePowerUp", 7f); //change spawn time
    }

    void ActivateShield() {
        PowerUp.hasShield = true;
    }

    void SetShieldOff() {
        PowerUp.hasShield = false;
        leftBallAura.gameObject.SetActive(false);
        rightBallAura.gameObject.SetActive(false);
    }

    IEnumerator fadeOut(SpriteRenderer MyRenderer, float duration)
    {
        float counter = 0;
        //Get current color
        Color spriteColor = MyRenderer.material.color;

        while (counter < duration)
        {
            counter += Time.deltaTime;
            //Fade from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            Debug.Log(alpha);

            //Change alpha only
            MyRenderer.color = new Color(spriteColor.r, spriteColor.g, spriteColor.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }


}
