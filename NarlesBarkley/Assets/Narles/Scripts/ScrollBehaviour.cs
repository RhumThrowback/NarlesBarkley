using UnityEngine;
using System.Collections;

public class ScrollBehaviour : MonoBehaviour
{
    private float scrollSpeed = 0.0f;
    public Rigidbody2D rb;

    // Use this for initialization
    void Start ()
    {
	    rb = GetComponent<Rigidbody2D>();
	}

    // Update is called once per frame
    void Update()
    {
            rb.velocity = new Vector3(0.0f, scrollSpeed, 0.0f);      
    }

    public void SetScrollSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}
