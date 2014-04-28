using UnityEngine;
using System.Collections;

public class MenuOther : MonoBehaviour 
{
	public Font myFont;
	public static bool menu = false;

	void Start ()
	{
	}

	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		GUI.color = Color.white;

		if (Input.GetKey (KeyCode.P))
		{
			menu = true;
		}

		if(Movement.endGame == true)
		{ 
			Time.timeScale = 0;
			GUI.Box (new Rect (Screen.width/2-80,Screen.height/2-100,170,250), "Fed to the\n Ravenous Bugblatter\n Beast of Traal");
			//GUI.Label(new Rect(Screen.width/2-30, Screen.height/2-30, 126, 80), "Score: " + NewBehaviourScript.score.ToString() + "\n\n" + "High Score: " + highscore);
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Play again") || Input.GetKeyDown("return"))
			{
				Movement.endGame = false;
				Countdown.time = 120.0f;
				Deliver.curMission = false;
				Time.timeScale = 1;
				Application.LoadLevel("Scene1");
			}
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+100, 150, 40), "Main Menu"))
			{
				Application.LoadLevel("Menu");
			}
		}

		if (menu == true)
		{
			Time.timeScale = 0;
			GUI.Box (new Rect (Screen.width/2-80,Screen.height/2-100,170,250), "PAUSE!!");

			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+5, 150, 40), "Resume"))
			{
				menu = false;
				Time.timeScale = 1;
			}
			else if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Play again") || Input.GetKeyDown("return"))
			{
				Application.LoadLevel("Scene1");
				Movement.endGame = false;
				Countdown.time = 120.0f;
				Deliver.curMission = false;
				Time.timeScale = 1;
				menu = false;
			}
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+100, 150, 40), "Main Menu"))
			{
				menu = false;
				Time.timeScale = 1;
				Application.LoadLevel("Menu");
			}
		}
	}
}