using UnityEngine;
using System.Collections;



public class SpellController : MonoBehaviour {
	
	public float speed;
	public float range;
	public Transform target;
	public GameObject explosion;
	public float waitToExplode;
	public float explodeTime;
	public float Damage;
	
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
		}
	}
	
//	void OnTriggerStay(Collider o) {
//		if (((gameObject.tag == "GoodSpell") && (o.gameObject.tag == "Enemy")) || ((gameObject.tag == "BadSpell") && (o.gameObject.tag == "GoodGuy"))) {
//			Destroy (gameObject);
//		}
//	}
	
	void Explode() {
		Instantiate (explosion, transform.position, Quaternion.identity);
		target.GetComponent<CharController> ().cantMove = true;
		target.GetComponent<CharController> ().shouldIFly = true;
		target.GetComponent<CharController> ().originalPos = new Vector3 (target.transform.localPosition.x , target.transform.localPosition.y, target.transform.localPosition.z);
		target.GetComponent<CharController> ().Hitpoints -= Damage;
		Destroy (gameObject);
	}
}
