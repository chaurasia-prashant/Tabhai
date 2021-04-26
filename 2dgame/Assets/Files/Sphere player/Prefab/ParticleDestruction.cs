using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class ParticleDestruction: MonoBehaviour{

	public float lifeTime;

	
	void Start()
	{
		
		Invoke ("DestroyPartical", lifeTime);
	}
	
	
	
	
	void DestroyPartical()
	{
		
		
		Destroy (gameObject);
		
	}
	
	
	
	
	
	
	
}