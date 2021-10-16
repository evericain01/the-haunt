using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ScoreTracker : MonoBehaviour
{
    public GameObject textScoreDisplay;
    private bool hasEntered;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bullet" && !hasEntered)
        {
            hasEntered = true;
            int counter = FPSControllerLPFP.FpsControllerLPFP.scoreCounter++;
            GameObject textScoreDisplay = GameObject.Find("ScoreText");
            textScoreDisplay.GetComponent<Text>().text = "Score: " + counter.ToString();
            
        }
    }

}
