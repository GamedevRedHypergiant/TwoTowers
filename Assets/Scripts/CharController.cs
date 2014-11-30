using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;

public class CharController : MonoBehaviour
{
    //Koks karys( mage:1, goodGuy:2, Troll:3)
    public int type;
    private Transform EnemyCastle;
    private List<CharController> Targets;
    private CastleController enemyCastleController;
    private int countOfTargets = 0;
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
    public float damageToTroll;
    public float damageToMage;
    public float damageToWarrior;
    public float damageToTower;
    public float Speed;
    public float Hitpoints = 100f;
    public float ChanceToBlock = 5f;
    public float AttackSpeed = 0.7f;
    public float price = 10f;
    private Transform goldStorage;
    float goldGivenOnDeath = 5f;
    public Vector3 originalPos;
    private bool SetTimeTroll = true;

    // Use this for initialization
    void Start()
    {
        Targets = new List<CharController>();
        if (gameObject.tag == "GoodGuy")
        {
            EnemyCastle = GameObject.FindGameObjectWithTag("BadCastle").transform;
        } else if (gameObject.tag == "Enemy")
        {
            EnemyCastle = GameObject.FindGameObjectWithTag("GoodCastle").transform;
        }
        seeker = GetComponent<Seeker>();
        seeker.StartPath(transform.position, EnemyCastle.position, OnPathComplete);
        if (gameObject.tag == "GoodGuy")
        {
            goldStorage = GameObject.FindGameObjectWithTag("BadCastle").transform;
        } else if (gameObject.tag == "Enemy")
        {
            goldStorage = GameObject.FindGameObjectWithTag("GoodCastle").transform;
        }
        //  characterController = GetComponent<CharacterController> ();
    }

    public void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        } else
        {
            Debug.Log(p.error);
        }
    }

    void OnTriggerEnter(Collider o)
    {
        if (((gameObject.tag == "GoodGuy") && (o.tag == "Enemy")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodGuy")))
        {
            Targets.Add(o.GetComponent<CharController>());
            hasTarget = true;
            if (attacksFromRange)
            {
                targetReached = true;
            }
            countOfTargets++;
        } else if (((gameObject.tag == "GoodGuy") && (o.tag == "BadCastle")) || ((gameObject.tag == "GoodGuy") && (o.tag == "BadCastleInactive")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodCastle")))
        {
            enemyCastleController = o.GetComponent<CastleController>();
            hasTargetCastle = true;
            if (attacksFromRange)
            {
                targetReached = true;
            }
        }
    }

    void OnTriggerExit(Collider o)
    {
        if ((((gameObject.tag == "GoodGuy") && (o.tag == "Enemy")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodGuy"))) && countOfTargets == 0)
        {
            hasTarget = false;
        } 

        if (((gameObject.tag == "GoodGuy") && (o.tag == "BadCastle")) || ((gameObject.tag == "GoodGuy") && (o.tag == "BadCastleInactive")) || ((gameObject.tag == "Enemy") && (o.tag == "GoodCastle")))
        {
            enemyCastleController = o.GetComponent<CastleController>();
            hasTargetCastle = false;
            targetReached = false;          
        }
    }

    void FollowPath()
    {
        if (path == null)
        {
            return;
        }
        
        if (currentWaypoint >= path.vectorPath.Count)
        {
            return;
        }
        
        Vector3 dir = (path.vectorPath [currentWaypoint] - transform.position);
        //characterController.SimpleMove (dir);
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        transform.LookAt(transform.position + dir);
                
        if (Vector3.Distance(transform.position, path.vectorPath [currentWaypoint]) < 10f)
        {
            currentWaypoint++;
                        
        }
        animation ["run"].speed = 0.7f;
        animation.Play("run");
    }

    void getToTarget()
    {
        if (Targets.Count > 0)
        {
            if ((Targets [0] != null) && (hasTarget))
            {
                transform.LookAt(Targets [0].transform.position);
                if (Vector3.Distance(transform.position, Targets [0].transform.position) > 10f)
                {
                    transform.Translate(Vector3.forward * Time.deltaTime * Speed);

                    if ((path != null) && (Vector3.Distance(transform.position, path.vectorPath [currentWaypoint]) < 10f))
                    {
                        currentWaypoint++;
                        
                    }
                } else
                { 
                    targetReached = true;
                }
            

            } else
            {
                hasTarget = false;
                Targets.RemoveAt(0);
                countOfTargets--;
            }
        } else if (hasTargetCastle)
        {
            transform.LookAt(enemyCastleController.transform.position);
            if (Vector3.Distance(transform.position, enemyCastleController.transform.position) > 45f)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            } else
            { 
                targetReached = true;
            }
        }

    }

    void attack()
    {
        for (int i=0; i<Targets.Count; ++i)
        {
            if (Targets [i] == null)
            {
                Targets.Remove(Targets [i]);
                if (Targets.Count == 0)
                {
                    hasTarget = false;
                    targetReached = false;
                }
            }
        }

        if (Targets.Count > 0)
        {

            if (type == 3)
            {
                nextAttackTime = Time.time + (AttackSpeed * 2 / 3);
                SetTimeTroll = true;
            } else
            {
                nextAttackTime = Time.time + AttackSpeed;
            }

            bool isBlocked = false;
            if (Random.Range(0, 99) < Targets [0].ChanceToBlock)
            {
                isBlocked = true;
            }
                        
            if (!isBlocked)
            {                      
                if (type == 3)
                {
                    int i = 0;
                    while (Targets.Count > i)
                    {
                        if (Targets [i] == null)
                        {
                            Targets.Remove(Targets [i]);
                            if (Targets.Count == 0)
                            {
                                hasTarget = false;
                                targetReached = false;
                            }
                        } else
                        {
                        
                            if (Vector3.Distance(transform.position, Targets [i].transform.position) <= 10f)
                            {
                                targetReached = false;
                            }
                                         
                            if (Targets [i].type == 1)
                            {
                                Targets [i].Hitpoints -= damageToMage;
                            } else if (Targets [i].type == 2)
                            {
                                Targets [i].Hitpoints -= damageToWarrior;
                            } else
                            {
                                Targets [i].Hitpoints -= damageToTroll;
                            }

                            if (Targets [i].Hitpoints <= 0)
                            {
                                Targets.Remove(Targets [i]);
                                --i;
                                if (Targets.Count == 0)
                                {
                                    hasTarget = false;
                                    targetReached = false;
                                }
                            }
                            ++i;    
                        }
                    }
                } else
                {
                    if (Vector3.Distance(transform.position, Targets [0].transform.position) <= 10f)
                    {
                        targetReached = false;
                    }
                    
                    if (Targets [0].type == 1)
                    {
                        Targets [0].Hitpoints -= damageToMage;
                    } else if (Targets [0].type == 2)
                    {
                        Targets [0].Hitpoints -= damageToWarrior;
                    } else
                    {
                        Targets [0].Hitpoints -= damageToTroll;
                    }
                    
                    if (projectile != null)
                    {
                        Instantiate(projectile, Targets [0].transform.position, Targets [0].transform.rotation);
                    }
                    
                    if (Targets [0].Hitpoints <= 0)
                    {
                        Targets.Remove(Targets [0]);
                        if (Targets.Count == 0)
                        {
                            hasTarget = false;
                            targetReached = false;
                        }
                    }            
                    animation ["attack"].speed = 0.7f;
                    animation.Play("attack");
                }
            }          
        }               
    }

    void attackCastle()
    {

        if (enemyCastleController.Hitpoints > 0)
        {
            nextAttackTime = Time.time + AttackSpeed;
            enemyCastleController.Hitpoints -= damageToTower;   

            animation ["attack"].speed = 0.7f;
            animation.Play("attack");
        } else
        {
            hasTargetCastle = false;
            taskDone = true;
        }           
    }

    void giveGold()
    {
        goldStorage.GetComponent<CastleController>().gold += goldGivenOnDeath;
    }

    void die()
    {
        giveGold();
        Destroy(gameObject);
    }

    void idle()
    {
        animation.Play("idle");
    }

    void cachExplosion()
    {
        transform.position -= transform.forward * Time.deltaTime * 100;
        if (Vector3.Distance(transform.position, originalPos) > 50f)
        {
            shouldIFly = false;
            cantMove = false;
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.zero;
        if (!taskDone && !cantMove)
        {
            if (!hasTarget && !hasTargetCastle)
            {
                FollowPath();
            } else  if (targetReached)
            {

                if (Time.time >= nextAttackTime)
                {                                      
                                        
                    if (hasTarget)
                    {
                        if (SetTimeTroll && type == 3)
                        {
                            animation ["attack"].speed = 0.55f;        
                            animation.Play("attack");
                            SetTimeTroll = false;
                            //kad uzduodant smugi veiktu animcja anksciau
                            nextAttackTime = Time.time + (AttackSpeed / 3);
                        } else

                            attack();

                    } else if (hasTargetCastle)
                    {
                        attackCastle();
                    }   
                }
            } else if (hasTarget || hasTargetCastle)
            {
                getToTarget();
            }
        } else if (shouldIFly)
        {
            cachExplosion();
        } else
        {
            idle();
        }



        if (Hitpoints <= 0)
        {
            die();
        }
    }       
}

