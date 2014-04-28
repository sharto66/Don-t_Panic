using UnityEngine;
using System.Collections;

public class actorScript : MonoBehaviour {
	public int speed = 5;
	Vector3 startPoint;
	float startTime;
	private float journeyLength;
	public Font myFont;
	int highscore;
	public AudioClip beep;
	public AudioClip gameOver;
	bool gravity;
	bool sound = true;
	bool endGame = false;

	void Start()
	{
		rigidbody2D.AddForce(transform.up * speed * 100);
		int ran = Random.Range(1, 3);
		if (ran == 2)
		{
			rigidbody2D.gravityScale = -0.05f;
			gravity = true;
		}
		else if(ran == 1)
		{
			rigidbody2D.gravityScale = 0.05f;
			gravity = false;
		}
	}

	void OnGUI()
	{
		if (gravity == true)
		{

		}
		if (renderer.isVisible != true || endGame == true)
		{
			speed = 0;
			if(sound != false)
			{
				AudioSource.PlayClipAtPoint (gameOver, transform.position);
				sound = false;
			}
			Time.timeScale = 0;
			GUIStyle myStyle = new GUIStyle();
			myStyle.font = myFont;
			GUI.color = Color.white;
			highscore = PlayerPrefs.GetInt("High-Score");
			if(NewBehaviourScript.score > highscore)
			{
				highscore = NewBehaviourScript.score;
				PlayerPrefs.SetInt("High-Score", highscore);
			}
			GUI.Box (new Rect (Screen.width/2-80,Screen.height/2-100,170,250), "<b>YOU ARE A FAILURE</b>");
			GUI.Label(new Rect(Screen.width/2-30, Screen.height/2-30, 130, 80), "Score: " + NewBehaviourScript.score.ToString() + "\n\n" + "High Score: " + highscore);
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Play again") || Input.GetKeyDown("return"))
			{
				Application.LoadLevel("MainScene");
				NewBehaviourScript.score = 0;
			}
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+100, 150, 40), "Main Menu"))
			{
				Application.LoadLevel("Menu");
				NewBehaviourScript.score = 0;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.tag == "asteroid")
		{
			endGame = true;
		}
		else
		{
			Destroy(gameObject);
			AudioSource.PlayClipAtPoint (beep, transform.position);
		}
	}

}
