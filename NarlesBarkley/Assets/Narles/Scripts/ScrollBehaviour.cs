using UnityEngine;
using System.Collections;

public class ScrollBehaviour : MonoBehaviour
{
    private float scrollSpeed = 1.0f;
    private Rigidbody2D rb;
    private Camera mainCam;

    // Use this for initialization
    void Start ()
    {
        mainCam = Camera.main;
	    rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
        GameState gameState = GameManager.Instance.CurrentState();
        if (gameState == GameManager.Instance.stateGamePlaying)
        {
            rb.velocity = new Vector3(0.0f, (scrollSpeed * -1.0f), 0.0f);
        }
    }

    public void SetScrollSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}
