using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using System.Math;

public class objectMover : MonoBehaviour
{
    public static float initialSpeed = 2.5f;
    public static float speed;
    public static float speedDirection = -1;

    // Start is called before the first frame update
    void Start() {
        speed = initialSpeed;
        InvokeRepeating("AdjustSpeed", 0.0f, 0.2f);
    }

    // Update is called once per frame
    void Update() {
        MoveObstacle();
    }

    void MoveObstacle() {
        transform.Translate(0, -(speedDirection * speed * Time.deltaTime), 0);
    }

    void AdjustSpeed() {
                
        if (speed < 3.5) {
            speed = speed + 0.03f * Time.deltaTime;
        } else if (speed < 4){
            speed = speed + 0.04f * Time.deltaTime;
        } else if (speed < 4.5){
            speed = speed + 0.009f * Time.deltaTime;
        } else if (speed < 5){
            speed = speed + 0.0009f * Time.deltaTime;
        } 

    }
}
