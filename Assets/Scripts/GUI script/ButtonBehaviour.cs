using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonBehaviour : MonoBehaviour {

	public Button warrior_button;
	public Button magic_button;
	public Button troll_button;

	public GameObject warrior_object;
	public GameObject magic_object;
	public GameObject troll_object;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ButtonEnableWarriors ();
		ButtonEnableMages ();
		ButtonEnableTrolls ();
	}

	private void ButtonEnableWarriors()
	{
		//if player have enough money
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= warrior_object.GetComponent<CharController> ().price))
		{
			//if tower has enough space
			if (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_warriors > GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getWarriors())
			{
				warrior_button.interactable = true;
			}
			else
			{
				warrior_button.interactable = false;
			}
		}
		else
		{
			warrior_button.interactable = false;
		}
	}

	private void ButtonEnableMages()
	{
		//if player have enough money
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= magic_object.GetComponent<CharController> ().price))
		{
			//if tower has enough space
			if (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_mages > GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getMages())
			{
				magic_button.interactable = true;
			}
			else
			{
				magic_button.interactable = false;
			}
		}
		else
		{
			magic_button.interactable = false;
		}
	}

	private void ButtonEnableTrolls()
	{
		//if player have enough money
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= troll_object.GetComponent<CharController> ().price))
		{
			//if tower has enough space
			if (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_trolls > GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getTrolls())
			{
				troll_button.interactable = true;
			}
			else
			{
				troll_button.interactable = false;
			}
		}
		else
		{
			troll_button.interactable = false;
		}
	}

	//execute on button warrior press
	public void warriorButtonClick()
	{
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= warrior_object.GetComponent<CharController> ().price))// && (nextBuy <= Time.time)) 
		{
			GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold -= warrior_object.GetComponent<CharController> ().price;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().incWarriors();
		}
	}
	
	//execute on button magic press
	public void magicButtonClick()
	{
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= magic_object.GetComponent<CharController> ().price))// && (nextBuy <= Time.time)) 
		{
			GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold -= magic_object.GetComponent<CharController> ().price;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().incMages();
		}
	}

	public void trollButtonClick()
	{
		if ((GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold >= troll_object.GetComponent<CharController> ().price))// && (nextBuy <= Time.time)) 
		{
			GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().gold -= troll_object.GetComponent<CharController> ().price;
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().incTrolls();
		}
	}
}