using UnityEngine;
using System.Collections;

public class GameEnding : MonoBehaviour {

	public float goodHealth;
	public float badHealth;

	public Rect statePos;
	public Rect buttonPos;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		goodHealth = GameObject.FindGameObjectWithTag("GoodCastle").GetComponent<CastleController>().Hitpoints;
		badHealth = GameObject.FindGameObjectWithTag("BadCastle").GetComponent<CastleController>().Hitpoints;
	}

	void OnGUI() {
		useGUILayout = false;
		statePos.x = Screen.width /2;
		statePos.y = Screen.height /2;
		statePos.width = 48;
		statePos.height = 48;

		buttonPos.x = statePos.x;
		buttonPos.y = statePos.y + statePos.height;
		buttonPos.width = 48;
		buttonPos.height = 48;

		if (goodHealth <= 0) {
						GUI.Box (statePos, "Defeat");
						Time.timeScale = 0;
							if (GUI.Button (buttonPos, "Restart")) {
									Time.timeScale = 1;
									Application.LoadLevel (Application.loadedLevel);
									
							}
		} else if (badHealth <= 0) {
								GUI.Box (statePos, "Victory");
								Time.timeScale = 0;
								if (GUI.Button (buttonPos, "NextLevel")) {
									Time.timeScale = 1;
									Application.LoadLevel (3);
								}
						}
	}
}
