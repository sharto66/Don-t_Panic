using UnityEngine;
using System.Collections;

public class Scoreboard : MonoBehaviour 
{
	public static bool rPaper, gPaper, bPaper, wPaper, rComplete, gComplete, bComplete, wComplete; 

	void Start ()
	{
		rPaper = false; 
		gPaper = false; 
		bPaper = false; 
		wPaper = false; 
		rComplete = false; 
		gComplete = false; 
		bComplete = false; 
		wComplete = false;
		Time.timeScale = 1;
	}

	void Update () 
	{
		if(rComplete == true && gComplete == true && bComplete == true && wComplete == true)
		{
			Movement.endGame = true;
		}
	}

	void OnGUI()
	{
		if(rComplete == true && gComplete == true && bComplete == true && wComplete == true)
		{
			GUI.Box (new Rect (Screen.width/2-80,Screen.height/2-100,170,250), "Winner");

			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Play again") || Input.GetKeyDown("return"))
			{
				Application.LoadLevel("Scene1");
				Movement.endGame = false;
				Countdown.time = 120.0f;
				Deliver.curMission = false;
				Time.timeScale = 1;
			}
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+100, 150, 40), "Main Menu") || Input.GetKey(KeyCode.M));
			{
				Time.timeScale = 1;
				Deliver.curMission = false;
				Application.LoadLevel("Menu");
			}
		}
	}	
}
