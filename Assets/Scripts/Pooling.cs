using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class Pooling : MonoBehaviour
{
   
    public float[] spawnPoints = new float[3];
    public GameObject leftLastObject;
    public GameObject rightLastObject;
    public GameObject PowerUpObject;
    public GameObject[] leftObstacleArray = new GameObject[4];
    public GameObject[] rightObstacleArray = new GameObject[4];

    public float minimumGap;
    public float maximumGap;


    public PowerUp PowerUpControl;
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

        InitializeObstacles(-2.0f);

    }



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "left")
        {
            float leftRandomInt = Random.Range(minimumGap,maximumGap);
            float leftY = leftLastObject.transform.position.y + (objectMover.speedDirection)*leftRandomInt;
            
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
            
            float rightRandomInt = Random.Range(minimumGap,maximumGap);
            float rightY = rightLastObject.transform.position.y + (objectMover.speedDirection)*rightRandomInt;
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
        else if(col.gameObject.tag == "shield" || col.gameObject.tag == "reverse" || col.gameObject.tag == "explosive" || col.gameObject.tag == "reverse-direction" || col.gameObject.tag == "boost") //TODO: instead, check if tag exists in a predefined string array
        {
            col.gameObject.SetActive(false);
            float randomFloat = Random.Range(20f, 45f);
            PowerUpControl.Invoke("CreatePowerUp", 7f); //change spawn time
        }

    }

    public void InitializeObstacles(float positionY)
    {
        //initialize left obstacles
        int selection = Random.Range(0, 2); 

        if (selection == 0) {
            leftObstacleArray[0].transform.position = new Vector3(-2.1f, positionY, 0f); 
            leftLastObject = leftObstacleArray[0];
        } else if (selection == 1) {
            leftObstacleArray[0].transform.position = new Vector3(-0.67f, positionY, 0f); 
            leftLastObject = leftObstacleArray[0];
        }
        
        
        
        
        foreach (GameObject go in leftObstacleArray.Skip(1))
        {
            float leftRandomInt = Random.Range(minimumGap, maximumGap);
            float leftY = leftLastObject.transform.position.y - leftRandomInt;
            selection = Random.Range(0, 2);
            if (selection == 0)
            {
                go.transform.position = new Vector3(-2.1f, leftY, 0f);
            }
            else
            {
                go.transform.position = new Vector3(-0.67f, leftY, 0f);
            }
            leftLastObject = go;
        }

        //initialize right obstacles
        selection = Random.Range(0, 2);
        

        if (selection == 0) {
            rightObstacleArray[0].transform.position = new Vector3(0.59f, positionY, 0f); 
            rightLastObject = rightObstacleArray[0];
        } else if (selection == 1) {
            rightObstacleArray[0].transform.position = new Vector3(2.24f, positionY, 0f); 
            rightLastObject = rightObstacleArray[0];
        }
        
        
        foreach (GameObject go in rightObstacleArray.Skip(1)){
            float rightRandomInt = Random.Range(minimumGap, maximumGap);
            float rightY = rightLastObject.transform.position.y - rightRandomInt;
            selection = Random.Range(0, 2);
            if (selection == 0)
            {
                go.transform.position = new Vector3(0.59f, rightY, 0f);
            }
            else
            {
                go.transform.position = new Vector3(2.24f, rightY, 0f);
            }
            rightLastObject = go;
        }
    }


}
