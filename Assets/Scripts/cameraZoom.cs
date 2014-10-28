using UnityEngine;
using System.Collections;

public class cameraZoom : MonoBehaviour {

	public float distance = 10f;
	private float sensitivityDistance = 500f;
	private float damping = 2.5f;
	private float min = 200;
	private float max = 900;
	private Vector3 ydistance;
	private Vector3 currentLocation;
	
	void  Start ()
	{

	}
	void  Update ()
	{	

		distance -= Input.GetAxis("Mouse ScrollWheel") * sensitivityDistance;
		distance = Mathf.Clamp(distance, min, max);
		ydistance = transform.position;
		ydistance.y = Mathf.Lerp(transform.localPosition.y, distance, Time.deltaTime * damping);
		transform.localPosition = ydistance;
	}
}
