using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using System.Reflection;

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

    private void Update()
    {
        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }
    }

    public void SceneSwitcher()
    {
        GameObject.Find("Player").GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        GameObject.Find("Player").GetComponent<FPSControllerLPFP.FpsControllerLPFP>()._audioSource.Stop();
        GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().enabled = false;
        GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().anim.enabled = false;
        GameObject.Find("arms_handgun_04").GetComponent<HandgunScriptLPFP>().crosshair = new Texture2D(0, 0);
        SetAmbientOcclusion(1000.0f);
        SetIndirectResolution(1000.0f);

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
        nextLevelCountDownText.GetComponent<Text>().text = secondsLeft.ToString();

        if (takingAway == false && secondsLeft > 0)
        {
            StartCoroutine(TimerTake());
        }

        StartCoroutine(DelayToNextScene());
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

    public static void SetIndirectResolution(float val)
    {
        SetFloat("m_LightmapEditorSettings.m_Resolution", val);
    }

    public static void SetAmbientOcclusion(float val)
    {
        SetFloat("m_LightmapEditorSettings.m_CompAOExponent", val);
    }


    public static void SetFloat(string name, float val)
    {
        ChangeProperty(name, property => property.floatValue = val);
    }

    public static void SetInt(string name, int val)
    {
        ChangeProperty(name, property => property.intValue = val);
    }

    public static void SetBool(string name, bool val)
    {
        ChangeProperty(name, property => property.boolValue = val);
    }

    public static void ChangeProperty(string name, Action<SerializedProperty> changer)
    {
        var lightmapSettings = getLighmapSettings();
        var prop = lightmapSettings.FindProperty(name);
        if (prop != null)
        {
            changer(prop);
            lightmapSettings.ApplyModifiedProperties();
        }
        else Debug.LogError("lighmap property not found: " + name);
    }

    static SerializedObject getLighmapSettings()
    {
        var getLightmapSettingsMethod = typeof(LightmapEditorSettings).GetMethod("GetLightmapSettings", BindingFlags.Static | BindingFlags.NonPublic);
        var lightmapSettings = getLightmapSettingsMethod.Invoke(null, null) as UnityEngine.Object;
        return new SerializedObject(lightmapSettings);
    }
}
