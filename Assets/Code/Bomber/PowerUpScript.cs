using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	public int x, y;
	public int type;
	public Material power;
	public Material bomb;
	public Material speed;
		
	// Use this for initialization
	void Start () {
		type = LevelArray.rand.Next(0,3);
		x = Mathf.RoundToInt(gameObject.transform.position.x) + 5;
		y = Mathf.RoundToInt(gameObject.transform.position.z) + 5;
		
		if (type == 0) {
			gameObject.renderer.material = speed;
		} else if (type == 1) {
			gameObject.renderer.material = power;
		} else if (type == 2) {
			gameObject.renderer.material = bomb;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
