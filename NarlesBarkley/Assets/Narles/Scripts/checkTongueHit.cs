using UnityEngine;
using System.Collections;

public class checkTongueHit : MonoBehaviour
{

    public extendTongue script;
    float platformY;

    // Use this for initialization
    void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if(!script.isMoving)
        { 
            if (coll.gameObject.tag == "Ring" && coll.gameObject.activeInHierarchy)
            {
                platformY = coll.gameObject.transform.position.y;
                Debug.Log("Hit");
                script.MoveUp(platformY);
                script.isMoving = true;  
            }
        }
    }
}
