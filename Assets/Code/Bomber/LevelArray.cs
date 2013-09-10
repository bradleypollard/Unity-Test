using UnityEngine;
using System.Collections;

public class LevelArray : MonoBehaviour {
	
	private static int levelX = 11; private static int levelY = 11;
	public static ArrayClass[,] level = new ArrayClass[levelX,levelY];
	public static System.Random rand = new System.Random();
	public GameObject block;
	private System.Random r = new System.Random();

	// Use this for initialization
	void Start () {
		
		fillArray(75);
		
		for (int j = 0; j < levelY; j++) {
			for (int i = 0; i < levelX; i++) {
				if (i % 2 != 0 && j % 2 != 0) {
					level[i,j] = new ArrayClass(ArrayTypes.SOLID, null);
				} else if (level[i,j] == null || i == 0 && j == 0 || i == 0 && j == 1 || i == 1 && j == 0
							|| i == levelX-1 && j == 0 || i == levelX-1 && j == 1 || i == levelX-2 && j == 0
							|| i == 0 && j == levelY-1 || i == 1 && j == levelY-1 || i == 0 && j == levelY-2
							|| i == levelX-1 && j == levelY-1 || i == levelX-1 && j == levelY-2 || i == levelX-2 && j == levelY-1) {
					level[i,j] = new ArrayClass(ArrayTypes.EMPTY, null);
				} else if (level[i,j].Type == ArrayTypes.BLOCK) {
					level[i,j].Obj = createObject(i,j,block,0);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
				
	}
	
	
	private void fillArray(int num) {
		for (int i = 0; i < num; i++) {
			level[r.Next(0,levelX), r.Next(0,levelY)] = new ArrayClass(ArrayTypes.BLOCK, null);
		}
	}
	
	public static GameObject createObject(int x, int y, GameObject o, int rot) {
		int xCoord = x-5; int yCoord = y-5;
		GameObject lastObject = (GameObject)Instantiate(o);
		lastObject.transform.position = new Vector3(xCoord, 0.4f, yCoord);
		lastObject.transform.rotation = Quaternion.Euler (new Vector3(0,rot,0));
		
		return lastObject;
	}
	
}
