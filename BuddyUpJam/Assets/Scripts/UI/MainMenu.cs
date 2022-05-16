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
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfx(7);
        }
        SceneManager.LoadScene(SceneName.IntroScene.ToString());
        //SceneManager.LoadScene(SceneName.TeoPuzzle.ToString());
    }

    public void OnCreditsButtonClicked()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfx(7);
        }
        SceneManager.LoadScene(SceneName.Credits.ToString());
    }

    public void OnReturnButtonClicked()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfx(7);
        }
        SceneManager.LoadScene(SceneName.MainMenu.ToString());
    }
}
