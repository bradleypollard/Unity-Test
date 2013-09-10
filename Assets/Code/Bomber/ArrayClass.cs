using UnityEngine;
using System.Collections;

public class ArrayClass {
	
	public GameObject Obj;
	public ArrayTypes Type;
	
	public ArrayClass(ArrayTypes t, GameObject o) {
		this.Type = t;
		this.Obj = o;
	}
	
}

public enum ArrayTypes { 
	
	EMPTY,
	SOLID,
	BLOCK,
	FIRECROSS,
	FIRE,
	PLACED,
	BOMB,
	POWERUP
	
}
