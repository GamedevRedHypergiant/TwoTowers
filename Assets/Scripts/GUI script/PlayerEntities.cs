using UnityEngine;
using System.Collections;

public class PlayerEntities : MonoBehaviour {

	private int Warriors;
	private int Mages;
	private int Trolls;
	
	// Use this for initialization
	void Start () {
		Warriors = 0;
		Mages = 0;
		Trolls = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void incWarriors()
	{
		++Warriors;
	}

	public void decWarriors()
	{
		--Warriors;
	}

	public int getWarriors()
	{
		return Warriors;
	}

	public void incMages()
	{
		++Mages;
	}

	public void decMages()
	{
		--Mages;
	}
	
	public int getMages()
	{
		return Mages;
	}

	public void incTrolls()
	{
		++Trolls;
	}
	
	public void decTrolls()
	{
		--Trolls;
	}
	
	public int getTrolls()
	{
		return Trolls;
	}


}
