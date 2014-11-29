using UnityEngine;
using System.Collections;

public class SpawnSelector : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.parent.tag == "GoodSpawn") {
			renderer.material.color = new Color(255, 255, 255, 1f);
		} else {
			renderer.material.color = new Color(255, 255, 255, 0.3f);
		}
	}

	void OnMouseOver() {
		GameObject.FindGameObjectWithTag ("GoodSpawn").tag = "SpawnInactive";
		this.transform.parent.tag = "GoodSpawn";
		GameObject newCastle = GameObject.FindGameObjectWithTag ("BadCastleInactive");
		GameObject.FindGameObjectWithTag ("BadCastle").tag = "BadCastleInactive";
		newCastle.tag = "BadCastle";
	}


}
