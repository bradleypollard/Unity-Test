using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {
	
	private float acc = 0;
	private float rot = 0;
	private int accCount = 0;
	private int rotCount = 0;
	private int waitTime = 10;
	private bool WDown = false;
	private bool SDown = false;
	private bool ADown = false;
	private bool DDown = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		
		if (Input.GetKeyDown(KeyCode.W)) {
			WDown = true;
		} else if (Input.GetKeyUp(KeyCode.W)){
			WDown = false;
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			SDown = true;
		} else if (Input.GetKeyUp(KeyCode.S)) {
			SDown = false;
		}
		if (Input.GetKeyDown(KeyCode.A)) {
			ADown = true;
		} else if (Input.GetKeyUp(KeyCode.A)) {
			ADown = false;
		}
		if (Input.GetKeyDown(KeyCode.D)) {
			DDown = true;
		} else if (Input.GetKeyUp(KeyCode.D)) {
			DDown = false;
		}
		
		if (accCount == 0) {
			if (WDown) {
				if (acc <= 0.1) {
					acc += 0.01f;
					accCount = waitTime;
				}
			} else {
				if (acc > 0) {
					acc = Mathf.Max(acc-0.03f,0);
					accCount = waitTime;
				}
			}
			if (SDown) {
				if (acc >= -0.1) {
					acc += -0.01f;
					accCount = waitTime;
				}
			} else {
				if (acc< 0) {
					acc = Mathf.Max(acc+0.03f,0);
					accCount = waitTime;
				}
			}
		} else {
			accCount--;
		}
		
		if (rotCount == 0) {
			if (DDown) {
				if (rot <= 5) {
					rot += 1;
					rotCount = waitTime;
				}
			} else {
				if (rot > 0) {
					rot = Mathf.Max(rot-3, 0);
					rotCount = waitTime;
				}
			}
			if (ADown) {
				if (rot >= -5) {
					rot += -1;
					rotCount = waitTime;
				}
			} else {
				if (rot < 0) {
					rot = Mathf.Min(rot+3, 0);
					rotCount = waitTime;
				}
			}
		} else {
			rotCount--;	
		}
		
		this.gameObject.transform.Translate(new Vector3(0,0,acc));
		this.gameObject.transform.Rotate(new Vector3(0,rot,0));
			
	}
}
