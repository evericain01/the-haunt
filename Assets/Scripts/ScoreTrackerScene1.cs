using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreTrackerScene1 : MonoBehaviour
{
    private bool hasEntered;

    public GameObject scoreDisplayText;
    public GameObject currentAmmotext;
    public GameObject ammoDivider;
    public GameObject totalAmmoText;
    public GameObject gunIcon;
    public GameObject currentLevelText;
    public GameObject timeLeftText;
    public GameObject countDownText;
    public GameObject reloadText;

    public GameObject nextLevelText;
    public GameObject nextLevelCountDownText;


    public int secondsLeft = 5;
    public bool takingAway = false;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bullet") && !hasEntered)
        {
            hasEntered = true;

            // Updating the score.
            int counter = FPSControllerLPFP.FpsControllerLPFP.ballonScoreCounter--;

            Debug.Log("Counter: " + counter);

            // Changing balloon color to red.
            this.GetComponent<Renderer>().material.color = Color.red;

            // Setting the score onto canvas UI text.
            /*GameObject textScoreDisplay = GameObject.Find("ScoreText");*/
            scoreDisplayText.GetComponent<Text>().text = "Balloons Left: " + counter.ToString();

            if (counter == 0)
            {

                GameObject.Find("Player").GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
                GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().enabled = false;
                GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().crosshair = new Texture2D(0, 0);


                scoreDisplayText.SetActive(false);
                currentAmmotext.SetActive(false);
                ammoDivider.SetActive(false);
                totalAmmoText.SetActive(false);
                gunIcon.SetActive(false);
                currentLevelText.SetActive(false);
                timeLeftText.SetActive(false);
                countDownText.SetActive(false);
                reloadText.SetActive(false);

                nextLevelText.SetActive(true);
                nextLevelCountDownText.SetActive(true);

                if (takingAway == false && secondsLeft > 0)
                {
                    StartCoroutine(TimerTake());
                }

                StartCoroutine(DelayToNextScene());
            }

        }

    }

    IEnumerator DelayToNextScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Scene2");
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            nextLevelCountDownText.GetComponent<Text>().text = secondsLeft.ToString();
        }
        else
        {
            nextLevelCountDownText.GetComponent<Text>().text = secondsLeft.ToString();

        }
        takingAway = false;

    }
}


