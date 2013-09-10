using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {
	
	public int remaining;
	public int xDir, yDir;
	public GameObject fire;
	public GameObject firecross;
	public GameObject fireend;
	public float TIMER = 1f;
	
	private int x, y;

	// Use this for initialization
	void Start () {
		x = Mathf.RoundToInt(gameObject.transform.position.x) + 5; 
		y = Mathf.RoundToInt(gameObject.transform.position.z) + 5;
		
		if (remaining > 0) {
			if (xDir ==0 && yDir == 0) {
				createFire(0,-1,x,y,90);
				createFire(0,1,x,y,270);
				createFire(-1,0,x,y,180);
				createFire(1,0,x,y,0);
			} else {
				int ang = 0;
				if      (xDir == 0 && yDir == -1) ang = 90;
				else if (xDir == 0 && yDir == 1)  ang = 270;
				else if (xDir == -1 && yDir == 0) ang = 180;
				else if (xDir == 1 && yDir == 0)  ang = 0;
				
				createFire(xDir,yDir,x,y,ang);
			}
			
		}
			
	}
	
	private void createFire(int i, int j, int x, int y, int rot) {
		if (x+i >= 0 && x+i < 11 && y+j >= 0 && y+j < 11) {
			if (LevelArray.level[x+i,y+j].Type == ArrayTypes.EMPTY) {
				GameObject o;
				if (remaining == 1) {
					o = fireend;
				} else {
					o = fire;
				}
				GameObject s = LevelArray.createObject(x+i,y+j,o,rot);
				LevelArray.level[x+i,y+j] = new ArrayClass(ArrayTypes.FIRE, s);
								
				FireScript f = (FireScript)s.GetComponent("FireScript");
				f.remaining = remaining-1;
				f.xDir = i; f.yDir = j;
			} else if (LevelArray.level[x+i,y+j].Type == ArrayTypes.FIRE) {
				GameObject s = LevelArray.createObject(x+i,y+j,firecross,rot);
				LevelArray.level[x+i,y+j] = new ArrayClass(ArrayTypes.FIRECROSS, s);
								
				FireScript f = (FireScript)s.GetComponent("FireScript");
				f.remaining = remaining-1;
				f.xDir = i; f.yDir = j;
			} else if (LevelArray.level[x+i,y+j].Type == ArrayTypes.BLOCK) {
				BlockScript b = (BlockScript)LevelArray.level[x+i,y+j].Obj.GetComponent("BlockScript");
				b.hit = true;
			} else if (LevelArray.level[x+i,y+j].Type == ArrayTypes.BOMB) {
				BombScript b = (BombScript)LevelArray.level[x+i,y+j].Obj.GetComponent("BombScript");
				b.TIMER = 0;
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		TIMER -= Time.deltaTime;
		
		if (TIMER <=0) {
			Destroy(gameObject);
			LevelArray.level[x,y] = new ArrayClass(ArrayTypes.EMPTY, null);
		}
	}
	
}
