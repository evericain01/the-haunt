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
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
            hasEntered = true;
            this.GetComponent<Renderer>().material.color = Color.red;
            int counter = FPSControllerLPFP.FpsControllerLPFP.scoreCounter--;
            textScoreDisplay = GameObject.Find("ScoreText");
            textScoreDisplay.GetComponent<Text>().text = "Balloons Left: " + counter.ToString();
            Destroy(this);
        }
}


