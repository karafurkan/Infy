using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public SpriteRenderer powerUpSpriteRenderer;

    public float[] spawnPoints = new float[4];

    public static bool hasShield = false;

    public Sprite shieldSprite;
    public Sprite reverseControlsSprite;
    public Sprite reverseDirectionSprite;
    public Sprite explosiveSprite;
    public Sprite boostSprite;

    int randomPowerUp = 0;

    public Pooling pooling;
    void Start()
    {
        pooling = GetComponent<Pooling>();
        powerUpSpriteRenderer = pooling.PowerUpObject.GetComponent<SpriteRenderer>();
        spawnPoints[0] = -2.0f;
        spawnPoints[1] = -0.5f;
        spawnPoints[2] = 0.5f;
        spawnPoints[3] = 2.0f;
        pooling.GetComponent<SpriteRenderer>().color = Color.red;
    }


    public void CreatePowerUp() {
        int pos = Random.Range(0,4);
        float spawnGap = Random.Range(1f, 2f);
        spawnGap = spawnGap * -(objectMover.speedDirection);
        
        
        if (spawnPoints[pos] < 0f) {
            float powerUpY = pooling.leftLastObject.transform.position.y - spawnGap;
            pooling.PowerUpObject.transform.position = new Vector3(spawnPoints[pos], powerUpY, 0);
            pooling.leftLastObject = pooling.PowerUpObject;
        } else {
            float powerUpY = pooling.rightLastObject.transform.position.y - spawnGap;
            pooling.PowerUpObject.transform.position = new Vector3(spawnPoints[pos], powerUpY, 0);
            pooling.rightLastObject = pooling.PowerUpObject;
        }
        pooling.PowerUpObject.SetActive(true);

        //int randomPowerUp = Random.Range(0,5);  // To determine which power-up is it going to be.
        //int randomPowerUp = 1;
        ++randomPowerUp;
        if(randomPowerUp == 0) {
            //pooling.PowerUpObject.transform.GetComponent<Image>.overrideSprite = Resources.Load<Sprite>("Textures/sprite");
            powerUpSpriteRenderer.sprite = shieldSprite;
            pooling.PowerUpObject.tag = "shield";
            //powerUpSpriteRenderer.color = Color.blue;
        } else if (randomPowerUp == 1){
            powerUpSpriteRenderer.sprite = reverseControlsSprite;
            pooling.PowerUpObject.tag = "reverse";
        } else if (randomPowerUp == 2) {
            powerUpSpriteRenderer.sprite = explosiveSprite;
            pooling.PowerUpObject.tag = "explosive";
        } else if (randomPowerUp == 3) {
            powerUpSpriteRenderer.sprite = reverseDirectionSprite;
            pooling.PowerUpObject.tag = "reverse-direction";
        } else if (randomPowerUp == 4) {
            powerUpSpriteRenderer.sprite = boostSprite; //3 saniye sonra shield bitecek. (2 saniye boost 1 saniye extra)
            Invoke("RemoveShield", 3f);
            pooling.PowerUpObject.tag = "boost";
        } 
        
     
    }


    public void ActivateExplosive() {
        if(BallController.verticalDirection == -1)
        {
            pooling.InitializeObstacles(-8.0f);
        }
        else
        {
            pooling.InitializeObstacles(15f);
            pooling.leftLastObject = pooling.leftObstacleArray[0];
            pooling.rightLastObject = pooling.rightObstacleArray[0];
        }
            
    }


}
