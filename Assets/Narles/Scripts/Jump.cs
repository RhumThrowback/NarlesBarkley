using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {

    private float Speed = 10.0f;
    private float JumpForce = 8.0f;
    private float Gravity = 30.0f;
    private Vector3 MoveDir = Vector3.zero;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        CharacterController Controller = gameObject.GetComponent<CharacterController>();

        if (Controller.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            MoveDir = transform.TransformDirection(MoveDir);

            MoveDir *= Speed;

            if (Input.GetButtonDown("Jump"))
            {
                MoveDir.y = JumpForce;
            }

        }

        MoveDir.y -= Gravity * Time.deltaTime;

        Controller.Move(MoveDir * Time.deltaTime);
	
	}
}
