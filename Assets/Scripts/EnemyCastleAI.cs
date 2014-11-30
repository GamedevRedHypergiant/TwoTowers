using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCastleAI : MonoBehaviour {

    public GameObject[] SoldiersGood;
    public List<GameObject> troops;
	public Transform spawnPos;
	public float troopCooldown;
	public float currentGold;
	float nextBuy;
	int nextTroop;
	bool diceRolled = false;

    int GuyCount = 0;
    int MageCount = 0;
    int TrollCount = 0;

    bool Sent= false;
    

	// Use this for initialization
	void Start () {
		currentGold = transform.GetComponent<CastleController>().gold;
	}
	
	// Update is called once per frame
	void Update () {

        SoldiersGood = GameObject.FindGameObjectsWithTag("GoodGuy");

        for (int i=0; i<SoldiersGood.Length; ++i)
        {
            if (SoldiersGood [i].GetComponent<CharController>().type == 1)
            {
                ++MageCount;
            }else if (SoldiersGood [i].GetComponent<CharController>().type == 2)
            {
                ++GuyCount;
            }else
            {
                ++TrollCount;
            }
        }
        if (!Sent)
        {

            if (GuyCount >= 1)
            {
                Instantiate(troops [0], spawnPos.position, spawnPos.rotation);
                Sent = true;
            }
        
            if (GuyCount > 3)
            {
                Instantiate(troops [2], spawnPos.position, spawnPos.rotation);
                Sent = true;
            }

            if (TrollCount >= 1)
            {
                Instantiate(troops [1], spawnPos.position, spawnPos.rotation);
                Sent = true;
            }
        }
        
        
        
        
        
        
        //        currentGold = transform.GetComponent<CastleController> ().gold;
//		if (troops.Count > 0) {
//						if (!diceRolled) {
//							nextTroop = Random.Range (0, troops.Count);
//							Debug.Log (nextTroop);
//							diceRolled = true;
//						}
//						if ((troops [nextTroop].GetComponent<CharController> ().price <= currentGold) && (nextBuy <= Time.time)) {
//								nextBuy = Time.time + troopCooldown;
//								transform.GetComponent<CastleController> ().gold -= troops [nextTroop].GetComponent<CharController> ().price;
//								Instantiate (troops [nextTroop], spawnPos.position, spawnPos.rotation);	
//								diceRolled = false;
//						}
//				}

	}

    void SendTroll()
    {

    }

    void SendMage()
    {
        
    }

    void SendWarrior()
    {
        
    }
}
