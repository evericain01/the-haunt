using UnityEngine;
using UnityEngine.UI;

public class ScoreTrackerLevel1 : MonoBehaviour
{
    private bool hasEntered;
    public GameObject scoreDisplayText;
    int balloonCounter = -1;

    public AudioSource backGroundAudio;

    private void Start()
    {
        backGroundAudio = GameObject.Find("Timer").GetComponent<AudioSource>();
    }

    private void Update()
    {

        if (balloonCounter == 0)
        {
            backGroundAudio.enabled = false;
            GameObject.Find("Timer").GetComponent<TimerCountdown>().secondsLeft = 30;
            GameObject.Find("SceneSwitcher").GetComponent<SceneSwitch>().SceneSwitcher();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
        {
            hasEntered = true;

            // Updating the score.
            balloonCounter = FPSControllerLPFP.FpsControllerLPFP.ballonScoreCounter--;
            Debug.Log("Counter: " + balloonCounter);

            // Changing balloon color to red.
            this.GetComponent<Renderer>().material.color = Color.red;

            // Setting the score onto canvas UI text.
            scoreDisplayText.GetComponent<Text>().text = "Balloons Left: " + balloonCounter.ToString();

        }

    }


}


