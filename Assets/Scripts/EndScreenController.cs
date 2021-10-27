using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{
    private void Start()
    {
        // Resetting Score
        FPSControllerLPFP.FpsControllerLPFP.ballonScoreCounter = 30;
        FPSControllerLPFP.FpsControllerLPFP.skullScoreCounter = 20;

        // Unlocking the cursor after scene change.
        Cursor.visible = true;
        Screen.lockCursor = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
