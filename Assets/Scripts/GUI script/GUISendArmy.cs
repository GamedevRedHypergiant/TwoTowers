using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUISendArmy : MonoBehaviour {

	public Text warrior_send_count_text;
	public Text mage_send_count_text;

	public Slider slider_warrior;
	public Slider slider_mage;

	public GameObject warrior;
	public Transform warrior_position;
	public GameObject mage;
	public Transform mage_position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		warrior_send_count_text.text = slider_warrior.value.ToString ();
		mage_send_count_text.text = slider_mage.value.ToString ();
		slider_mage.maxValue = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getMages();
		slider_warrior.maxValue = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getWarriors();
	}

	public void sendArmy ()
	{
		int j = (int) slider_warrior.value;
		for (int i=0; i<j; ++i)
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().decWarriors ();
			Instantiate (warrior, warrior_position.position, warrior_position.rotation);
		}

		j = (int) slider_mage.value;
		for (int i=0; i<j; ++i)
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().decMages ();
			Instantiate (mage, mage_position.position, mage_position.rotation);
		}

	}


}
