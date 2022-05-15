using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToActivate = null;
    [SerializeField] DialogManager dialogManager = null;
    public void AnimationFinished()
    {
        if(objectsToActivate.Length > 0)
        {
            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(true);
                if (dialogManager == null)
                {
                    dialogManager = FindObjectOfType<DialogManager>();
                }
                dialogManager.SecondDialogSet();
            }
        }
    }
}
