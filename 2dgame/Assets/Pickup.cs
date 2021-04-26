using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Pickup: MonoBehaviour{

	public Weapon weaponToEquip;




	private void OnTriggerEnter2D(Collider2D collision){
		


		if (collision.tag == "Player") {
			collision.GetComponent<PlayerMovement>().ChangeWeapon(weaponToEquip);
			Destroy(gameObject);
		}
	}
	
	
	
	
	
	
}