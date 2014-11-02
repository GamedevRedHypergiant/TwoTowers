using UnityEngine;
using System.Collections;

public class GUI_button : MonoBehaviour 
{


	public Texture2D[] warriorBuy = new Texture2D[2];
	public Texture2D blank;

	public GameObject friend;
	//public Texture box;
	public Transform friendPosition;

	public float troopCooldown;
	float nextBuy;

	public Rect buttonPos;
	public Rect cooldown;

	public float shiftX;

	private void OnGUI (){
		if (Time.timeScale > 0) {
						buttonPos.x = Screen.width - 150 + shiftX;
						buttonPos.y = Screen.height - 120;
						buttonPos.width = 48;
						buttonPos.height = 48;
		

						if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= friend.GetComponent<CharController> ().price) && (nextBuy <= Time.time)) {
								if (GUI.Button (buttonPos, warriorBuy [0])) {
										nextBuy = Time.time + troopCooldown;
										Instantiate (friend, friendPosition.position, friendPosition.rotation);	
										GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold -= friend.GetComponent<CharController> ().price;

								}
						} else {
								cooldown.x = buttonPos.x;
								cooldown.y = buttonPos.y;
								cooldown.width = buttonPos.width;
								cooldown.height = 48 * ((nextBuy - Time.time) / troopCooldown);
								if (cooldown.height < 0) {
										cooldown.height = 0;
								}
								GUI.Button (buttonPos, warriorBuy [1]);
								GUI.DrawTexture (cooldown, blank);
						}
				}
	}
}