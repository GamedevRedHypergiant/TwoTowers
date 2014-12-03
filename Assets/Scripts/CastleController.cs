using UnityEngine;
using System.Collections;

public class CastleController : MonoBehaviour {

	//upgradeTower
    public int upgrade_warriors;
    public int upgrade_mages;
    public int upgrade_trolls;
    public int upgrade_health;
    public int upgrade_cost;

    public int start_upgrade_cost = 100;
    public int max_warriors;
	public int max_mages;
	public int max_trolls;

	public float gold;
	public float Hitpoints = 1000f;
	public float reloadTime = 15f;
	public GameObject projectile;

	public Transform[] spawn = new Transform[2];

	public Transform target;

	float nextFireTime;

	float nextGoldGenerateTime;
	float waitTimeToGenerate = 5f;
	public float goldGiven = 5f;

	Vector3 aimPoint;

	Quaternion desiredRotation;

	float turnSpeed = 500;

	int spawner = 0;



	// Use this for initialization
	void Start () {
		nextGoldGenerateTime = Time.time + waitTimeToGenerate;
	}


	
	// Update is called once per frame
	void Update () {
		if (Hitpoints < 0) {
			Hitpoints = 0;
		}
		generateGold ();
		if (target) {				
				CalculateAimPosition(target.position, spawner);
			spawn[spawner].rotation = Quaternion.Lerp(spawn[spawner].rotation, desiredRotation, Time.deltaTime * turnSpeed);
			if(Time.time >= nextFireTime)
				FireProjectile();
		}

	}

	void CalculateSpawner() {
		if (spawner == 0) {
						spawner = 1;
				} else {
						spawner = 0;
				}
	}
	
	void OnTriggerEnter (Collider o) {
		if ((transform.tag == "GoodCastle" && o.gameObject.tag == "Enemy") || (transform.tag == "BadCastle" && o.gameObject.tag == "GoodGuy")) {
			nextFireTime = Time.time + (reloadTime * 0.5f);
			target = o.gameObject.transform;
		}
	}

	void OnTriggerStay (Collider o) {
		if ((transform.tag == "GoodCastle" && o.gameObject.tag == "Enemy") || (transform.tag == "BadCastle" && o.gameObject.tag == "GoodGuy")) {
			target = o.gameObject.transform;
		}
	}
	
	
	
	void OnTriggerExit (Collider other) {
		if(other.gameObject.transform == target) {
			target = null;
		}
	}
	
	void CalculateAimPosition (Vector3 targetPos, int i) {
		aimPoint = new Vector3(targetPos.x - spawn[i].position.x, targetPos.y - spawn[i].position.y, targetPos.z - spawn[i].position.z);
		desiredRotation = Quaternion.LookRotation(aimPoint);
	}
	
	void FireProjectile () {
		CalculateSpawner ();
		nextFireTime = Time.time + reloadTime;
		
		GameObject spell = (GameObject)Instantiate(projectile, spawn[spawner].position, spawn[spawner].rotation);
		SpellController beh = spell.GetComponent<SpellController> ();
		beh.target = target;
		
	}

	void generateGold() {
				if (nextGoldGenerateTime <= Time.time) {
						nextGoldGenerateTime = Time.time + waitTimeToGenerate;
						gold += goldGiven;
				}
		}

    public void ugradeTower()
    {
        if (gold >= upgrade_cost)
        {

            gold -= start_upgrade_cost;
            max_warriors += upgrade_warriors;
            max_mages += upgrade_mages;
            max_trolls += upgrade_trolls;
            Hitpoints += upgrade_health;
            start_upgrade_cost += upgrade_cost;
            goldGiven+=goldGiven;
        }
    }
}
