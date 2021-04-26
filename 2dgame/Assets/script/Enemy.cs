using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Enemy: MonoBehaviour{

	public int health;

	[HideInInspector]
	public Transform player;
	public float speed;
	public float timeBetweenAttack;
	public int damage;

	public int pickupChance;
	public GameObject[] pickups;

	public virtual void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;

	}
		

	public void TakeDamage (int damageAmount){
	
		health -= damageAmount;

		if (health <= 0) {

			int randomNumber = Random.Range (0, 101);
			if (randomNumber < pickupChance) {
			
				GameObject randomPickup = pickups [Random.Range (0, pickups.Length)];
				Instantiate (randomPickup, transform.position, transform.rotation);
			}

		
			Destroy (gameObject);
		
		}
	}


	
	
	void Update()
	{
		
		
		
		
	}
	
	
	
	
	
	
	
}