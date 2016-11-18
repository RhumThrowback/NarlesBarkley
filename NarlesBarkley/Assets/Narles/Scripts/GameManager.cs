using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    private GameState currentState;
    public StateGamePlaying stateGamePlaying { get; set; }
    public StateGameLost stateGameLost { get; set; }
    public StateGameMenu stateGameMenu { get; set; }
    public StateIntro stateIntro { get; set; }

    public static GameManager Instance { get { return instance; } }
    private static GameManager instance = null;

    public int ringCount;
    private const int MIN_RINGS = 8;

    public float scrollSpeed;
    public List<GameObject> ringsInLevel;

    public GameObject activeRing;
    public GameObject player;
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
        //SceneManager.LoadScene(0);
        activeRing = null;
        scrollSpeed = 1.0f;
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

    public GameState CurrentState()
    {
        return currentState;
    }

    public GameObject FindActiveRing()
    {
        float minDist = Mathf.Infinity;
        Vector3 currentPostion = player.transform.position;
        foreach(GameObject ring in ringsInLevel)
        {
            Vector3 directionToTarget = ring.transform.position - currentPostion;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if(dSqrToTarget < minDist && ring.transform.position.y > currentPostion.y)
            {
                minDist = dSqrToTarget;
                activeRing = ring;
            }
        }

        return activeRing;
    }
    public Vector3 PlayerPosition(GameObject player)
    {
        Vector3 playerScreenPos = Camera.main.GetComponent<Camera>().WorldToScreenPoint(player.transform.position);
        Debug.Log(playerScreenPos);
        return playerScreenPos;
    }
}
