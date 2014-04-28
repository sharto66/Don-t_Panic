using UnityEngine;
using System.Collections;

public class Player2control : MonoBehaviour
{
	public AudioClip multiply;
	public AudioClip blop;
	public float MaxSpeed = 4f;


	// Update is called once per frame
	void Update () 
	{
		PlayerMovement ();
	}

	void PlayerMovement()
	{
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate (Vector2.right * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)) 
		{
			transform.Translate (Vector3.left * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.UpArrow))
		{
			transform.Translate (Vector2.up * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.DownArrow))
		{
			transform.Translate (Vector3.down * MaxSpeed * Time.deltaTime);
		}	
		
	/*	if (Input.GetKey (KeyCode.P)) 
		{
			MPMenu.pauseGame = true;
		} */ //causing a serious bug
		
		if (Input.GetKey (KeyCode.E))
		{
			AudioSource.PlayClipAtPoint(blop,transform.position);
			Spawner.difficulty ++ ;
		}
	}

	void OnCollisionEnter2D(Collision2D collider)
	{
		
		if (collider.gameObject.tag == "powerUp1" )
		{
			AudioSource.PlayClipAtPoint(multiply,transform.position);
			MPScore.plyr2score = MPScore.plyr2score * MPScore.multiplier1;
			Destroy (collider.gameObject);
		}
		else if (collider.gameObject.tag == "powerUp" )
		{
			AudioSource.PlayClipAtPoint(multiply,transform.position);
			MPScore.plyr2score = MPScore.plyr2score * MPScore.multiplier2;
			Destroy (collider.gameObject);
		}
	}
}
