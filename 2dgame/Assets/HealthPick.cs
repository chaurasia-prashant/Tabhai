using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class HealthPick: MonoBehaviour{

	PlayerMovement playerScript;
	public int healAmount;

	private void Start()
	{
		playerScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerMovement> ();
	}
	 
	
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player") {
			playerScript.Heal (healAmount);
			Destroy (gameObject);
		}
	}
	
	
	
	
	
	
	
}