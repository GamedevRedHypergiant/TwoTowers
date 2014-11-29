using UnityEngine;
using System.Collections;

public class HealthBarDisplay : MonoBehaviour {

	public float maxHealth;
	public float curHealth;
	Rect healthBarPosition;

	public Texture2D healthBar;
	
	public float healthBarLength;
	
	// Use this for initialization
	void Start () {
		healthBarLength = 80;
		maxHealth = gameObject.transform.parent.transform.GetComponent<CharController> ().Hitpoints;

	}
	
	// Update is called once per frame
	void Update () {
		curHealth = gameObject.transform.parent.transform.GetComponent<CharController> ().Hitpoints;
	}

	void OnGUI() {
		drawHealth ();
	}

	void drawHealth() {
		healthBarPosition.x = (Camera.main.WorldToScreenPoint(this.transform.parent.GetComponent<CharController> ().transform.position).x) - healthBarLength / 2;
		healthBarPosition.y = Screen.height - (Camera.main.WorldToScreenPoint(this.transform.parent.GetComponent<CharController> ().transform.position).y);
		healthBarPosition.height = 8;
		healthBarPosition.width = healthBarLength * (curHealth / maxHealth);
		GUI.DrawTexture (healthBarPosition, healthBar);
	}

}
