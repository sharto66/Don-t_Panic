using UnityEngine;
using System.Collections;

public class Player1Control : MonoBehaviour
{

	public AudioClip multiply;
	public AudioClip blop;
	public float MaxSpeed = 4f;

	void Start()
	{
		Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () 
	{
		PlayerMovement();	
	}
	
	void PlayerMovement()
	{
		if (Input.GetKey (KeyCode.D))
		{
			transform.Translate (Vector2.right * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.A)) 
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
			MPMenu.pauseGame = true;
		}*/
		
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
			MPScore.plyr1score = MPScore.plyr1score * MPScore.multiplier1;
			Destroy (collider.gameObject);
		}
		else if (collider.gameObject.tag == "powerUp" )
		{
			AudioSource.PlayClipAtPoint(multiply,transform.position);
			MPScore.plyr1score = MPScore.plyr1score * MPScore.multiplier2;
			Destroy (collider.gameObject);
		}
	}
}