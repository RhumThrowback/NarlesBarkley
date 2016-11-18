using UnityEngine;
using System.Collections;

public class SpinPlatform : MonoBehaviour
{
	private Rigidbody rb;
    private GameObject activeRing;
    private float torque = 1.0f;

    void Start()
    {
        //rb = ActiveRing.GetComponent<Rigidbody>();
    }

	void Update()
    {
        activeRing = GameManager.Instance.FindActiveRing();
        if (activeRing == null) return;
        rb = GameManager.Instance.activeRing.GetComponent<Rigidbody>();
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
