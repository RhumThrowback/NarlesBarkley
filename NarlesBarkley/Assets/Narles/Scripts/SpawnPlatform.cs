using UnityEngine;
using System.Collections;

[System.Serializable]
public class SpawnPlatform : MonoBehaviour
{
    public class Theme
    { 
    public GameObject enemy;
    }

    private const float RING_HEIGHT = 2.5f; //Distance between platforms (height)
    private const float CHANCE_OF_THEME_CHANGE = 0.2f;
    private const int MAX_INACTIVE_RING_SEGMENTS = 6; //Used for Randomize function.  Makes sure there is at least one active ring segment in each ring.
    private Vector3 spawnPoint;
    public GameObject lastBaseObject;
    

    // Set themes for background to change up environment on playthroughs
    // add new themes if wanted
    public Theme easyStreet;
    // Use this for initialization
    void Awake  ()
    {
        //start point for first base geometry object
        spawnPoint = new Vector3(0.0f, 0.0f, 4.64f);
	}

	// Update is called once per frame
	void Update ()
    {
        //if the last base object we spawned has moved far enough away, spawn a new base object
        GameState currentState = GameManager.Instance.CurrentState();
        if (currentState == GameManager.Instance.stateGamePlaying)
        { 
           if(spawnPoint.y - lastBaseObject.transform.position.y > RING_HEIGHT)
            {
                CreateNewSegment();
                Randomize(lastBaseObject, MAX_INACTIVE_RING_SEGMENTS);
            }
        }
    }

    public void CreateNewSegment()
    {
        GameObject newPiece = PoolManager.Instance.GetObjectForType("Ring", true);
        newPiece.transform.position = spawnPoint;
        lastBaseObject = newPiece;
        GameManager.Instance.ringsInLevel.Add(newPiece);
    }

    
    public void ClearLevel()
    {
        //zero everthing out;
        lastBaseObject = null;
        spawnPoint = new Vector3(0.0f, 0.0f, 4.64f);
        GameManager.Instance.ringsInLevel.Clear();
        


        GameObject[] tempRings = GameObject.FindGameObjectsWithTag("Ring");

        if(tempRings.Length > 0)
        { 
            for (int i = 0; i < tempRings.Length; i++ )
            {
                PoolManager.Instance.PoolObject(tempRings[i]);
            }
        }
    }

    //use this to Create level at beginning(first load and after game over) 
    public void CreateNewLevel()
    {
        ClearLevel();
        int numPiecesToSpawn = 5;

        for(int i = 0; i < numPiecesToSpawn; i++)
        {
            GameObject newPiece = PoolManager.Instance.GetObjectForType("Ring", true);

            if (lastBaseObject == null)
            { 
                newPiece.transform.position = spawnPoint;
                lastBaseObject = newPiece;
                GameManager.Instance.ringCount++;
                Randomize(lastBaseObject, MAX_INACTIVE_RING_SEGMENTS);
            }
            else
            {
                newPiece.transform.position = new Vector3(lastBaseObject.transform.position.x, lastBaseObject.transform.position.y - RING_HEIGHT, lastBaseObject.transform.position.z);
                lastBaseObject = newPiece;
                GameManager.Instance.ringCount++;
                Randomize(lastBaseObject, MAX_INACTIVE_RING_SEGMENTS);
            }
            GameManager.Instance.ringsInLevel.Add(newPiece);
        }
    }

    private void Randomize(GameObject piece, int maxMissing)
    {
        int numInActiveSegments = 0;

        for (int i = 0; i < piece.transform.childCount; i++ )
        {
            piece.transform.GetChild(i).gameObject.SetActive(true);
            if (numInActiveSegments < maxMissing)
            {
                int range = Random.Range(0, 2);

                switch (range)
                {
                    case 0:
                        piece.transform.GetChild(i).gameObject.SetActive(false);
                        numInActiveSegments++;
                        break;
                    case 1:
                        break;
                    default:
                        break;
                }
            }
        }
    }

}
