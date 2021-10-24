using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTrackerLevel2 : MonoBehaviour
{
    public GameObject textScoreDisplay;
    private bool hasEntered;
    int skullCounter = 19;

    public AudioSource backGroundAudio;

    private void Start()
    {
        // Re-enabling audio.
        backGroundAudio = GameObject.Find("Timer").GetComponent<AudioSource>();
        backGroundAudio.enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
        {
            hasEntered = true;

            // Updating the score.
            skullCounter = FPSControllerLPFP.FpsControllerLPFP.skullScoreCounter--;
            Debug.Log("Counter: " + skullCounter);

            // Changing skull color to red.
            this.GetComponent<Renderer>().material.color = Color.gray;

            // Setting the score onto canvas UI text.
            textScoreDisplay = GameObject.Find("ScoreText");
            textScoreDisplay.GetComponent<Text>().text = "Skulls Left: " + skullCounter.ToString();
        }

    }
    private void Update()
    {
        if (skullCounter == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
    }
}
