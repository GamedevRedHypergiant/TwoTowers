using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCastleAI : MonoBehaviour {

	public List<GameObject> troops;
	public Transform spawnPos;
	public float troopCooldown;
	public float currentGold;
	float nextBuy;
	int nextTroop;
	bool diceRolled = false;


	// Use this for initialization
	void Start () {
		currentGold = transform.GetComponent<CastleController>().gold;
	}
	
	// Update is called once per frame
	void Update () {
		currentGold = transform.GetComponent<CastleController> ().gold;
		if (troops.Count > 0) {
						if (!diceRolled) {
							nextTroop = Random.Range (0, troops.Count);
							Debug.Log (nextTroop);
							diceRolled = true;
						}
						if ((troops [nextTroop].GetComponent<CharController> ().price <= currentGold) && (nextBuy <= Time.time)) {
								nextBuy = Time.time + troopCooldown;
								transform.GetComponent<CastleController> ().gold -= troops [nextTroop].GetComponent<CharController> ().price;
								Instantiate (troops [nextTroop], spawnPos.position, spawnPos.rotation);	
								diceRolled = false;
						}
				}

	}
}
