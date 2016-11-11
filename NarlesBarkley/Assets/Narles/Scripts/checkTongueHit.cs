using UnityEngine;
using System.Collections;

public class checkTongueHit : MonoBehaviour {

    public extendTongue script;
    float platformY;

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Next Platform")
        {
            
            platformY = coll.gameObject.transform.position.y;
            Debug.Log("Hit");
            script.MoveUp(platformY);            
        }
        
    }
}
