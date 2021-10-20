using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTrackerLevel2 : MonoBehaviour
{
    public GameObject textScoreDisplay;
    private bool hasEntered;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
        {
            hasEntered = true;

            // Updating the score.
            int counter = FPSControllerLPFP.FpsControllerLPFP.skullScoreCounter--;
            Debug.Log("Counter: " + counter);

            // Changing balloon color to red.
            this.GetComponent<Renderer>().material.color = Color.gray;

            // Setting the score onto canvas UI text.
            textScoreDisplay = GameObject.Find("ScoreText");
            textScoreDisplay.GetComponent<Text>().text = "Skulls Left: " + counter.ToString();
        }

    }
}
