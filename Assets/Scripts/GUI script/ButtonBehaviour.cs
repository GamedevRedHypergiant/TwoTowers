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
	
    public GameObject attributePanel;
    public Text soldierName;
    public Text soldierInfoDamage;
    public Text soldierInfoElse;

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

    public void onMouseEnter(Button buttonEnter)
    {
        string temp;
        if (buttonEnter == warrior_button)
        {
            ChangeFontColorGui (warrior_button);
            soldierName.text = "Warrior";
            temp = "Damage:\nWarrior: " + warrior_object.GetComponent<CharController>().damageToWarrior.ToString();
            temp += "\nMage: " + warrior_object.GetComponent<CharController>().damageToMage.ToString();
            temp += "\nTroll: " + warrior_object.GetComponent<CharController>().damageToTroll.ToString();
            soldierInfoDamage.text = temp;
            temp = "Normal attack\n";
            temp += "Life: " + warrior_object.GetComponent<CharController>().Hitpoints.ToString();
            soldierInfoElse.text = temp;
        }
        if (buttonEnter == magic_button)
        {
            ChangeFontColorGui (magic_button);
            soldierName.text = "Mage";
            temp = "Damage:\nWarrior: " + magic_object.GetComponent<CharController>().damageToWarrior.ToString();
            temp += "\nMage: " + magic_object.GetComponent<CharController>().damageToMage.ToString();
            temp += "\nTroll: " + magic_object.GetComponent<CharController>().damageToTroll.ToString();
            soldierInfoDamage.text = temp;
            temp = "Spell attack\n";
            temp += "Life: " + magic_object.GetComponent<CharController>().Hitpoints.ToString();
            soldierInfoElse.text = temp;
        }
        if (buttonEnter == troll_button)
        {
            ChangeFontColorGui (troll_button);
            soldierName.text = "Troll";
            temp = "Damage:\nWarrior: " + troll_object.GetComponent<CharController>().damageToWarrior.ToString();
            temp += "\nMage: " + troll_object.GetComponent<CharController>().damageToMage.ToString();
            temp += "\nTroll: " + troll_object.GetComponent<CharController>().damageToTroll.ToString();
            soldierInfoDamage.text = temp;
            temp = "Area attack\n";
            temp += "Life: " + troll_object.GetComponent<CharController>().Hitpoints.ToString();
            soldierInfoElse.text = temp;
        }
        attributePanel.SetActive(true);
    }
    
    public void onMouseExit()
    {
        attributePanel.SetActive(false);
    }
    private void ChangeFontColorGui (Button but)
    {
        if (but.interactable == true)
        {
            soldierName.color = Color.green;
            soldierInfoDamage.color = Color.green;
            soldierInfoElse.color = Color.green;
        } else
        {
            soldierName.color = Color.red;
            soldierInfoDamage.color = Color.red;
            soldierInfoElse.color = Color.red;
        }
    }


}