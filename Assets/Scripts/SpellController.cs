using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class SpellController : MonoBehaviour {
	
	public float speed;
	public float range;
	public Transform target;
	public GameObject explosion;
	public float waitToExplode;
	public float explodeTime;
	public float Damage;
	List<Transform> targets = new List<Transform> ();
	
	private float distance;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.forward * Time.deltaTime * speed);
		distance += Time.deltaTime * speed;
		if (distance >= range) {
			Explode();
		}
		
		if (target) {
			transform.LookAt (target);
			if (Vector3.Distance (transform.position, target.transform.position) < 2f) {
				if (Time.time > explodeTime) { 
				Explode();
				}
			}
		} else {
			Explode ();
		}
	}
	
	void OnTriggerEnter(Collider o) {
		if (((gameObject.tag == "GoodSpell") && (o.gameObject.tag == "Enemy")) || ((gameObject.tag == "BadSpell") && (o.gameObject.tag == "GoodGuy"))) {
			explodeTime = Time.time + waitToExplode;
			targets.Add(o.transform);
		}
	}
	
//	void OnTriggerStay(Collider o) {
//		if (((gameObject.tag == "GoodSpell") && (o.gameObject.tag == "Enemy")) || ((gameObject.tag == "BadSpell") && (o.gameObject.tag == "GoodGuy"))) {
//			Destroy (gameObject);
//		}
//	}
	
	void Explode() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		for (int i = 0; i < targets.Count; i++) {
						if (targets [i] != null) {
								targets [i].GetComponent<CharController> ().cantMove = true;
								targets [i].GetComponent<CharController> ().shouldIFly = true;
								targets [i].GetComponent<CharController> ().originalPos = new Vector3 (targets [i].transform.localPosition.x, targets [i].transform.localPosition.y, targets [i].transform.localPosition.z);
								targets [i].GetComponent<CharController> ().Hitpoints -= Damage;
						}
				}
		Destroy (gameObject);
	}
}
