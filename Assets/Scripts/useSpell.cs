using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class useSpell : MonoBehaviour {
	
	public rotate spellController;
	public Text cd;
	private float time = 0;
	
	void Update(){
		if (time > 0) {
			time -= Time.deltaTime;
			cd.text = "Cooldown :" + (int)time;
		}
		else {
			cd.text = "Ready!";
		}
	}
	
	public void useFireWall(){
		if (time <= 0) {
			spellController.on = true;
			spellController.proj.enabled = true;
			time = 60;
		}
	}
	
}
