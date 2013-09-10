using UnityEngine;
using System.Collections;

public class BulletExplosion : MonoBehaviour {
	
	public GameObject effect;
	public float LIFESPAN = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		LIFESPAN -= Time.deltaTime;
		
		if (LIFESPAN <= 0) {
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter(Collision c) {
		//Destroy(gameObject);
		if (c.gameObject.tag == "Enemy") {
			Explode(c);
		}
	}
	
	private void Explode(Collision c) { 
		c.gameObject.tag = "Dead";
		Instantiate(effect, c.transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
