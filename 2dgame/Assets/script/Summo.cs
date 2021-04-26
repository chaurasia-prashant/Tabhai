using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Summo: Enemy{



	private Vector2 targetPosition;
	private Animator anim;
	public float timeBetweenSummo;
	private float SummoTime;
	public Enemy enemyToSummo;
	public float attackSpeed;
	public float stopDistance;
	private float attackTime;


	public override void Start()
	{
		base.Start ();
		float randomX = Random.Range (-20,20);
		float randomY = Random.Range (-15,15);
		targetPosition = new Vector2 (randomX, randomY);
		anim = GetComponent<Animator> ();

	}
	
	
	
	
	private void Update()
	{
		if (player != null) {
			if (Vector2.Distance (transform.position, targetPosition) > .5f) {
			
				transform.position = Vector2.MoveTowards (transform.position, targetPosition, speed * Time.deltaTime);
				anim.SetBool ("isRun", true);	
			} else {
			
				anim.SetBool ("isRun", false);
				if (Time.time >= SummoTime) {
					SummoTime = Time.time + timeBetweenSummo;
					anim.SetTrigger("jump"); 
				}
			
			}
			if (Vector2.Distance (transform.position, player.position) < stopDistance) {

				if (Time.time >= attackTime){
					StartCoroutine (Attack ());
					attackTime = Time.time + timeBetweenAttack;
				}
			}
		 
		}

		
		
		
	}
	
	
	
	public void Summon(){

		if (player!= null){

			Instantiate(enemyToSummo, transform.position, transform.rotation);
		}
	}

	IEnumerator Attack(){

		player.GetComponent<PlayerMovement>().TakeDamage (damage);

		Vector2 originalPosition = transform.position;
		Vector2 targetPosition = player.position;

		float percent = 0;
		while (percent <= 1) {
			percent += Time.deltaTime * attackSpeed;
			float formula = (-Mathf.Pow (percent, 2) + percent) * 4;
			transform.position = Vector2.Lerp (originalPosition, targetPosition, formula);
			yield return null;
		}

	}
	
	
}