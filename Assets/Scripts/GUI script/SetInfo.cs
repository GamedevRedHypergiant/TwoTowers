using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetInfo : MonoBehaviour {

	public Text warriors;
	public Text mages;
	public Text trolls;

	public Text max_warriors;
	public Text max_mages;
	public Text max_trolls;

	private int Temp;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		warriors.text = (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getWarriors()).ToString();
		mages.text = (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getMages()).ToString();
		trolls.text = (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getTrolls()).ToString();
		max_warriors.text = (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_warriors).ToString ();
		max_mages.text = (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_mages).ToString ();
		max_trolls.text = (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_trolls).ToString ();
	}
}
