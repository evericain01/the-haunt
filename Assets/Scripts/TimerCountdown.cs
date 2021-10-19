using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountdown : MonoBehaviour
{
    public GameObject textDisplay;
    public GameObject nextLevelText;
    public GameObject nextLevelCountDownText;
    public int secondsLeft = 30;
    public bool takingAway = false;

    private void Start()
    {
        nextLevelText.SetActive(false);
        nextLevelCountDownText.SetActive(false);

        textDisplay.GetComponent<Text>().text = secondsLeft.ToString();
    }

    private void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
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
