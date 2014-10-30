using UnityEngine;
using System.Collections;



public class ProjectileBehaviour : MonoBehaviour {
	
	public float speed = 15;
	public float range = 10;

	public float damage = 3;

	private Transform target;
	private float distance;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		distance += Time.deltaTime * speed;
		if (distance >= range) {
			Destroy(gameObject);
		}
	}
	
	void OnTriggerEnter(Collider o) {
		if ((o.gameObject.tag == "GoodGuy") || (o.gameObject.tag == "Enemy")) {
				target = o.transform;
			doDamage(target);
				Destroy (gameObject);
		}
	}
	
	void OnTriggerExit(Collider o) {
		if ((o.gameObject.tag == "Enemy") || (o.gameObject.tag == "GoodGuy")) {
			Destroy (gameObject);
		}
	}

	void doDamage(Transform target) {
		target.GetComponent<CharController> ().Hitpoints -= damage;
		}
}
