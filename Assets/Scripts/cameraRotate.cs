using UnityEngine;
using System.Collections;

public class cameraRotate : MonoBehaviour {

	float speed = 40f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftBracket)) {
			transform.Rotate (Vector3.back * speed * Time.deltaTime);
		} else if (Input.GetKey(KeyCode.RightBracket)) {
				transform.Rotate (Vector3.forward * speed * Time.deltaTime);
		}
	}
}