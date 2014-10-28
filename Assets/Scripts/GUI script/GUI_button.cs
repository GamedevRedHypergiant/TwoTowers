using UnityEngine;
using System.Collections;

public class GUI_button : MonoBehaviour 
{
	
	public GameObject enemy;
	public Transform enemyPosition;

	public GameObject friend;
	public Texture box;
	public Transform friendPosition;

	private void OnGUI (){



		//GUI.Box(new Rect(Screen.width -120, 0, Screen.width, Screen.height), new GUIContent(box));

		if (GUI.Button (new Rect (50, 50, 100, 60), "Send Enemy")) {
			Instantiate(enemy, enemyPosition.position, enemyPosition.rotation);	
		}
		 if (GUI.Button (new Rect (Screen.width - 150, Screen.height - 120, 100, 60), "Send Friend")) {
			Instantiate(friend, friendPosition.position, friendPosition.rotation);	
		}

	}
}