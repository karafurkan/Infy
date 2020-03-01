using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMover : MonoBehaviour
{
    public static float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveObstacle();
    }

    void MoveObstacle()
    {
        transform.Translate(0, speed * Time.deltaTime, 0);
    }
}
