using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    
    float score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = score + objectMover.speed * Time.deltaTime;
        
        this.gameObject.GetComponent<Text>().text = ((int)score).ToString();
    }
}
