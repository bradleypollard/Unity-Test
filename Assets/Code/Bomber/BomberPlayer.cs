using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class BomberPlayer : MonoBehaviour {
	
	public float MAXSPEED = 5.0f;
	public int BOMBSTR = 1;
	public int BOMBCNT = 1;
	
	public int NAME;
	
	private float y = 0f;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (!Screen.lockCursor) {
			Screen.lockCursor = true;	
		}
		
		// Movement
		float z = Input.GetAxis("VerticalPlayer" + NAME.ToString()) * MAXSPEED;
		float x = Input.GetAxis("HorizontalPlayer" + NAME.ToString()) * MAXSPEED;
		
		Vector3 v = transform.rotation * (new Vector3(x,y,z));
		
		cc.Move(v * Time.deltaTime);
		
	}
	
	void OnTriggerEnter(Collider o) {
		if (o.tag == "Fire") {
			Destroy(gameObject);
		} else if (o.tag == "PowerUp") {
			PowerUpScript p = (PowerUpScript)o.GetComponent("PowerUpScript");
			if (p.type == 0) {
				MAXSPEED++;	
			} else if (p.type == 1) {
				BOMBSTR++;
			} else if (p.type == 2) {
				BOMBCNT++;
			}
			LevelArray.level[p.x,p.y] = new ArrayClass(ArrayTypes.EMPTY, null);
			Destroy(o.gameObject);
			
		}
		
	}
	
}
