﻿using UnityEngine;
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
		print ("Warrior!!!");
	}

	public void decWarriors()
	{
		--Warriors;
		print ("Warrior!!!");
	}

	public int getWarriors()
	{
		return Warriors;
	}

	public void incMages()
	{
		++Mages;
		print ("Mages!!!");
	}

	public void decMages()
	{
		--Mages;
		print ("Mages!!!");
	}
	
	public int getMages()
	{
		return Mages;
	}



}
