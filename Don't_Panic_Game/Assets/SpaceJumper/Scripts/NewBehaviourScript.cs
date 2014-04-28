using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	public SpriteRenderer prefab;
	public SpriteRenderer bullet;
	//public ParticleRenderer explosion;
	public Vector3 myPos;
	public bool inShip = false;
	public bool moveCamera = false;
	private float startTime;
	private float journeyLength;
	public bool init = false;
	static public int score;
	static float tempScore;
	public float difficulty = 3.0f;
	Vector3 clickedPosition = new Vector3();
	public Font myFont;
	public float speed = 4.0f;
	public bool endGame = false;
	bool sound = true;
	int highscore;
	public AudioClip gameOver;
	public AudioClip laser;
	public Texture2D upArrow;
	public Texture2D downArrow;
	public Texture2D arrow;
	//Vector3 vecP = new Vector3 (200, 0, 0);

	void Start()
	{
		Time.timeScale = 1.0f;
		tempScore = score;
		Invoke ("CheckGame", 15.0f);
	}

	void Update () {
		if (init == true)
		{
			transform.position +=  Vector3.up * speed * Time.deltaTime;
		}
		else
		{
			transform.position +=  ShipSpawn.direction * -1 / ShipSpawn.Ydist * speed * Time.deltaTime;
		}

		if (inShip == true) 
		{
			speed = 0;
			if (Input.GetMouseButtonDown (0) && Input.mousePosition.x > transform.position.x + 100)
			{
				Spawn ();
				inShip = false;
			}
			else if (Input.GetMouseButtonDown (1) && Input.mousePosition.x > transform.position.x + 100)
			{
				Shoot();
				AudioSource.PlayClipAtPoint (laser, transform.position);
			}

			foreach(Touch touch in Input.touches)
			{
				if (touch.phase == TouchPhase.Ended)
				{
					if(touch.position.x < transform.position.x + 300 && touch.position.x > transform.position.x + 100)
					{
						Spawn();
						inShip = false;
					}
				}
			}
			foreach(Touch touchs in Input.touches)
			{
				if (touchs.phase == TouchPhase.Began && touchs.position.x > transform.position.x + 401)
				{
					Shoot();
					AudioSource.PlayClipAtPoint (laser, transform.position);
				}
			}
		}
		if (moveCamera == true)
		{
			float distCovered = (Time.time - startTime) * 3.5f;
			float fracJourney = distCovered / journeyLength;
			Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, transform.position + myPos, fracJourney);
			if(Camera.main.transform.position == transform.position + myPos)
			{
				moveCamera = false;
			}
		}
	}//end Update

	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		GUI.color = Color.white;
		GUI.Label(new Rect(30, 13 ,15, 20), "<color=white>"+score.ToString()+"</color>", myStyle);
		if(ShipSpawn.direction == Vector3.down * ShipSpawn.Ydist)
		{
			arrow = upArrow;
		}
		else if(ShipSpawn.direction == Vector3.up * ShipSpawn.Ydist)
		{
			arrow = downArrow;
		}
		GUI.Label(new Rect (Screen.width/2,20,100,100), new GUIContent(arrow));
		if(endGame == true)
		{
			arrow = null; 
			inShip = false;
			if(sound != false)
			{
				AudioSource.PlayClipAtPoint (gameOver, transform.position);
				sound = false;
			}
			Time.timeScale = 0;
			GUIStyle Style = new GUIStyle();
			Style.font = myFont;
			GUI.color = Color.white;
			highscore = PlayerPrefs.GetInt("High-Score");
			if(score > highscore)
			{
				highscore = score;
				PlayerPrefs.SetInt("High-Score", highscore);
			}
			GUI.Box (new Rect (Screen.width/2-80,Screen.height/2-100,170,250), "<b>YOU ARE A FAILURE</b>");
			GUI.Label(new Rect(Screen.width/2-30, Screen.height/2-30, 126, 80), "Score: " + NewBehaviourScript.score.ToString() + "\n\n" + "High Score: " + highscore);
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Play again") || Input.GetKeyDown("return"))
			{
				Application.LoadLevel("MainScene");
				score = 0;
			}
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+100, 150, 40), "Main Menu"))
			{
				Application.LoadLevel("Menu");
				score = 0;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "bullet" || coll.gameObject.tag == "asteroid" && renderer.isVisible == true)
		{
			//Instantiate(explosion, transform.position, Quaternion.identity);
			endGame = true;
			inShip = false;
		}
		else if(coll.gameObject.tag == "Player")
		{
			score++;
			speed = 0;
			inShip = true;
			moveCamera = true;
			startTime = Time.time;
			journeyLength = Vector3.Distance(Camera.main.transform.position, transform.position + myPos);
		}
	}

	void Spawn()
	{
		clickedPosition = Input.mousePosition;
		//clickedPosition = Input.mousePosition + vecP;
		clickedPosition.z = transform.position.z - Camera.main.transform.position.z;
		clickedPosition = Camera.main.ScreenToWorldPoint(clickedPosition);
		Quaternion q = Quaternion.FromToRotation(Vector3.up, clickedPosition - transform.position );
		Instantiate (prefab, transform.position + (transform.right * 2.0f), q);
	}

	void Shoot()
	{
		clickedPosition = Input.mousePosition;
		clickedPosition.z = transform.position.z - Camera.main.transform.position.z;
		clickedPosition = Camera.main.ScreenToWorldPoint(clickedPosition);
		Quaternion q = Quaternion.FromToRotation(Vector3.up, clickedPosition - transform.position );
		Instantiate (bullet, transform.position + (transform.right * 0.8f), q);
	}

	void CheckGame()
	{
		if (renderer.isVisible != true)
		{
			Destroy(gameObject);
		}

		if (renderer.isVisible)
		{
			endGame = true;
		}
	}

}
