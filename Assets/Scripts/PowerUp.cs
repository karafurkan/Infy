using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public Sprite reverseControlSprite;
    public Sprite shieldSprite;

    public float[] spawnPoints = new float[4];
    /*
    public PowerUp(GameObject pu, GameObject llo, GameObject rlo)
    {
        powerUpObject = pu;
        leftLastObject = llo;
        rightLastObject = rlo;
    }
    */
    Pooling pooling; // = GetComponent<Pooling>();
    void Start()
    {
        pooling = GetComponent<Pooling>();

        spawnPoints[0] = -2.0f;
        spawnPoints[1] = -0.5f;
        spawnPoints[2] = 0.5f;
        spawnPoints[3] = 2.0f;
        pooling.GetComponent<SpriteRenderer>().color = Color.red;
    }


    public void getRandomPosition() {
        Debug.Log("getrandomPos Running");
        int pos = Random.Range(0,4);
        float spawnGap = Random.Range(2.5f, 4f);
        

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


        int randomPowerUp = Random.Range(0,2);  // To determine which power-up is it going to be.
        //int randomPowerUp = 0;  // Uncomment it to have all the powerups 'reverse'
        if(randomPowerUp == 0) {
            Debug.Log("SHIELD POWERUP CREATED");
            pooling.PowerUpObject.tag = "shield";
            pooling.PowerUpObject.GetComponent<SpriteRenderer>().color = Color.blue;
        } else {
            Debug.Log("REVERSE POWERUP CREATED");
            pooling.PowerUpObject.tag = "reverse";
            pooling.PowerUpObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        
     
    }


}
