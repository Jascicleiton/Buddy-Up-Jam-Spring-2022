using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro3Controller : MonoBehaviour
{
    [SerializeField] private DialogManager dialogManager = null;
    // Start is called before the first frame update

    void Start()
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfx(4);
            StartCoroutine(WaitOneSecond());
            SoundManager.Instance.PlaySfx(5);
            StartCoroutine(WaitOneSecond());
            
        }
        if (dialogManager != null)
        {
            dialogManager.FourthDialogSet();
        }
        else
        {
            dialogManager = FindObjectOfType<DialogManager>();
            dialogManager.FourthDialogSet();
        }
    }

    private void OnEnable()
    {
        EventHandler.DialogFinished += OpenPuzzle;
    }

    private void OnDisable()
    {
        EventHandler.DialogFinished -= OpenPuzzle;
    }

    private IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1f);
    }

    private void OpenPuzzle(int dialogNumber)
    {
        if (dialogNumber == 4)
        {
            SceneManager.LoadScene(SceneName.TeoPuzzle.ToString());
        }
    }
}
