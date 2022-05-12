using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonCLicked()
    {
        //SceneManager.LoadScene("IntroScene");
        SceneManager.LoadScene(SceneName.SamplePuzzle.ToString());
    }

    public void OnCreditsButtonClicked()
    {
        SceneManager.LoadScene(SceneName.Credits.ToString());
    }

    public void OnReturnButtonClicked()
    {
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
