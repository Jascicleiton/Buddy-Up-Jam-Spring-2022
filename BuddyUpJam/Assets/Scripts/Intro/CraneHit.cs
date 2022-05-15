using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CraneHit : MonoBehaviour
{
    [SerializeField] GameObject craneImage = null;
    [SerializeField] DialogManager dialogManager = null;
    [SerializeField] Sprite portraitSprite = null;
    private void OnEnable()
    {
        EventHandler.DialogFinished += ShowCraneHit;
    }

    private void OnDisable()
    {
        EventHandler.DialogFinished -= ShowCraneHit;
    }

    private void ShowCraneHit(int dialogNumber)
    {
        if (dialogNumber == 2)
        {
            if (SoundManager.Instance != null)
            {
                SoundManager.Instance.PlaySfx(3);
            }
            if (craneImage != null)
            {
                craneImage.SetActive(true);
                StartCoroutine(CraneHitRoutine());
            }
        }
        else if (dialogNumber == 3)
        {
            SceneManager.LoadScene(SceneName.TeoPuzzle.ToString());
        }
    }

    private IEnumerator CraneHitRoutine()
    {
        yield return new WaitForSeconds(2f);
        if (dialogManager != null)
        {
            dialogManager.leftPortrait.sprite = portraitSprite;
            dialogManager.ThirdDialogSet();
        }
        craneImage.SetActive(false);
        
    }
}
