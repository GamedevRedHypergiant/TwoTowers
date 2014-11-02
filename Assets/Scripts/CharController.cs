using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class CharController : MonoBehaviour {

	public Transform EnemyCastle;

	public List<CharController> targets;
	public CastleController enemyCastle;
	

	int countOfTargets = 0;

	Seeker seeker;
	Path path;
	int currentWaypoint;
	
	Vector3 enemyPos;
	bool hasTarget = false;
	bool hasTargetCastle = false;
	bool targetReached = false;
	bool taskDone = false;
	public bool cantMove = false;
	public bool shouldIFly = false;
	public bool attacksFromRange;
	public Transform projectile;

	CharacterController characterController;

	float nextAttackTime;
	
	//character gameplay values
	public float Speed;
	public float Hitpoints = 100f;
	public float ChanceToBlock = 5f;
	public float AttackSpeed = 0.7f;
	public float Damage = 5f;
	public float price = 10f;

	public Transform goldStorage;

	float goldGivenOnDeath = 5f;

	public Vector3 originalPos;



	// Use this for initialization
	void Start () {
		targets = new List<CharController> ();
		if (gameObject.tag == "GoodGuy") {
			EnemyCastle = GameObject.FindGameObjectWithTag ("BadCastle").transform;
		} else if (gameObject.tag == "Enemy") {
			EnemyCastle = GameObject.FindGameObjectWithTag ("GoodCastle").transform;
		}
		seeker = GetComponent<Seeker> ();
		seeker.StartPath (transform.position, EnemyCastle.position, OnPathComplete);
		if (gameObject.tag == "GoodGuy") {
						goldStorage = GameObject.FindGameObjectWithTag ("BadCastle").transform;
				} else if (gameObject.tag == "Enemy") {
						goldStorage = GameObject.FindGameObjectWithTag ("GoodCastle").transform;
				}
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
			if (attacksFromRange) {
				targetReached = true;
			}
			countOfTargets++;
		} else if (((gameObject.tag == "GoodGuy") && (o.tag == "BadCastle")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodCastle"))) {
			enemyCastle = o.GetComponent<CastleController>();
			hasTargetCastle = true;
			if (attacksFromRange) {
				targetReached = true;
			}
		}
	}

	void OnTriggerExit(Collider o) {
		if ((((gameObject.tag == "GoodGuy") && (o.tag == "Enemy")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodGuy"))) && countOfTargets == 0) {
			hasTarget = false;
		} 

		if (((gameObject.tag == "GoodGuy") && (o.tag == "BadCastle")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodCastle"))) {
			enemyCastle = o.GetComponent<CastleController>();
			hasTargetCastle = false;
			targetReached = false;			
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
				if (targets.Count > 0) {
						if ((targets [0] != null) && (hasTarget)) {
								transform.LookAt (targets [0].transform.position);
								if (Vector3.Distance (transform.position, targets [0].transform.position) > 10f) {
										transform.Translate (Vector3.forward * Time.deltaTime * Speed);
								} else { 
										targetReached = true;
								}
						} else {
								hasTarget = false;
								targets.RemoveAt (0);
								countOfTargets--;
						}
				} else if (hasTargetCastle) {
			transform.LookAt (enemyCastle.transform.position);
			if (Vector3.Distance (transform.position, enemyCastle.transform.position) > 45f) {
				transform.Translate (Vector3.forward * Time.deltaTime * Speed);
			} else { 
				targetReached = true;
			}
				}

		}
	

	void attack() {

		nextAttackTime = Time.time + AttackSpeed;

		bool isBlocked = false;
		if (Random.Range (0, 99) < targets[0].ChanceToBlock) {
						isBlocked = true;
				}


				if (targets [0].Hitpoints <= 0) {
						targets.Remove (targets [0]);
						countOfTargets--;
						if (countOfTargets <= 0) {
								hasTarget = false;
								targetReached = false;
						}
				} else if (!isBlocked) {
			
						if (Vector3.Distance (transform.position, targets [0].transform.position) <= 10f) {
							targetReached = false;
						}

						targets [0].Hitpoints -= Damage;
							if (projectile != null) {
								Instantiate(projectile, targets[0].transform.position, targets[0].transform.rotation);
							}
				} 


						
		animation ["attack"].speed = 0.7f;
		animation.Play("attack");
	}

	void attackCastle() {

				if (enemyCastle.Hitpoints > 0) {
						nextAttackTime = Time.time + AttackSpeed;
						enemyCastle.Hitpoints -= Damage;	

						animation ["attack"].speed = 0.7f;
						animation.Play ("attack");
				} else {
					hasTargetCastle = false;
					taskDone = true;
				}			
		}

	void giveGold() {
		goldStorage.GetComponent<CastleController>().gold += goldGivenOnDeath;
	}

	void die() {
		giveGold ();
		Destroy (gameObject);
	}

	void idle() {
		animation.Play ("idle");
		}

	void cachExplosion() {
		transform.position -= transform.forward * Time.deltaTime * 100;
		if (Vector3.Distance (transform.position, originalPos) > 50f) {
						shouldIFly = false;
						cantMove = false;
				}
	}
	

	// Update is called once per frame
	void Update () {
		transform.position = transform.position + Vector3.zero;
		if (!taskDone && !cantMove) {
						if (!hasTarget && !hasTargetCastle) {
								FollowPath ();
						} else 	if (targetReached) {

								if (Time.time >= nextAttackTime) {
										if (hasTarget) {
												attack ();
										} else if (hasTargetCastle) {
												attackCastle ();
										}	
								}
						} else if (hasTarget || hasTargetCastle) {
								getToTarget ();
						}
				} else if (shouldIFly) {
					cachExplosion();
				} else {
						idle ();
				}



				if (Hitpoints <= 0) {
						die ();
				}
			}		
		}

