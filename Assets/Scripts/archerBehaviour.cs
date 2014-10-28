using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class archerBehaviour : MonoBehaviour {
	public Animator animator;
	public bool enemyAttackable = false;
	public bool timeToDie = false;
	
	private float animLayer2;
	

	void Start () {
		animator = GetComponent<Animator>();
		
	}
	
	void OnAnimatorIK(){
		animator.SetLayerWeight(1, 1f);
		animator.SetLayerWeight(2, animLayer2);

		
		
		
	}
	
	void Update () {
			
		}
		
}
	