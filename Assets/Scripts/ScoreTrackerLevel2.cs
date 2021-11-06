using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreTrackerLevel2 : MonoBehaviour
{
    public GameObject textScoreDisplay;
    private bool hasEntered;
    int skullCounter = -1;

    public AudioSource backGroundAudio;

    private void Start()
    {
        // Re-enabling audio.
        backGroundAudio = GameObject.Find("Timer").GetComponent<AudioSource>();
        backGroundAudio.enabled = true;
    }

    private void Update()
    {
        // Checks for when there are no more skulls left to prompt the End Screen.
        if (skullCounter == 0)
        {
            SceneManager.LoadScene("EndScreen");
        }
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
            GetComponent<Renderer>().material.color = Color.gray;

            // Setting the score onto canvas UI text.
            textScoreDisplay = GameObject.Find("ScoreText");
            textScoreDisplay.GetComponent<Text>().text = "Skulls Left: " + skullCounter.ToString();
        }

    }

}
