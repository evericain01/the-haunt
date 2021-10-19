using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using System.Reflection;

public class ScoreTrackerScene1 : MonoBehaviour
{
    private bool hasEntered;
    public GameObject scoreDisplayText;
    public bool takingAway = false;
    int counter = -1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
        {
            hasEntered = true;

            // Updating the score.
            counter = FPSControllerLPFP.FpsControllerLPFP.ballonScoreCounter--;

            // Changing balloon color to red.
            this.GetComponent<Renderer>().material.color = Color.red;

            // Setting the score onto canvas UI text.
            scoreDisplayText.GetComponent<Text>().text = "Balloons Left: " + counter.ToString();

        }

    }

    private void Update()
    {
        if (counter == 0)
        {
            GameObject.Find("SceneSwitcher").GetComponent<SceneSwitch>().SceneSwitcher();
        }
    }
}


