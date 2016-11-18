using UnityEngine;
using System.Collections;

public class ScrollBehaviour : MonoBehaviour
{
    private float scrollSpeed;
    private Rigidbody rb;
    private Camera mainCam;

    // Use this for initialization
    void Start ()
    {
        mainCam = Camera.main;
	    rb = GetComponent<Rigidbody>();
        scrollSpeed = GameManager.Instance.scrollSpeed;
	}

    // Update is called once per frame
    void Update()
    {
        if (rb == null) return;

        scrollSpeed = GameManager.Instance.scrollSpeed;

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
