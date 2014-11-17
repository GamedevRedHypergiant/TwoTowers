using UnityEngine;
using System.Collections;

public class HidePlayerGui : MonoBehaviour {

	public GameObject playerGUI;

	public void onMouseDown() {
		playerGUI.SetActive (false);
	}
}
