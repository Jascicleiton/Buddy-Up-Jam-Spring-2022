using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScene : MonoBehaviour
{
    [SerializeField] SceneName puzzleSelected = SceneName.TeoPuzzle;
    public void PuzzleSelected()
    {
        if(GameManager.Instance != null)
        {
            GameManager.Instance.puzzleToGoTo = puzzleSelected;
            SceneManager.LoadScene(SceneName.IntroScene.ToString());
        }
        else
        {
            print("GameManager null");
        }
    }
}
