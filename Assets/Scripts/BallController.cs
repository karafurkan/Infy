using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D leftBallRB;
    public Rigidbody2D rightBallRB;
    private Vector2 velocity;
    public float speed;

    private bool leftBallMoving = false;
    private bool hitLeftBall = false;
    private int leftBallDirection = 1;

    private bool rightBallMoving = false;
    private bool hitRightBall = false;
    private float rightBallDirection = -1;

    public static bool isReversed;

    // Start is called before the first frame update
    void Start()
    {
        isReversed = false;

        velocity = new Vector2(speed, 0f);
        //Application.targetFrameRate = 300;
        SetVsync0_120FPS();
        //leftBallRB.MovePosition(leftBallRB.position + velocity * Time.fixedDeltaTime);

    }

    // Update is called once per frame
    


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveLeftBall();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveRightBall();
        }
        
    }

    private void FixedUpdate()
    {
        //left ball movement
        if (hitLeftBall && !leftBallMoving)
        {
            leftBallRB.AddForce(velocity * leftBallDirection, ForceMode2D.Impulse);
            leftBallMoving = true;
            hitLeftBall = false;
            leftBallDirection = leftBallDirection * -1;
        }

        else if (hitLeftBall && leftBallMoving)
        {
            leftBallRB.AddForce(velocity * leftBallDirection * 2, ForceMode2D.Impulse);
            leftBallMoving = true;
            hitLeftBall = false;
            leftBallDirection = leftBallDirection * -1;
        }

        if (leftBallMoving)
        {
            if (leftBallDirection == -1)
            {
                if (leftBallRB.transform.position.x >= -0.5)
                {
                    leftBallRB.AddForce(-velocity, ForceMode2D.Impulse);
                    leftBallMoving = false;
                    leftBallDirection = -1;
                }
            }
            else if (leftBallDirection == 1)
            {
                if (leftBallRB.transform.position.x <= -2)
                {
                    leftBallRB.AddForce(velocity, ForceMode2D.Impulse);
                    leftBallMoving = false;
                    leftBallDirection = 1;
                }
            }
        }




        //right ball movement
        if (hitRightBall && !rightBallMoving)
        {
            rightBallRB.AddForce(velocity * rightBallDirection, ForceMode2D.Impulse);
            rightBallMoving = true;
            hitRightBall = false;
            rightBallDirection = rightBallDirection * -1;
        }

        else if (hitRightBall && rightBallMoving)
        {
            rightBallRB.AddForce(velocity * rightBallDirection * 2, ForceMode2D.Impulse);
            //rightBallMoving = true;
            hitRightBall = false;
            rightBallDirection = rightBallDirection * -1;
        }

        if (rightBallMoving)
        {
            if (rightBallDirection == 1)
            {
                if (rightBallRB.transform.position.x <= 0.5)
                {
                    rightBallRB.AddForce(velocity, ForceMode2D.Impulse);
                    rightBallMoving = false;
                    rightBallDirection = 1;
                }
            }
            else if (rightBallDirection == -1)
            {
                if (rightBallRB.transform.position.x >= 2)
                {
                    rightBallRB.AddForce(-velocity, ForceMode2D.Impulse);
                    rightBallMoving = false;
                    rightBallDirection = -1;
                }
            }
        }
    }

    public void moveLeftBall()
    {
        if(isReversed == true) {
            hitRightBall = true;
        } else {
            hitLeftBall = true;
        }
    }
    public void moveRightBall()
    {
        if(isReversed == true) {
            hitLeftBall = true;
        } else {
            hitRightBall = true;
        }
    }
    public void SetVsync0_120FPS() { QualitySettings.vSyncCount = 0; Application.targetFrameRate = 120; }
}
