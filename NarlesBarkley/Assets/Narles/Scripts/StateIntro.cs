using UnityEngine;
using System.Collections;
using System;

public class StateIntro : GameState
{
    private float timer;
    private SpawnPlatform spawnScript;
    public StateIntro(GameManager manager) : base(manager) { }

    public override void OnStateEntered()
    {
        spawnScript = GameManager.Instance.GetComponent<SpawnPlatform>();
        timer = 4.0f;
        spawnScript.CreateNewLevel();
        
    }
    public override void OnStateExit()
    {
        timer = 4.0f;
    }

    public override void StateUpdate()
    {
        timer -= Time.deltaTime;
    
        if (timer <= 0.0f)
        {
            gameManager.NewGameState(gameManager.stateGamePlaying);
        }
    }
}
