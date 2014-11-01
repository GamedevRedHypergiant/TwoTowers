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

	private void OnGUI (){
		buttonPos.x = Screen.width - 150;
		buttonPos.y = Screen.height - 120;
		buttonPos.width = 48;
		buttonPos.height = 48;
		

		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= 10) && (nextBuy <= Time.time)) {
						if (GUI.Button (buttonPos, warriorBuy[0])) {
								nextBuy = Time.time + troopCooldown;
								Instantiate (friend, friendPosition.position, friendPosition.rotation);	
								GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold -= friend.GetComponent<CharController> ().price;

						}
				} else {
				cooldown.x = buttonPos.x;
				cooldown.y = buttonPos.y;
				cooldown.width = 48;
				if (cooldown.height < 0) {
				cooldown.height = 0;
				} else {
					cooldown.height = 48 * ((nextBuy - Time.time)/troopCooldown);
				}
					GUI.Button (buttonPos, warriorBuy[1]);
					GUI.DrawTexture(cooldown, blank);
				}

	}
}