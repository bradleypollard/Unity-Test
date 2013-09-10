using UnityEngine;
using System.Collections;

public class BombCreator : MonoBehaviour {
	
	public GameObject bomb;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		BomberPlayer p = (BomberPlayer)cc.GetComponent("BomberPlayer");
		string button = "Fire1Player" + p.NAME.ToString();
		
		if (Input.GetButtonDown(button)) {
			int x = Mathf.RoundToInt(cc.transform.position.x)+5; int y = Mathf.RoundToInt(cc.transform.position.z)+5;
			if (p.BOMBCNT > 0 && LevelArray.level[x,y].Type == ArrayTypes.EMPTY) {;
				GameObject b = LevelArray.createObject(x,y,bomb,0);
				BombScript s = (BombScript)b.GetComponent("BombScript");
				s.owner = p;
				LevelArray.level[x,y] = new ArrayClass(ArrayTypes.BOMB, b);
				p.BOMBCNT--;
			}
			
		}
		
	}
}
