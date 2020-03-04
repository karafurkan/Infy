using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pooling : MonoBehaviour
{
   
    public float[] spawnPoints = new float[3];
    public GameObject leftLastObject;
    public GameObject rightLastObject;
    public GameObject PowerUpObject;


    private PowerUp PowerUpControl;
    /*
    public static float leftObjectY;   
    public static float rightObjectY;
    */

    // Start is called before the first frame update
    void Start()
    {
        PowerUpControl = GetComponent<PowerUp>();

        spawnPoints[0] = 1.0f;
        spawnPoints[1] = 2.0f;
        spawnPoints[2] = 3.0f;

        //PowerUpControl = new PowerUp(); //(PowerUpObject, leftLastObject, rightLastObject);
        
        //leftObjectY = leftLastObject.transform.position.y;
        //rightObjectY = rightLastObject.transform.position.y;
        


    }

    // Update is called once per frame
    void Update()
    {
    
    }
    


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "left")
        {
            float leftRandomInt = Random.Range(2.5f,4f);
            float leftY = leftLastObject.transform.position.y - leftRandomInt;
            int selection = Random.Range(0, 2);
            if (selection == 0){
                col.gameObject.transform.position = new Vector3(-2.1f, leftY, 0f);
            }
            else
            {
                col.gameObject.transform.position = new Vector3(-0.67f, leftY, 0f);
            }
            
            leftLastObject = col.gameObject;
            //leftObjectY = leftLastObject.transform.position.y;
            
        }
        else if (col.gameObject.tag == "right")
        {
            
            float rightRandomInt = Random.Range(2.5f,4f);
            float rightY = rightLastObject.transform.position.y - rightRandomInt;    
            int selection = Random.Range(0, 2);
            if (selection == 0)
            {
                col.gameObject.transform.position = new Vector3(0.59f, rightY, 0f);
            }
            else
            {
                col.gameObject.transform.position = new Vector3(2.24f, rightY, 0f);
            }
            rightLastObject = col.gameObject;
            //rightObjectY = rightLastObject.transform.position.y;
        }
        else if(col.gameObject.tag == "shield" || col.gameObject.tag == "reverse") //TODO: instead, check if tag exists in a predefined string array
        {
            col.gameObject.SetActive(false);
            float randomFloat = Random.Range(20f, 45f);
            PowerUpControl.Invoke("getRandomPosition", 2f); //change spawn time
            //PowerUpControl.getRandomPosition();
        }

    }

}
