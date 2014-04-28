using UnityEngine;
using System.Collections;

public class Asteroids : MonoBehaviour 
{

	public AudioClip death;
	public float MoveSpeedY = 2f;
	public SpriteRenderer DeadDolphinSprite;
	public SpriteRenderer DeadDolphinSpritePlyr2;
	bool check = true;

	Quaternion q;

	void Start()
	{

	}
	void Update () 
	{
		if(check == true)
		{
			Invoke ("CheckGame", 6.0f);
			check = false;
		}
	}

	void CheckGame()
	{
		if(renderer.isVisible == false)
		{
			Destroy(gameObject);
		}
		check = true;
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		if (collider.gameObject.tag == "Player" || collider.gameObject.tag=="MainPlayer")
		{
			AudioSource.PlayClipAtPoint(death,transform.position);
			Destroy (collider.gameObject);
			Instantiate(DeadDolphinSprite,transform.position +Vector3.down ,Quaternion.identity);
			Score.dolphinMultiplier--;

		}

		if(collider.gameObject.tag =="MainPlayer")
		{
			Menu.endGame = true;
		}



		if(collider.gameObject.tag == "Finish")
		{
			Destroy(gameObject);
		}
	}

}
