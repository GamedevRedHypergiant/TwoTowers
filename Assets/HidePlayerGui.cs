using UnityEngine;
using System.Collections;

public class HidePlayerGui : MonoBehaviour {

	public GameObject playerGUI;

	void OnMouseDown() {
		playerGUI.SetActive (false);
	}
}
