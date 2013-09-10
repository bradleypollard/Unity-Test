using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	
	public GameObject bullet;
	public float bSpeed = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1")) {
			Camera c = Camera.main;
			GameObject b = (GameObject)Instantiate(bullet, c.transform.position + c.transform.forward, c.transform.rotation);
			b.rigidbody.AddForce(c.transform.forward * bSpeed, ForceMode.Impulse);
		}
	}
}
