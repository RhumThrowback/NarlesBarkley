using UnityEngine;
using System.Collections;

public class extendTongue : MonoBehaviour {
        
    public Rigidbody2D rb;
    public GameObject playerTongue;    

    // Use this for initialization
    void Start () {        
        rb = GetComponent<Rigidbody2D>();       
    }

    void FixedUpdate()
    {
        
    }
        
    void Update ()
    {
       
    }

    void MoveToNextPlatform(float platformY)
    {
        transform.Translate(0, platformY, 0);
    }
    
    public IEnumerator activateTongue() {
        playerTongue.SetActive(true);   
        yield return new WaitForSeconds(0.5f);       
        playerTongue.SetActive(false);
    }

    public void actTongue()
    {
        StartCoroutine(activateTongue());
    }

    public void MoveUp(float platformPositionY)
    {
        MoveToNextPlatform(platformPositionY);
    }
}
