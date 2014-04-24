using UnityEngine;
using System.Collections;

public class ShipSpawn : MonoBehaviour {
	//public SpriteRenderer ship2;
	public SpriteRenderer ship4;
	public SpriteRenderer asteroid;
	SpriteRenderer prefab;
	static public Vector3 direction = new Vector3();
	public float Xdist;
	static public float Ydist = 22.0f;
	Quaternion q;
	int rand;
	public Texture2D upArrow;
	public Texture2D downArrow;
	public Texture2D arrow;

	void SpawnShip()
	{
		Xdist = Random.Range (13.0f, 14.5f);
		int ran = Random.Range(1, 3);
		if (ran == 2)
		{
			direction = Vector3.down * Ydist;
			q = Quaternion.identity;
		}
		else if(ran == 1)
		{
			direction = Vector3.up * Ydist;
			q = Quaternion.AngleAxis(180, Vector3.right);
		}
		/*rand = Random.Range (1, 3);
		if (rand == 1) 
		{
			prefab = ship2;
		}
		else if (rand == 2) 
		{
			prefab = ship4;
		}
		*/
		prefab = ship4;
		Instantiate (prefab, transform.position + (Vector3.right * Xdist) + (direction), q);
	}

	void arrowDirection()
	{
		if(rand == 1)
		{
			arrow = downArrow;
		}
		else if(rand == 2)
		{
			arrow = upArrow;
		}
		GUI.Box(new Rect (Screen.width/2,30,100,100), new GUIContent(arrow));
	}

	void SpawnAsteroid()
	{
		int r = Random.Range (5, 8);
		for(int i = 0; i < r; i++)
		{
			float xdist = Random.Range(7.0f, 16.0f);
			float ydist = Random.Range(-1.75f, 1.75f);
			Instantiate(asteroid, transform.position + (Vector3.right * xdist) + (Vector3.down * ydist), Quaternion.identity);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "ship")
		{
			SpawnShip ();
			SpawnAsteroid ();
		}
	}
}
