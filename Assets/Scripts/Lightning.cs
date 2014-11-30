using UnityEngine;
using System.Collections;

public class Lightning : MonoBehaviour {

	float thunderLength = 5F;
	float lastThunder = 0F;
	float minTime = 0.5F;
	float thresh = 0.002F;
	private float lastTime = 0;
	public Light myLight;

	// Use this for initialization
	void Start () {
	}


	void Update () {
						if ((Time.time - lastTime) > minTime) {
								if (Random.value > thresh) {
										light.enabled = false;

								} else {
										light.enabled = true;
										audio.Play ();
										lastTime = Time.time;
								}
						}
		}
}
