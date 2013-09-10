using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {
	
	public float MAXSPEED = 5.0f;
	public float LOOKSPEED = 2.0f;
	public float VIEWRANGE = 60.0f;
	public float JUMPSPEED = 10.0f;
	
	private float pitch = 0f;
	private float y = 0f;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!Screen.lockCursor) {
			Screen.lockCursor = true;	
		}
		
		// Rotation
		float yaw = Input.GetAxis("Mouse X") * LOOKSPEED;
		transform.Rotate(0,yaw,0);
		
		
		pitch -= Input.GetAxis("Mouse Y") * LOOKSPEED;
		pitch = Mathf.Clamp(pitch, -VIEWRANGE, VIEWRANGE);
		Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(pitch,0,0));
		
		// Jumping
		y += Physics.gravity.y * Time.deltaTime;
		
		if (Input.GetButtonDown("Jump") /*&& cc.isGrounded*/) {
			y = JUMPSPEED;
		}
		
		// Movement
		float z = Input.GetAxis("Vertical") * MAXSPEED;
		float x = Input.GetAxis("Horizontal") * MAXSPEED;
		
		Vector3 v = transform.rotation * (new Vector3(x,y,z));
		
		cc.Move(v * Time.deltaTime);
		
	}
	
}
