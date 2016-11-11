using UnityEngine;
using System.Collections;
using System;

public class StateGamePlaying : GameState
{
    private bool isPaused = false;

    public StateGamePlaying(GameManager manager) : base(manager) { }

    public override void OnStateEntered()
    {
        
    }
    public override void OnStateExit()
    {
        
    }
    public override void StateUpdate()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape)) //Only for testing, needs to be modified for touch later on
        {
            if(isPaused)
            {
                ResumeGameMode();
            }
            else
            {
                PauseGameMode();
            }
        }
    }

    private void ResumeGameMode()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
    }

    private void PauseGameMode()
    {
        Time.timeScale = 0.0f;
        isPaused = true;
    }
}
