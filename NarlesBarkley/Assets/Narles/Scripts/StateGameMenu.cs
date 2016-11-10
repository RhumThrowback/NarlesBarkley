using UnityEngine;
using System.Collections;
using System;

public class StateGameMenu : GameState
{
    private ScrollBehaviour scroll;
    private Camera cam = Camera.main;

    public StateGameMenu(GameManager manager) : base(manager) { }

    public override void OnStateEntered()
    {
        scroll = cam.GetComponent<ScrollBehaviour>();
        scroll.SetScrollSpeed(0.0f);
    }
    public override void OnStateExit()
    {
        throw new NotImplementedException();
    }
    public override void StateUpdate()
    {
        throw new NotImplementedException();
    }
}
