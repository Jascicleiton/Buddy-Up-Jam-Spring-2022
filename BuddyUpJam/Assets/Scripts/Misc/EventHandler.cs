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

    public static event Action CraneClicked;

    public static void CallCraneClicked()
    {
        if (CraneClicked != null)
        {
            CraneClicked();
        }
    }

    public static event Action PieceRemoved;
    
    public static void CallPieceRemoved()
    {
        if (PieceRemoved != null)
        {
            PieceRemoved();
        }
    }

    public static event Action<PuzzleSequence> Slide;
    public static void CallSlide(PuzzleSequence directionToSlide)
    {
        if (Slide != null)
        {
            Slide(directionToSlide);
        }
    }
}
