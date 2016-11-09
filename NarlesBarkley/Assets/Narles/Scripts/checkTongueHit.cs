using UnityEngine;
using System.Collections;

public class checkTongueHit : MonoBehaviour {

    private extendTongue script;
    // Use this for initialization
	void Start ()
    {
        script = GameObject.FindObjectOfType(typeof(extendTongue)) as extendTongue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Platform")
        {           
            Debug.Log("Hit");
            script.MoveUp();            
        }
        
    }
}
