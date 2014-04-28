using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour 
{
	public float difficulty;
	public SpriteRenderer VogonFleet;
	bool check = true;
	Quaternion q;

	void Update ()
	{
		Harder ();

		if (check == true)
		{
			Invoke("SpawnUp", difficulty);
			Invoke ("SpawnDown", difficulty);
			Invoke("SpawnLeft", difficulty);
			Invoke ("SpawnRight", difficulty);
			check = false;
		}
	}

	void Harder ()
	{
		float count = 4f;
		if(Scoreboard.rComplete == true)
		{
			count = count - 0.25f;
		}
		if(Scoreboard.gComplete == true)
		{
			count = count - 0.25f;
		}
		if(Scoreboard.bComplete == true)
		{
			count = count - 0.25f;
		}
		if(Scoreboard.wComplete == true)
		{
			count = count - 0.25f;
		}

		difficulty = count;
	}

	void SpawnDown ()
	{
		Instantiate(VogonFleet, new Vector3(2.5f, -9.0f, 0.0f), Quaternion.identity);
		check = true;
	}

	void SpawnUp()
	{
		q = Quaternion.AngleAxis (180, Vector3.right);
		Instantiate(VogonFleet, new Vector3(-2.5f, 9.0f, 0.0f), q);
		check = true;
	}

	void SpawnLeft()
	{
		Instantiate(VogonFleet, new Vector3(-20.0f, 2.5f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 270.0f));
		check = true;
	}

	void SpawnRight()
	{
		q = Quaternion.AngleAxis (180, Vector3.right);
		Instantiate(VogonFleet, new Vector3(20.0f, -2.5f, 0.0f), Quaternion.Euler (0.0f, 0.0f, 90.0f));
		check = true;
	}
}
