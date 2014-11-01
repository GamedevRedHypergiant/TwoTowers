using UnityEngine;
using System.Collections;

public class CastleHealthBar : MonoBehaviour {

	public Texture2D healthBarFrame;
	public Rect framePosition;

	public Texture2D healthBar;
	public Rect healthBarPosition;

	public Transform castle;
	float maxHealth;
	float health;


	public float healthBarShift;

	// Use this for initialization
	void Start () {
		maxHealth = castle.GetComponent<CastleController> ().Hitpoints;
	}
	
	// Update is called once per frame
	void Update () {
		health = castle.GetComponent<CastleController> ().Hitpoints;
	}

	void OnGUI() {
		drawFrame ();
		drawHealth ();
	}

	void drawFrame() {
		framePosition.x = (Screen.width - framePosition.width)/2 - healthBarShift;
		GUI.DrawTexture (framePosition, healthBarFrame);
	}

	void drawHealth() {
		healthBarPosition.x = framePosition.x;
		healthBarPosition.y = framePosition.y;
		healthBarPosition.height = framePosition.height;
		healthBarPosition.width = framePosition.width * (health / maxHealth);
		GUI.DrawTexture (healthBarPosition, healthBar);
	}
}
