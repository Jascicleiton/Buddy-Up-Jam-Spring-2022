using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchBox : MonoBehaviour
{
    [SerializeField] private Cinematic cinematic = null;
    private Animator animator = null;

    private void Start()
    {
        if(cinematic == null)
        {
            cinematic = FindObjectOfType<Cinematic>();
        }
        animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        EventHandler.DialogFinished += DialogFinished;
    }

    private void OnDisable()
    {
        EventHandler.DialogFinished -= DialogFinished;
    }

    private void DialogFinished(int dialogNumber)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfx(1);
        }
        if (animator != null)
        {
            animator.SetTrigger("fade");
        }
    }

    public void ZoomInFinished()
    {
        cinematic.ActivateDialogOne();
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfx(0);
        }
    }


    public void ZoomOutFinished()
    {
        cinematic.ActivatePhone();
    }
}
