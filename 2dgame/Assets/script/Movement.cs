using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Movement: MonoBehaviour{

	public float speed;



	private Vector2 moveAmount;
	private void Start()
	{
		


	}




	private void Update()
	{
		Vector2 moveInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		moveAmount = moveInput.normalized*speed;


	}







}