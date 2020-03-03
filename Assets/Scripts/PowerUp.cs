using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;

    public float[] spawnPoints = new float[4];

    void Start()
    {

        spawnPoints[0] = -2.0f;
        spawnPoints[1] = -0.5f;
        spawnPoints[2] = 0.5f;
        spawnPoints[3] = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, objectMover.speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D col) { 
        powerUp.SetActive(false);
        Invoke("getRandomPosition", 2.0f);
    }


    void getRandomPosition() {
        int pos = Random.Range(0,4);
        float posY;
        if (spawnPoints[pos] < 0f) {
            posY = Pooling.leftObjectY - 2f;
            //Debug.Log("LeftObjectY = " + Pooling.leftObjectY);
            //Debug.Log("PowerUP = " + posY);
        } else {
            posY = Pooling.rightObjectY - 2f;
            //Debug.Log("RightObjectY = " + Pooling.rightObjectY);
            //Debug.Log("PowerUP = " + posY);
        }
        powerUp.transform.position = new Vector3(spawnPoints[pos], posY, 0);
        powerUp.SetActive(true);
     
    }


}
