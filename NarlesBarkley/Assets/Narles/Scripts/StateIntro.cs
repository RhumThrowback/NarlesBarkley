using UnityEngine;
using System.Collections;
using System;

public class StateIntro : GameState
{
    private float timer;
    public StateIntro(GameManager manager) : base(manager) { }

    public override void OnStateEntered()
    {
        timer = 4.0f;
    }
    public override void OnStateExit()
    {
        timer = 4.0f;
    }

    public override void StateUpdate()
    {
        timer -= Time.deltaTime;
        Debug.Log(timer); //Test print to console remove later 

        if (timer <= 0.0f)
        {
            gameManager.NewGameState(gameManager.stateGamePlaying);
        }
    }
}
