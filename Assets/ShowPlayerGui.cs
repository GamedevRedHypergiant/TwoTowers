using UnityEngine;
using System.Collections;

public class ShowPlayerGui : MonoBehaviour {

	public GameObject playerGUI;

	void OnMouseDown() {
		playerGUI.SetActive (true);
	}

	// Use this for initialization
	void Start () {
		playerGUI.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {

	}


}
