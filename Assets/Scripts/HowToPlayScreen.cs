using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HowToPlayScreen : MonoBehaviour
{
    public Button backButton;

    private Vector2 speed = new Vector2(8,0);


    public Button rightButton;
    public Button leftButton;

    public Rigidbody2D leftBallRB;
    public Rigidbody2D rightBallRB;

    private bool leftBallMoving = false;
    private bool rightBallMoving = false;

    private int leftBallDirection = 1;
    private int rightBallDirection = -1;

    private bool leftButtonClicked = false;
    private bool rightButtonClicked = false;
    
    private float leftBallPosX;
    private float rightBallPosX;


    public GameObject obstacle;
    public GameObject powerup;

    public Text guideText;

    private int stage = 0;

    void Start()
    {
        rightButton.gameObject.SetActive(false);
    }

 
    void Update()
    {
        Flow();
    }

    private void FixedUpdate()
    {
        MoveLeftBall();
        MoveRightBall();
    }

    public void backButtonClicked() {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ResetScene() {


    }

    public void Flow() {

        if (stage == 1) {
            guideText.text = "Top on Right Side!";
            leftButton.gameObject.SetActive(false);
            rightButton.gameObject.SetActive(true);

        } else if (stage == 2) {
            guideText.text = "Avoid the obstacle!";
            leftButton.gameObject.SetActive(true);
            MoveObstacle();

        } else if (stage == 3) {
            MoveObstacle();
            
        } else if (stage == 4) {
            MovePowerUP();
        }
    
    }


    public void MoveLeftBall() {
        
        if (leftButtonClicked == true && leftBallMoving == false){
            leftBallPosX = leftBallRB.transform.position.x;
            leftBallRB.AddForce(speed * leftBallDirection, ForceMode2D.Impulse);
            leftBallDirection = leftBallDirection * -1;
            leftBallMoving = true;
            leftButtonClicked = false;
        } 

        if (leftBallMoving == true)
        {
            if (Mathf.Abs(leftBallRB.transform.position.x - leftBallPosX) >= 1.5) {
                leftBallRB.AddForce(speed * leftBallDirection, ForceMode2D.Impulse);
                leftBallMoving = false;
            }
        }
    }

    public void MoveRightBall() {

        if (rightButtonClicked == true && rightBallMoving == false){
            rightBallPosX = rightBallRB.transform.position.x;
            rightBallRB.AddForce(speed * rightBallDirection, ForceMode2D.Impulse);
            rightBallDirection = rightBallDirection * -1;
            rightBallMoving = true;
            rightButtonClicked = false;
        } 

        if (rightBallMoving == true)
        {
            if (Mathf.Abs(rightBallRB.transform.position.x - rightBallPosX) >= 1.5) {
                rightBallRB.AddForce(speed * rightBallDirection, ForceMode2D.Impulse);
                rightBallMoving = false;
            }
        }
    }

    public void LeftButtonClicked() {
        if (stage == 0) {
            stage = 1;
        }
        leftButtonClicked = true;
    }

    public void RightButtonClicked() {
        if (stage == 1) {
            stage = 2;
        }
        rightButtonClicked = true;
    }


    void MoveObstacle() {
        obstacle.gameObject.transform.Translate(0, 3 * Time.deltaTime, 0);
        if (obstacle.gameObject.transform.position.y >= 5.15 && stage == 2) {
            stage = 3;
            obstacle.transform.position = new Vector3(0.85f, -5.4f, 0f);
        }
        else if (obstacle.gameObject.transform.position.y >= 5.15 && stage == 3) {
            stage = 4;
            guideText.text = "Collect the power-up!";
            powerup.gameObject.SetActive(true);
            obstacle.gameObject.SetActive(false);
        }
    }


    void MovePowerUP() {
        powerup.gameObject.transform.Translate(0, 3 * Time.deltaTime, 0);
        if (powerup.gameObject.transform.position.y >= 5.15 && stage == 4) {
            powerup.transform.position = new Vector3(powerup.transform.position.x, -5.4f, 0f);
        }
    }
}
