using UnityEngine;
using System.Collections;

public class SpinPlatform : MonoBehaviour {

	
	
	public Rigidbody rb;
    public GameObject ActiveRing;
    private float torque = 1.5f;

    void Start()
    {
        rb = ActiveRing.GetComponent<Rigidbody>();
    }

	void Update()
    {
        
    }

    public void CallRotate(float rotate)
    {
        OnRotateRing(rotate);
    }

	void OnRotateRing(float rotate)
	{        		
		{
            if (rotate > 0 )
            {
                Debug.Log("Rotate Right");
                rb.AddTorque(-transform.up * torque * rotate);
            }
            if (rotate < 0 )
            {
                Debug.Log("Rotate Left");
                rb.AddTorque(-(transform.up * torque * rotate));					    
            }
		}
	}
}
