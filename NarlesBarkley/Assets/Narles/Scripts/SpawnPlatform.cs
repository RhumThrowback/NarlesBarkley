using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpawnPlatform : MonoBehaviour
{
    public class Theme
    { 
    public GameObject enemy;
    }
    
    private const float RING_HEIGHT = 4.0f; //Distance between platforms (height)
    private const float CHANCE_OF_THEME_CHANGE = 0.2f;
    private Vector3 spawnPoint;
    public GameObject lastBaseObject;

    // Set themes for background to change up environment on playthroughs
    // add new themes if wanted
    public Theme easyStreet;
    // Use this for initialization
    void Awake  ()
    {
        //start point for first base geometry object
        spawnPoint = new Vector3(0, 0, 0); 
	}

	// Update is called once per frame
	void Update ()
    {
	    //if the last base object we spawned has moved far enough away, spawn a new base object
           if(spawnPoint.y - lastBaseObject.transform.position.y > RING_HEIGHT)
            {
                CreateNewSegment();
            }
    }

    public void CreateNewSegment()
    {
        GameObject newPiece = PoolManager.Instance.GetObjectForType("Platform", true);
        newPiece.transform.position = spawnPoint;
        lastBaseObject = newPiece;
    }
}
