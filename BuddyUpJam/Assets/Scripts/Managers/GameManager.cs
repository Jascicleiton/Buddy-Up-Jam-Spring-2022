using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public SceneName puzzleToGoTo = SceneName.TeoPuzzle;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }


}
