using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SetInfo : MonoBehaviour {

	public Text warriors;
	public Text mages;

	public Text max_warriors;
	public Text max_mages;

	private int Temp;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		warriors.text = (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getWarriors()).ToString();
		mages.text = (GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerEntities> ().getMages()).ToString();
		max_warriors.text = (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_warriors).ToString ();
		max_mages.text = (GameObject.FindGameObjectWithTag ("GoodCastle").GetComponent<CastleController> ().max_mages).ToString ();
	}
}
