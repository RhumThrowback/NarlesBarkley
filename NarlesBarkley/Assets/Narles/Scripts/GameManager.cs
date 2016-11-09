using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private GameState currentState;
    public StateGamePlaying stateGamePlaying { get; set; }
    public StateGameLost stateGameLost { get; set; }
    public StateGameMenu stateGameMenu { get; set; }
    public StateIntro stateIntro { get; set; }

    public static GameManager Instance { get { return instance; } }
    private static GameManager instance = null;


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

        stateGamePlaying =  new StateGamePlaying(this);
        stateGameLost =     new StateGameLost(this);
        stateGameMenu =     new StateGameMenu(this);
        stateIntro =        new StateIntro(this);
    }

    private void Start()
    {
        NewGameState(stateIntro);
        SceneManager.LoadScene(0);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.StateUpdate();
        }
    }

    public void NewGameState(GameState newState)
    {
        if(null != currentState)
        {
            currentState.OnStateExit();
        }
        currentState = newState;
        currentState.OnStateEntered();
    }
}
