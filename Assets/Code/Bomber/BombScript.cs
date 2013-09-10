using UnityEngine;
using System.Collections;

public class BombScript : MonoBehaviour {
	
	public GameObject fire;
	public float TIMER = 3f;
	private int x, y;
	public BomberPlayer owner;

	// Use this for initialization
	void Start () {
		x = Mathf.RoundToInt(gameObject.transform.position.x) + 5;
		y = Mathf.RoundToInt(gameObject.transform.position.z) + 5;
	}
	
	// Update is called once per frame
	void Update () {
		TIMER -= Time.deltaTime;
		
		if (TIMER <=0) {
			Destroy(gameObject);
			GameObject s = LevelArray.createObject(x,y,fire,0);
			LevelArray.level[x,y] = new ArrayClass(ArrayTypes.FIRECROSS, s);
			
			FireScript f = (FireScript)s.GetComponent("FireScript");
			f.remaining = owner.BOMBSTR;
			f.xDir = 0; f.yDir = 0;
			
			owner.BOMBCNT++;
		}
	}
}
