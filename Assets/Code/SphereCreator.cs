using UnityEngine;
using System.Collections;

public class SphereCreator : MonoBehaviour {
	
	public float SPEED = 1000;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		// Abilities
		if (Input.GetKeyDown(KeyCode.Q)) {
			createSphere(0);
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			createSphere(SPEED);
		}
	}
	
	private void createSphere(float v) {
		GameObject s = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			
		Vector3 p = cc.transform.position + transform.rotation * (new Vector3(0, 0, 1));
		s.transform.Translate(p);
		
		s.AddComponent<Rigidbody>();
		s.rigidbody.AddForce(transform.rotation * new Vector3(0,0,v));
	}
}
