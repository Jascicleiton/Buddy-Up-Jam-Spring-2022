using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematic : MonoBehaviour
{
    [SerializeField] private Animator cameraAnimator = null;
    [SerializeField] private GameObject lunchBox = null;
    
    [SerializeField] private DialogManager dialogManager = null;

   
    // Start is called before the first frame update
    void Start()
    {
        if(SoundManager.Instance != null)
        {
            SoundManager.Instance.PlayMusic(1);
        }
        lunchBox.SetActive(true);
        cameraAnimator.SetBool("shouldZoomIn", true);
        if(dialogManager == null)
        {
            dialogManager = FindObjectOfType<DialogManager>();
        }
    }

    public void ActivateDialogOne()
    {
        
        dialogManager.FirstDialogSet();
    }

    public void ActivatePhone()
    {
        SceneManager.LoadScene(SceneName.IntroScene1.ToString());
    }
}
