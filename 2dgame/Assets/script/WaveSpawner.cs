using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class WaveSpawner: MonoBehaviour{


	[System.Serializable]
	public class Wave{

		public Enemy[] enemies;
		public int count;
		public float timeBetweenSpwans;

	}
	
	public Wave[] waves; 
	public Transform[] spwanPoints;
	public float timeBetwwnWaves;

	private Wave currentWave;
	private int currentWaveIndex;
	private Transform player;

	private bool finishedSpwan;
	private SceneTransition sceneTransition;


	private void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		StartCoroutine (StartNextWave (currentWaveIndex));
		sceneTransition = FindObjectOfType<SceneTransition> ();
	}
	
	IEnumerator StartNextWave(int index){
		yield return new WaitForSeconds (timeBetwwnWaves);
		StartCoroutine (SpwanWave (index));
	}
	IEnumerator SpwanWave(int index){

		currentWave = waves[index];
		for (int i = 0 ; i < currentWave.count; i++)
		{
			if (player == null)
			{
				yield break;

			}

			Enemy randomEnemy = currentWave.enemies[Random.Range(0,currentWave.enemies.Length)];
			Transform randomSpot = spwanPoints[Random.Range(0,spwanPoints.Length)];
			Instantiate (randomEnemy, randomSpot.position, randomSpot.rotation);

			if (i == currentWave.count - 1) {
				finishedSpwan = true;
			} else {
			
				finishedSpwan = false;
			}


			yield return new WaitForSeconds(currentWave.timeBetweenSpwans);
		}
	
	}
	private void Update()
	{
		if (finishedSpwan == true && GameObject.FindGameObjectsWithTag ("Enemy").Length == 0) {
			finishedSpwan = false;
			if (currentWaveIndex + 1 < waves.Length) {
				currentWaveIndex++;
				StartCoroutine (StartNextWave (currentWaveIndex));
			
			} else {
			
				sceneTransition.LoadScene ("Win");
			}
		}

	}


}