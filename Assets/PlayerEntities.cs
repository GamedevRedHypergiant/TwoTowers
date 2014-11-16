using UnityEngine;
using System.Collections;

public class PlayerEntities : MonoBehaviour {

	private int Warriors;
	private int Mages;
	
	// Use this for initialization
	void Start () {
		Warriors = 0;
		Mages = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void incWarriors()
	{
		++Warriors;
		print ("eina!!!");
	}

	public int getWarriors()
	{
		return Warriors;
	}



}
