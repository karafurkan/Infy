using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody2D leftBallRB;
    public Rigidbody2D rightBallRB;
    private Vector2 velocity;
    public float speed;

    const int resolutionX = 9;
    const int resolutionY = 16;

    private bool leftBallMoving = false;
    private bool hitLeftBall = false;
    private int leftBallDirection = 1;

    private bool rightBallMoving = false;
    private bool hitRightBall = false;
    private float rightBallDirection = -1;

    public static bool isReversedController;


    // Reversed Direction
    public static bool isReversedDirection;
    public bool isMovingVertically = false;
    private Vector2 verticalVelocity;
    public static int verticalDirection = -1;
    //


    // Start is called before the first frame update
    void Start()
    {
        //fix resolution
        float screenRatio = Screen.width * 1f / Screen.height;
        float bestRatio = resolutionX * 1f / resolutionY;
        if (screenRatio <= bestRatio)
        {
            GetComponent<Camera>().rect = new Rect(0, (1f - screenRatio / bestRatio) / 2f, 1, screenRatio / bestRatio);
        }
        else if (screenRatio > bestRatio)
        {
            GetComponent<Camera>().rect = new Rect((1f - bestRatio / screenRatio) / 2f, 0, bestRatio / screenRatio, 1);
        }

        isReversedController = false;
        isReversedDirection = false;
        velocity = new Vector2(speed, 0f);
        //Application.targetFrameRate = 300;
        SetVsync0_120FPS();
        //leftBallRB.MovePosition(leftBallRB.position + velocity * Time.fixedDeltaTime) 



        verticalVelocity = new Vector2(0.0f, objectMover.speed);

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
       LeftRightMovement();
       UpDownMovemement();
    }

    private void UpDownMovemement() {
        
        if(isReversedDirection == true) {
            leftBallRB.AddForce(verticalVelocity * verticalDirection, ForceMode2D.Impulse);
            rightBallRB.AddForce(verticalVelocity * verticalDirection, ForceMode2D.Impulse);
            isReversedController = false;
            isMovingVertically = true;
            isReversedDirection = false;
        }

        if (isMovingVertically == true) {
            if (verticalDirection == -1) {
                if(leftBallRB.transform.position.y <= -4.306f) {
                    verticalDirection = 1;
                    leftBallRB.AddForce(verticalVelocity * verticalDirection, ForceMode2D.Impulse);
                    rightBallRB.AddForce(verticalVelocity * verticalDirection, ForceMode2D.Impulse);
                    isMovingVertically = false;
                }
            } else {
                if(leftBallRB.transform.position.y >= 4.306f) {
                    verticalDirection = -1;
                    leftBallRB.AddForce(verticalVelocity * verticalDirection, ForceMode2D.Impulse);
                    rightBallRB.AddForce(verticalVelocity * verticalDirection, ForceMode2D.Impulse);
                    isMovingVertically = false;
                }
            }
        }

    }



    private void LeftRightMovement() {
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
        if(!GameController.isPaused)
        {
            if (isReversedController == true)
            {
                hitRightBall = true;
            }
            else
            {
                hitLeftBall = true;
            }
        }
        
    }
    public void moveRightBall()
    {
        if(!GameController.isPaused)
        {
            if (isReversedController == true)
            {
                hitLeftBall = true;
            }
            else
            {
                hitRightBall = true;
            }
        }
        
    }
    public void SetVsync0_120FPS() { QualitySettings.vSyncCount = 0; Application.targetFrameRate = 120; }
}
