using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTrackerScene1 : MonoBehaviour
{
    public GameObject textScoreDisplay;

    private bool hasEntered;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
        {
            hasEntered = true;

            // Updating the score.
            int counter = FPSControllerLPFP.FpsControllerLPFP.ballonScoreCounter--;

            Debug.Log("Counter: " + counter);

            if (counter == 0)
            {
                SceneManager.LoadScene("Scene2");
            }

            // Changing balloon color to red.
            this.GetComponent<Renderer>().material.color = Color.red;


            // Setting the score onto canvas UI text.
            textScoreDisplay = GameObject.Find("ScoreText");
            textScoreDisplay.GetComponent<Text>().text = "Balloons Left: " + counter.ToString();
            Destroy(this);
        }

    }
}


