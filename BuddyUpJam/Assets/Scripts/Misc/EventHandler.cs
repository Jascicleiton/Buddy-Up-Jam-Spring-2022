using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler
{
    public static event Action<int> DialogFinished;

    public static void CallDialogFinishedEvent(int dialogNumber)
    {
        if (DialogFinished != null)
        {
            DialogFinished(dialogNumber);
        }
    }
}
