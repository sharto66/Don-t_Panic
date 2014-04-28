using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
	//public SpriteRenderer dolphinCentral;
	//public SpriteRenderer dolphinLeft;
	//public SpriteRenderer dolphinRight;
	public AudioClip multiply;
	public AudioClip blop;
	public float MaxSpeed = 4f;
	bool left = true;
	bool right = true;
	bool down = true;

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
		if (Input.GetKey (KeyCode.D) && right == true)
		{
			//Destroy(gameObject);
			//Instantiate(dolphinRight,transform.position +Vector3.down ,Quaternion.identity);
			transform.Translate (Vector2.right * MaxSpeed * Time.deltaTime);
			left = true;
		}
		
		if (Input.GetKey (KeyCode.A) && left == true) 
		{
			//Destroy(gameObject);
			//Instantiate(dolphinLeft,transform.position +Vector3.down ,Quaternion.identity);
			transform.Translate (Vector3.left * MaxSpeed * Time.deltaTime);
			right = true;
		}
		
		if (Input.GetKey (KeyCode.W))
		{
			down = true;
			transform.Translate (Vector2.up * MaxSpeed * Time.deltaTime);
		}
		
		if (Input.GetKey (KeyCode.S) && down == true)
		{
			transform.Translate (Vector3.down * MaxSpeed * Time.deltaTime);
		}	

		/*if (Input.GetKey (KeyCode.P)) 
		{
			Menu.pauseGame = true;
		}*/

		if (Input.GetKey (KeyCode.E))
		{
			AudioSource.PlayClipAtPoint(blop,transform.position);
			Spawner.difficulty ++ ;
		}
		//Destroy (gameObject);
		//Instantiate(dolphinCentral,transform.position +Vector3.down ,Quaternion.identity);
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
		if (collider.gameObject.tag == "left" )
		{
			left = false;
		}
		if (collider.gameObject.tag == "right" )
		{
			right = false;
		}
		if (collider.gameObject.tag == "Finish" )
		{
			down = false;
		}
	}
}