using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {

	public Button warrior_button;
	public Button magic_button;

	public GameObject warrior_object;
	public GameObject magic_object;

	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ButtonEnable (warrior_button, warrior_object);
		ButtonEnable (magic_button, magic_object);
	}

	private void ButtonEnable(Button button, GameObject friend)
	{
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= friend.GetComponent<CharController> ().price))// && (nextBuy <= Time.time)) 
		{
			button.interactable = true;
		}
		else
		{
			button.interactable = false;
		}
	}

	//execute on button warrior press
	public void warriorButtonClick()
	{
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= warrior_object.GetComponent<CharController> ().price))// && (nextBuy <= Time.time)) 
		{
			GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold -= warrior_object.GetComponent<CharController> ().price;
			player.GetComponent<PlayerEntities> ().incWarriors();
		}
	}
	
	//execute on button magic press
	public void magicButtonClick()
	{
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= magic_object.GetComponent<CharController> ().price))// && (nextBuy <= Time.time)) 
		{
			GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold -= magic_object.GetComponent<CharController> ().price;
		}
	}
}