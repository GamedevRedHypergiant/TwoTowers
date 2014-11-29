using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUICreateSpell : MonoBehaviour {

	public GameObject AOE;

	// Use this for initialization
	public void SpawnSpell() {
		Instantiate (AOE);
	}


}
