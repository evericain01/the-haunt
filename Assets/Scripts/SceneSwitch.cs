using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneSwitch : MonoBehaviour
{
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

    public void SceneSwitcher()
    {
        // Stopping animations, movement and audio.
        GameObject.Find("Player").GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        GameObject.Find("Player").GetComponent<FPSControllerLPFP.FpsControllerLPFP>()._audioSource.Stop();
        GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().enabled = false;
        GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().anim.enabled = false;
        GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().crosshair = new Texture2D(0, 0);

        // Removing the current canvas text.
        scoreDisplayText.SetActive(false);
        currentAmmotext.SetActive(false);
        ammoDivider.SetActive(false);
        totalAmmoText.SetActive(false);
        gunIcon.SetActive(false);
        currentLevelText.SetActive(false);
        timeLeftText.SetActive(false);
        countDownText.SetActive(false);
        reloadText.SetActive(false);

        // Displaying new canvas text.
        nextLevelText.SetActive(true);
        nextLevelCountDownText.SetActive(true);
        nextLevelCountDownText.GetComponent<Text>().text = secondsLeft.ToString();

        if (takingAway == false && secondsLeft > 0)
        {
            Debug.Log("Seconds Left: " + secondsLeft);
            StartCoroutine(TimerTake());
        }

        StartCoroutine(DelayToNextScene());
    }

    IEnumerator DelayToNextScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Level2");
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
