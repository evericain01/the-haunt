using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    void Start()
    {
        // Resetting Score
        FPSControllerLPFP.FpsControllerLPFP.ballonScoreCounter = 30;
        FPSControllerLPFP.FpsControllerLPFP.skullScoreCounter = 20;

        // Unlocking the cursor after scene change.
        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    public void RestartLevel()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
