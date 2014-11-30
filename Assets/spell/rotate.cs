using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	public ParticleSystem effect;
	public Projector proj;
	public float speed;
	public bool on;
	private float time = 0;

	// Use this for initialization
	void Start () {
		Instantiate(effect);
		effect.enableEmission = false;
		collider.enabled = false;
		proj.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (on) {
			if (collider.enabled) {
				time += Time.deltaTime;
				if (time >= 2) {
					collider.enabled = false;
					time = 0;
					on = false;
				}
			} else {
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;

				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					Vector3 currentMousePos = new Vector3 (hit.point.x, hit.point.y, hit.point.z);
					transform.position = new Vector3 (currentMousePos.x, 600, currentMousePos.z);
					if (Input.GetMouseButtonDown (0)) {
						Debug.Log (effect.transform.position.x);
						effect.transform.position = new Vector3 (currentMousePos.x, currentMousePos.y + 50, currentMousePos.z);
						effect.Play();
						proj.enabled = false;
						collider.enabled = true;
					}
				}
				transform.Rotate (0, 0, speed);
			}
		}
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Enemy")
			other.GetComponent<CharController> ().Hitpoints -= 50;
	}
}
