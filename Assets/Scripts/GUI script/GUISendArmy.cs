using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GUISendArmy : MonoBehaviour {

	public Text warrior_send_count_text;
	public Text mage_send_count_text;
	public Text troll_send_count_text;

	public Slider slider_warrior;
	public Slider slider_mage;
	public Slider slider_troll;

	public GameObject warrior;
	public GameObject mage;
	public GameObject troll;

	private Transform object_position;
	// Use this for initialization
	void Start () {
		object_position = GameObject.FindGameObjectWithTag ("GoodSpawn").transform;
	}
	
	// Update is called once per frame
	void Update () {
		object_position = GameObject.FindGameObjectWithTag ("GoodSpawn").transform;
		warrior_send_count_text.text = slider_warrior.value.ToString ();
		mage_send_count_text.text = slider_mage.value.ToString ();
		troll_send_count_text.text = slider_troll.value.ToString ();
		slider_mage.maxValue = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getMages();
		slider_warrior.maxValue = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getWarriors();
		slider_troll.maxValue = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getTrolls();
	}

	public void sendArmy ()
	{
		int j = (int) slider_warrior.value;
		for (int i=0; i<j; ++i)
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().decWarriors ();
			Instantiate (warrior, object_position.position, object_position.rotation);
		}

		j = (int) slider_mage.value;
		for (int i=0; i<j; ++i)
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().decMages ();
			Instantiate (mage, object_position.position, object_position.rotation);
		}

		j = (int) slider_troll.value;
		for (int i=0; i<j; ++i)
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().decTrolls ();
			Instantiate (troll, object_position.position, object_position.rotation);
		}

	}


}
