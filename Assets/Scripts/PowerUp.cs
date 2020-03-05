using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PowerUp : MonoBehaviour
{
    public SpriteRenderer powerUpSpriteRenderer;

    public float[] spawnPoints = new float[4];

    public static bool hasShield = false;


    Pooling pooling;
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


        int randomPowerUp = Random.Range(0,3);  // To determine which power-up is it going to be.
        //randomPowerUp = 2;  // Uncomment it to have all the powerups 'reverse'
        if(randomPowerUp == 0) {
            pooling.PowerUpObject.tag = "shield";
            powerUpSpriteRenderer.color = Color.blue;
        } else if (randomPowerUp == 1){
            pooling.PowerUpObject.tag = "reverse";
            powerUpSpriteRenderer.color = Color.red;
        } else if (randomPowerUp == 2) {
            pooling.PowerUpObject.tag = "explosive";
            powerUpSpriteRenderer.color = Color.yellow;
        }
        
     
    }


    public void ActivateExplosive() {
        pooling.InitializeObstacles(-8.0f);
    }


}
