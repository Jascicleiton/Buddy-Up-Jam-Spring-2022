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

    public static event Action<int> SfxToPlay;

    public static void CallSfxToPlay(int sfxToPlay)
    {
        if (SfxToPlay != null)
        {
            SfxToPlay(sfxToPlay);
        }
    }
}
