using UnityEngine;
using System.Collections;

public class HealthBarDisplay : MonoBehaviour {

	public float maxHealth;
	public float curHealth;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength = 80;
		maxHealth = gameObject.transform.parent.transform.GetComponent<CharController> ().Hitpoints;;

	}
	
	// Update is called once per frame
	void Update () {
		curHealth = gameObject.transform.parent.transform.GetComponent<CharController> ().Hitpoints;
		transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.up,Camera.main.transform.rotation * Vector3.back);
		Vector3 scale = transform.localScale;
		scale.x = curHealth/maxHealth * 0.3f; // your new value
		transform.localScale = scale;
	}

}
