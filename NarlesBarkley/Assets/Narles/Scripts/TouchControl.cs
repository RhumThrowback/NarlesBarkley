using UnityEngine;
using System.Collections;

public class TouchControl : MonoBehaviour {
    private Touch initialTouch = new Touch();
    private float distance = 0;
    private bool hasSwiped = false;

    public extendTongue tongueScript;
    public SpinPlatform spinScript;
    public Player playerScript;
    
    void Start()
    {
              
    }
           
    /*void FixedUpdate()
    {
        foreach (Touch t in Input.touches)
        {
            if (t.phase == TouchPhase.Began)
            {
                initialTouch = t;
            }
            else if (t.phase == TouchPhase.Moved && !hasSwiped)
            {
                float deltaX = initialTouch.position.x - t.position.x;
                float deltaY = initialTouch.position.y - t.position.y;
                distance = Mathf.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
                bool swipedSideways = Mathf.Abs(deltaX) > Mathf.Abs(deltaY);

                if (distance > 100f)
                {
                    if (swipedSideways && deltaX > 0) //swiped left
                    {
                        
                    }
                    else if (swipedSideways && deltaX <= 0) //swiped right
                    {
                       
                    }
                    else if (!swipedSideways && deltaY > 0) //swiped down
                    {
                        
                    }
                    else if (!swipedSideways && deltaY <= 0)  //swiped up
                    {
                        
                    }

                    hasSwiped = true;
                }

            }
            else if (t.phase == TouchPhase.Ended)
            {
                initialTouch = new Touch();
                hasSwiped = false;
            }
        }
    } */
    
    void OnMouseDrag()
    {
       
        float drag = Input.GetAxis("Horizontal");
        float swipe = Input.GetAxis("Vertical");
       
        if(GameManager.Instance.CurrentState() == GameManager.Instance.stateGamePlaying)
        { 
            if (swipe < -5) 
            {
                //Debug.Log("Swipe Up!");
               tongueScript.actTongue();
               //playerScript.Jump();
            }
            if (swipe > 5) 
            {
               //Debug.Log("Swipe Down!");
            }
            if (drag > 5)
            {
               // Debug.Log("Swipe Right!");
                spinScript.CallRotate(50);                       
            }
            if (drag < -5)
            {
               // Debug.Log("Swipe Left!");
                spinScript.CallRotate(-50);
            }
        }
    }
}
