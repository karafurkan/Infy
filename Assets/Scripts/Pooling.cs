using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pooling : MonoBehaviour
{
   
    public float[] spawnPoints = new float[3];
    public GameObject leftLastObject;
    public GameObject rightLastObject;
    
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints[0] = 1.0f;
        spawnPoints[1] = 2.0f;
        spawnPoints[2] = 3.0f;
        
        


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
        }

    }
}
