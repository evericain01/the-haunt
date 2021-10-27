using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject nextLevelText;
    public GameObject nextLevelCountDownText;

    public GameObject scoreDisplayText;
    public GameObject currentAmmotext;
    public GameObject ammoDivider;
    public GameObject totalAmmoText;
    public GameObject gunIcon;
    public GameObject currentLevelText;
    public GameObject timeLeftText;
    public GameObject countDownText;
    public GameObject reloadText;

    public int secondsLeft = 0;
    public bool takingAway = false;

    public GameObject pausePanel;
    private bool paused = false;

    public AudioSource backGroundAudio;

    private void Start()
    {
        paused = false;

        pausePanel.SetActive(false);
        nextLevelText.SetActive(false);
        nextLevelCountDownText.SetActive(false);

        textDisplay.GetComponent<Text>().text = secondsLeft.ToString();
        backGroundAudio = GameObject.Find("Timer").GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        // Prompting Game Over screen if there is no time left.
        if (secondsLeft == 0)
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
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
            pausePanel.SetActive(true);
            /*
                        Cursor.lockState = CursorLockMode.Locked;*/
/*            Cursor.visible = false;*/
            backGroundAudio.Pause();
            Time.timeScale = 0;
            paused = true;

        } else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            scoreDisplayText.SetActive(true);
            currentAmmotext.SetActive(true);
            ammoDivider.SetActive(true);
            totalAmmoText.SetActive(true);
            gunIcon.SetActive(true);
            currentLevelText.SetActive(true);
            timeLeftText.SetActive(true);
            countDownText.SetActive(true);
            reloadText.SetActive(true);
            pausePanel.SetActive(false);

            /*            Cursor.lockState = CursorLockMode.None;*/
/*            Cursor.visible = true;*/
            backGroundAudio.Play();
            Time.timeScale = 1;
            paused = false;
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if (secondsLeft < 10)
        {
            
            textDisplay.GetComponent<Text>().text = secondsLeft.ToString();
        }
        else
        {
            textDisplay.GetComponent<Text>().text = secondsLeft.ToString();

        }
        takingAway = false;
    }

}
