using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using System.Reflection;

public class ScoreTrackerLevel1 : MonoBehaviour
{
    private bool hasEntered;
    public GameObject scoreDisplayText;
    int balloonCounter = 30;

    public AudioSource backGroundAudio;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
        {
            hasEntered = true;

            // Updating the score.
            balloonCounter = FPSControllerLPFP.FpsControllerLPFP.ballonScoreCounter--;

            // Changing balloon color to red.
            this.GetComponent<Renderer>().material.color = Color.red;

            // Setting the score onto canvas UI text.
            scoreDisplayText.GetComponent<Text>().text = "Balloons Left: " + balloonCounter.ToString();

        }

    }

    private void Update()
    {
        backGroundAudio = GameObject.Find("Timer").GetComponent<AudioSource>();

        if (balloonCounter == 0)
        {
            backGroundAudio.enabled = false;
            GameObject.Find("SceneSwitcher").GetComponent<SceneSwitch>().SceneSwitcher();
        }

    }
}


