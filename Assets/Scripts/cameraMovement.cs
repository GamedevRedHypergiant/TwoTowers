using UnityEngine;
using System.Collections;


public class cameraMovement : MonoBehaviour {

	float rotateSpeed = 3.5f;

	float lowestZ = 200f;
	float highestZ = 750f;
	
	float lowestX = 250f;
	float highestX = 750f;

	float delta = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (lowestZ < transform.position.z && transform.position.z < highestZ) { 
						transform.Translate (0, Input.GetAxis ("Vertical") * rotateSpeed, 0);
		//}
		//if (lowestX < transform.position.x && transform.position.x < highestX) { 
						transform.Translate (Input.GetAxis ("Horizontal") * rotateSpeed, 0, 0);
		//		}
	}
}
