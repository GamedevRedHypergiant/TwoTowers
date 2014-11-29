using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshCollider))]

public class MagicSpellController : MonoBehaviour 
{
	
	private Vector3 screenPoint;
	private Vector3 offset;
	float distanceToGround;
	RaycastHit hit;
	Ray ray;
	int layerMask = 1 << 11;

	void Start() {
		transform.Rotate (Vector3.back);
	}

	void Update() {
		// prepare raycast
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, 1000, layerMask))
		{
			if (hit.transform.tag == "Terrain") {
				transform.position = hit.point ;
			}
		}
	}




}