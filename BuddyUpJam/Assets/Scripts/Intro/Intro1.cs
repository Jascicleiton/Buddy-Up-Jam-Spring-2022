using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro1 : MonoBehaviour
{
    Animator myAnimator;
    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
        
    }
    private void Start()
    {
     //   PlayAnimation();
    }


    public void PauseAnimation()
    {
        myAnimator.speed = 0;
    }

    private void ResumeAnimation()
    {
        myAnimator.speed = 1;
    }

    public void PlaySfx(int sfxToPlay)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.PlaySfx(sfxToPlay);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ResumeAnimation();
        }
    }
}
