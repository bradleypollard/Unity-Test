using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {

	public GameObject explode;
	public GameObject power;
	public float TIMER = 1f;
	private int x, y;
	public bool hit = false;

	// Use this for initialization
	void Start () {
		x = Mathf.RoundToInt(gameObject.transform.position.x) + 5;
		y = Mathf.RoundToInt(gameObject.transform.position.z) + 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (hit) {
			TIMER -= Time.deltaTime;
			
			if (TIMER <=0) {
				Destroy(gameObject);
				if (LevelArray.rand.Next(0,4) == 1) {
					GameObject o = LevelArray.createObject(x,y,power,0);
					LevelArray.level[x,y] = new ArrayClass(ArrayTypes.POWERUP, o);
				} else {
					LevelArray.level[x,y] = new ArrayClass(ArrayTypes.EMPTY, null);
				}
				
			}
		}
		
	}
}
