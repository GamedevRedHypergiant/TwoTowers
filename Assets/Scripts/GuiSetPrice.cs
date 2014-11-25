using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiSetPrice : MonoBehaviour {

	public Text warrior_price;
	public Text magic_price;
	public Text troll_price;

	public GameObject warrior;
	public GameObject magic;
	public GameObject troll;

	// Use this for initialization
	void Start () {
		warrior_price.text = (warrior.GetComponent<CharController> ().price).ToString();
		magic_price.text = (magic.GetComponent<CharController> ().price).ToString();
		troll_price.text = (troll.GetComponent<CharController> ().price).ToString();
	}

}
