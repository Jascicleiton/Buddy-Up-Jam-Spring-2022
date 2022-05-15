using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        if(!SoundManager.Instance.isMusicPlaying)
        {
            SoundManager.Instance.PlayMusic(0);
        }
    }

    public void OnStartButtonCLicked()
    {
        SceneManager.LoadScene(SceneName.IntroScene.ToString());
        //SceneManager.LoadScene(SceneName.TeoPuzzle.ToString());
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
