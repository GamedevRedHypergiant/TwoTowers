using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {
	
	public GameObject projectile;
	public Transform target;
	public Transform[] muzzlePositions;
	public float reloadTime;
	public float turnSpeed;
	public float firePauseTime;
	public float errorAmount;
	
	private float nextFireTime;
	private float nextMoveTime;
	private Quaternion desiredRotation;
	private float aimError;
	private Vector3 aimPoint;
	
	// Use this for initialization
	void Start () {
		//Nothing yet
	}
	
	// Update is called once per frame
	void Update () {
		
		if (target) {
			if(Time.time >= nextMoveTime) {
				
				CalculateAimPosition(target.position);
				muzzlePositions[0].rotation = Quaternion.Lerp(muzzlePositions[0].rotation, desiredRotation, Time.deltaTime * turnSpeed);

			}
			if(Time.time >= nextFireTime)
				FireProjectile();
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if((other.gameObject.tag == "Enemy") || (other.gameObject.tag == "GoodGuy")) {
			nextFireTime = Time.time + (reloadTime * 0.5f);
			target = other.gameObject.transform;
		}
	}
	
	void OnTriggerExit (Collider other) {
		if(other.gameObject.transform == target) {
			target = null;
		}
	}
	
	void CalculateAimPosition (Vector3 targetPos) {
		aimPoint = new Vector3(targetPos.x - muzzlePositions[0].position.x + aimError, targetPos.y - muzzlePositions[0].position.y + aimError, targetPos.z - muzzlePositions[0].position.z + aimError);
		desiredRotation = Quaternion.LookRotation(aimPoint);
	}
	
	void CalculateAimError () {
		aimError = Random.Range(-errorAmount, errorAmount);
	}
	
	void FireProjectile () {
		nextFireTime = Time.time + reloadTime;
		nextMoveTime = Time.time + firePauseTime;
		CalculateAimError();
		
		foreach(Transform theMuzzlePos in muzzlePositions) {
			GameObject bullet = (GameObject)Instantiate(projectile, theMuzzlePos.position, theMuzzlePos.rotation);
		}
	}
}﻿