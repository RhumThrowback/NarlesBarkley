using UnityEngine;
using System.Collections;

public class extendTongue : MonoBehaviour
{
        
    public Rigidbody rb;
    public GameObject playerTongue;
    public bool isMoving = false;

    // Use this for initialization
    void Start ()
    {        
        rb = GetComponent<Rigidbody>();
        playerTongue.SetActive(false);  
    }

    void FixedUpdate()
    {
        
    }
        
    void Update ()
    {
       
    }

    void MoveToNextPlatform(float platformY)
    {
       gameObject.transform.position = new Vector3(0.0f, platformY, 0.0f);
        isMoving = false;
    }
    
    public IEnumerator activateTongue()
    {
        playerTongue.SetActive(true);
        yield return new WaitForSeconds(0.2f);       
        playerTongue.SetActive(false);
        //isMoving = false;
    }

    public void actTongue()
    {
        StartCoroutine(activateTongue());
    }

    public void MoveUp(float platformPositionY)
    {
        //playerTongue.SetActive(false);
        MoveToNextPlatform(platformPositionY);
       
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("HitExtendTongue");
    //    GameObject temp;
    //    float newY;

    //    if (collision.gameObject.name == "Ring")
    //    {
    //        temp = collision.gameObject;
    //        newY = temp.gameObject.transform.position.y;

    //        MoveUp(newY);

    //    }
    //}
}
