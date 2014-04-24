using UnityEngine;
using System.Collections;


public class PowerUpSpawner : MonoBehaviour
{
	public float dropRangeLeft;
	public float dropRangeRight;
	public SpriteRenderer PowerUp1;
	public SpriteRenderer PowerUp2;
	public SpriteRenderer PowerUpChoice;
	public bool spawnpoop = true;

	void Update()
	{
		if(spawnpoop == true)
		{
			Invoke ("DeliverPowerUp",15);
			spawnpoop = false;
		}
	}

	void DeliverPowerUp()
	{
			//Create a random x coordinate for the delivery in the drop range.
		float dropPosX = Random.Range(dropRangeLeft,dropRangeRight);
		
			//Create a position with the random x coordinate.
		Vector3 dropPos = new Vector3(dropPosX,15f,1f);
		
		int random = Random.Range(1,3);
		if (random == 1)
		{				
			PowerUpChoice = PowerUp1;
		}
		else if ( random == 2) 
		{
			PowerUpChoice = PowerUp2; 
			
		}

		Instantiate(PowerUpChoice, dropPos, Quaternion.identity);
		spawnpoop = true;
	}
}