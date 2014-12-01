using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCastleAI : MonoBehaviour
{

    public GameObject[] SoldiersGood;
    public GameObject[] SoldiersAI;
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
    int GuyCountAI = 0;
    int MageCountAI = 0;
    int TrollCountAI = 0;
    bool Sent = false;
    float AIReactionTime = 5f;
    float NextLoop = 0f;
    
    // Update is called once per frame
    void Update()
    {

        if (NextLoop <= Time.time)
        {
            GuyCount = 0;
            MageCount = 0;
            TrollCount = 0;
            GuyCountAI = 0;
            MageCountAI = 0;
            TrollCountAI = 0;
            currentGold = transform.GetComponent<CastleController>().gold;
            FindAllObjectsGood();
            FindAllObjectsAI();

            if (MageCount <= 2 && MageCount > 0 && !Sent)
            {
                for (int i=0; i<2; ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [0].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [0], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [0].GetComponent<CharController>().price;
                    }
                }  
                if (transform.GetComponent<CastleController>().gold >= troops [1].GetComponent<CharController>().price)
                {
                    Instantiate(troops [1], spawnPos.position, spawnPos.rotation);
                    transform.GetComponent<CastleController>().gold -= troops [1].GetComponent<CharController>().price;
                }
                Sent = true;
            }

            if (GuyCount > 0 && GuyCount < 4 && MageCountAI == 0 && GuyCountAI == 0 && TrollCountAI == 0 && !Sent)
            {
                for (int i=0; i<2; ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [0].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [0], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [0].GetComponent<CharController>().price;
                    }
                }  
                if (transform.GetComponent<CastleController>().gold >= troops [1].GetComponent<CharController>().price)
                {
                    Instantiate(troops [1], spawnPos.position, spawnPos.rotation);
                    transform.GetComponent<CastleController>().gold -= troops [1].GetComponent<CharController>().price;
                }
                Sent = true;
            }
        
            if (GuyCount > 3 && MageCountAI == 0 && GuyCountAI == 0 && TrollCountAI == 0 && !Sent)
            {
                for (int i=0; i<Mathf.FloorToInt((GuyCount/2) -1); ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [2].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [2], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [2].GetComponent<CharController>().price;
                    }
                } 
                Sent = true;
            }

            if (TrollCount == 1 && MageCountAI == 0 && GuyCountAI == 0 && TrollCountAI == 0 && !Sent)
            {
                for (int i=0; i<2; ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [1].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [1], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [1].GetComponent<CharController>().price;
                    }
                }  

                if (transform.GetComponent<CastleController>().gold >= troops [0].GetComponent<CharController>().price)
                {
                    Instantiate(troops [0], spawnPos.position, spawnPos.rotation);
                    transform.GetComponent<CastleController>().gold -= troops [0].GetComponent<CharController>().price;
                }
                Sent = true;
            }
            if (TrollCount > 1 && MageCountAI == 0 && GuyCountAI == 0 && TrollCountAI == 0 && !Sent)
            {
                for (int i=0; i<TrollCount+1; ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [1].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [1], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [1].GetComponent<CharController>().price;
                    }
                }
                if (transform.GetComponent<CastleController>().gold >= troops [2].GetComponent<CharController>().price)
                {
                    Instantiate(troops [2], spawnPos.position, spawnPos.rotation);
                    transform.GetComponent<CastleController>().gold -= troops [2].GetComponent<CharController>().price;
                }
                Sent = true;
            }
            if (MageCount > 2 && MageCountAI == 0 && TrollCountAI == 0 && !Sent)
            {
                for (int i=0; i<MageCount; ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [0].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [0], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [0].GetComponent<CharController>().price;
                    }
                }
                for (int i=0; i<Mathf.FloorToInt((MageCount/3)); ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [2].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [2], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [2].GetComponent<CharController>().price;
                    }
                }
                Sent = true;
            }

            if (MageCount < 2 && MageCount > 2 && MageCountAI == 0 && TrollCountAI == 0 && !Sent)
            {
                for (int i=0; i<MageCount; ++i)
                {
                    if (transform.GetComponent<CastleController>().gold >= troops [1].GetComponent<CharController>().price)
                    {
                        Instantiate(troops [1], spawnPos.position, spawnPos.rotation);
                        transform.GetComponent<CastleController>().gold -= troops [1].GetComponent<CharController>().price;
                    }
                }
                Sent = true;
            }

            if (MageCountAI == 0 && GuyCountAI == 0 && TrollCountAI == 0 && !Sent)
            {              
                if (transform.GetComponent<CastleController>().gold >= troops [0].GetComponent<CharController>().price)
                {
                    Instantiate(troops [0], spawnPos.position, spawnPos.rotation);
                    transform.GetComponent<CastleController>().gold -= troops [0].GetComponent<CharController>().price;
                }

                Sent = true;
            }
            if (MageCountAI != 0 || GuyCountAI != 0 || TrollCountAI != 0 && !Sent)
            {
                if (transform.GetComponent<CastleController>().gold >= troops [1].GetComponent<CharController>().price)
                {
                    Instantiate(troops [1], spawnPos.position, spawnPos.rotation);
                    transform.GetComponent<CastleController>().gold -= troops [1].GetComponent<CharController>().price;
                }
                
                Sent = true;
            }

            NextLoop = Time.time + AIReactionTime;
            Sent = false;
        }
        
        
        
        
        
        //        currentGold = transform.GetComponent<CastleController> ().gold;
//      if (troops.Count > 0) {
//                      if (!diceRolled) {
//                          nextTroop = Random.Range (0, troops.Count);
//                          Debug.Log (nextTroop);
//                          diceRolled = true;
//                      }
//                      if ((troops [nextTroop].GetComponent<CharController> ().price <= currentGold) && (nextBuy <= Time.time)) {
//                              nextBuy = Time.time + troopCooldown;
//                              transform.GetComponent<CastleController> ().gold -= troops [nextTroop].GetComponent<CharController> ().price;
//                              Instantiate (troops [nextTroop], spawnPos.position, spawnPos.rotation); 
//                              diceRolled = false;
//                      }
//              }

    }

    void FindAllObjectsGood()
    {
        SoldiersGood = GameObject.FindGameObjectsWithTag("GoodGuy");
        
        for (int i=0; i<SoldiersGood.Length; ++i)
        {
            if (SoldiersGood [i].GetComponent<CharController>().type == 1)
            {
                ++MageCount;
            } else if (SoldiersGood [i].GetComponent<CharController>().type == 2)
            {
                ++GuyCount;
            } else
            {
                ++TrollCount;
            }
        }
    }

    void FindAllObjectsAI()
    {
        SoldiersAI = GameObject.FindGameObjectsWithTag("Enemy");
        
        for (int i=0; i<SoldiersAI.Length; ++i)
        {
            if (SoldiersAI [i].transform != spawnPos)
            {
                if (SoldiersAI [i].GetComponent<CharController>().type == 1)
                {
                    ++MageCountAI;
                } else if (SoldiersAI [i].GetComponent<CharController>().type == 2)
                {
                    ++GuyCountAI;
                } else
                {
                    ++TrollCountAI;
                }
            }
        }
    }

}
