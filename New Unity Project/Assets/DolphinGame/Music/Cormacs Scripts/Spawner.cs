using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public float powerUpDeliveryTime = 5f;
	public static float difficulty = 5f;
	public float dropRangeLeft;
	public float dropRangeRight;
	public SpriteRenderer Asteroid1;
	public SpriteRenderer Asteroid2;
	public SpriteRenderer Asteroid3;
	public SpriteRenderer AsteroidChoice;
	int i=1;

	public bool spawnpoop = true;

	void Start()
	{
		Time.timeScale = 1;
	}

		// Update is called once per frame
	void Update () 
	{

		i++;
		if( i == 20)
		{
			difficulty++;
			i = 1;
		}

		if (spawnpoop == true) 
		{
			Invoke ("SpawnAsteroid", 5/difficulty);
			spawnpoop = false;
		} 
	}
	void SpawnAsteroid()
	{
		float dropPosX = Random.Range(dropRangeLeft,dropRangeRight);

		Vector3 dropPos = new Vector3(dropPosX,10f,0);

		int random = Random.Range(1,4);
		if (random == 1) 
		{						
			AsteroidChoice = Asteroid1;
		}
		else if (random == 2)
		{
			AsteroidChoice = Asteroid2; 
		}
		else 
		{	
			AsteroidChoice = Asteroid3;
		}

		Instantiate (AsteroidChoice, dropPos, Quaternion.identity);
		spawnpoop = true;

	
	}
}
