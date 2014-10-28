using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class CharController : MonoBehaviour {

	public Transform EnemyCastle;

	public List<CharController> targets;
	

	int countOfTargets = 0;

	Seeker seeker;
	Path path;
	int currentWaypoint;
	
	Vector3 enemyPos;
	bool hasTarget = false;
	bool targetReached = false;

	CharacterController characterController;

	float nextAttackTime;
	
	//character gameplay values
	public float Speed;
	public float Hitpoints = 100f;
	public float ChanceToBlock = 5f;
	public float AttackSpeed = 0.7f;
	public float Damage = 5f;


	// Use this for initialization
	void Start () {
		targets = new List<CharController> ();
		seeker = GetComponent<Seeker> ();
		seeker.StartPath (transform.position, EnemyCastle.position, OnPathComplete);
	//	characterController = GetComponent<CharacterController> ();
	}

	public void OnPathComplete(Path p) {
		if (!p.error) {
						path = p;
						currentWaypoint = 0;
				} else {
						Debug.Log (p.error);
				}
	}

	void OnTriggerEnter (Collider o) {
		if (((gameObject.tag == "GoodGuy") && (o.tag == "Enemy")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodGuy"))) {
			targets.Add(o.GetComponent<CharController>());
			hasTarget = true;
			countOfTargets++;
		}
	}

	void OnTriggerExit(Collider o) {
		if ((((gameObject.tag == "GoodGuy") && (o.tag == "Enemy")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodGuy"))) && countOfTargets == 0) {
		//	hasTarget = false;
		}
	}

	void FollowPath() {
				if (path == null) {
						return;
				}
		
				if (currentWaypoint >= path.vectorPath.Count) {
						return;
				}
		
				Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position);
				//characterController.SimpleMove (dir);
		transform.Translate (Vector3.forward * Time.deltaTime * Speed);
				transform.LookAt(transform.position + dir);
				
				if (Vector3.Distance (transform.position, path.vectorPath [currentWaypoint]) < 10f) {
						currentWaypoint++;
						
				}
		animation ["run"].speed = 0.7f;
				animation.Play("run");
		}

	void getToTarget() {
						transform.LookAt (targets [0].transform.position);
						if (Vector3.Distance (transform.position, targets[0].transform.position) > 10f) {
								transform.Translate (Vector3.forward * Time.deltaTime * Speed);
						} else { 
								targetReached = true;
						}
				}

	void attack() {
		nextAttackTime = Time.time + AttackSpeed;

		bool isBlocked = false;
		if (Random.Range (0, 99) < ChanceToBlock) {
						isBlocked = true;
				}

		if(targets[0].Hitpoints <= 0) {
			targets.Remove (targets[0]);
			countOfTargets--;
			if(countOfTargets <= 0) {
				hasTarget = false;
			}
		} else if (!isBlocked) {
			targets [0].Hitpoints -= Damage;
		}


						
		animation ["attack"].speed = 0.7f;
		animation.Play("attack");
	}


	void die() {
		Destroy (gameObject);
	}
	

	// Update is called once per frame
	void Update () {
				
				if (!hasTarget) {
						FollowPath ();
						Debug.Log ("einam");
						
				} else 	if (targetReached) {
						if (Time.time >= nextAttackTime) {
								attack ();
						}
				}
				else if (hasTarget) {
						getToTarget ();
						Debug.Log ("to target");
				} 
				if (Hitpoints <= 0) {
						die ();
				}
			}		
		}

