using UnityEngine;
using System.Collections;

public class GUISendArmy : MonoBehaviour {

	public GameObject warrior;
	public Transform warrior_position;
	public GameObject mage;
	public Transform mage_position;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void sendArmy ()
	{
		int j = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getWarriors ();
		for (int i=0; i<j; ++i)
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().decWarriors ();
			Instantiate (warrior, warrior_position.position, warrior_position.rotation);

		}

		j = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getMages ();
		for (int i=0; i<j; ++i)
		{
			GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().decMages ();
			Instantiate (mage, mage_position.position, mage_position.rotation);

		}

	}
}
