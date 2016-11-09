using UnityEngine;
using System.Collections;

public class extendTongue : MonoBehaviour {
        
    public Rigidbody2D rb;
    public GameObject playerTongue;
    private bool hitPlatform;

    // Use this for initialization
    void Start () {        
        rb = GetComponent<Rigidbody2D>();
        hitPlatform = false;
    }

    void FixedUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Extend the tongue");
            StartCoroutine(activateTongue());            
        }        
    }
        
    void Update ()
    {
        if (hitPlatform)
        {
            Debug.Log("Move the player");
        }

    }

    void MoveToNextPlatform()
    {
        transform.Translate(0, 2.0f, 0);
    }
    
    IEnumerator activateTongue() {
        playerTongue.SetActive(true);   
        yield return new WaitForSeconds(0.5f);       
        playerTongue.SetActive(false);
    }

    public void MoveUp()
    {
        MoveToNextPlatform();
    }
}
