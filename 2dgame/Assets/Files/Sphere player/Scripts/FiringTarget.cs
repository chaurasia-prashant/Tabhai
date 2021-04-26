using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class FiringTarget: MonoBehaviour{

	public float speed;
	private Rigidbody2D rb2;


	private Vector2 moveAmount;
	private void Start()
	{
		
		rb2 = GetComponent<Rigidbody2D> ();

	}




	private void Update()
	{
		Vector2 moveInput = new Vector2 (Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

		moveAmount = moveInput.normalized*speed;




	}
	private void FixedUpdate()
	{
		rb2.MovePosition (rb2.position + moveAmount*Time.fixedDeltaTime);
	}
		
		
		
	}
	
	
	
	
	
	
	
