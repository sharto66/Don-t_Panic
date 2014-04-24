using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	public AudioClip multiply;
	public AudioClip blop;
	public float MaxSpeed = 2f;
	bool moveLeft = true;


	// Update is called once per frame
	void Update () 
	{
		Vector3 dir = Vector3.zero;
		dir.x = Input.acceleration.x * 5f;
		dir.y = Input.acceleration.y * 5f;
		if (dir.sqrMagnitude > 1)
		{
			dir.Normalize();
		}
		dir *= Time.deltaTime;
		transform.Translate(dir * 5.0f);
		PlayerMovement();	
	}
	
	void PlayerMovement()
	{
		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate (Vector2.right * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.A) && moveLeft == true) 
		{
			transform.Translate (Vector3.left * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.W)) 
		{
			transform.Translate (Vector2.up * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S))
		{
			transform.Translate (Vector3.down * MaxSpeed * Time.deltaTime);
		}	

		/*if (Input.GetKey (KeyCode.P)) 
		{
			Menu2.pauseGame = true;
		}*/

		if (Input.GetKey (KeyCode.E))
		{
			AudioSource.PlayClipAtPoint(blop,transform.position);
			Spawner.difficulty ++ ;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collider)
	{

		if (collider.gameObject.tag == "powerUp1" )//|| collider.gameObject.tag =="beachBall")
		{
			AudioSource.PlayClipAtPoint(multiply,transform.position);
			Score.score = Score.score * Score.multiplier1;
			Destroy (collider.gameObject);
		}
		else if (collider.gameObject.tag == "powerUp" )
		{
			AudioSource.PlayClipAtPoint(multiply,transform.position);
			Score.score = Score.score * Score.multiplier2;
			Destroy (collider.gameObject);
		}
		if(collider.gameObject.tag == "leftWall")
		{
			moveLeft = false;
		}

	}
	void OnCollisionExit2D(Collision2D coll)
	{
		if(coll.gameObject.tag == "leftWall")
		{
			moveLeft = true;
		}
	}

}