using UnityEngine;
using System.Collections;

public class MPMenu : MonoBehaviour 
{
	public static bool endGame = false;
	public static bool pauseGame = false;
	public static bool Plyr1Dead = false;
	public static bool Plyr2Dead = false;
	public Font myFont;
	public Font otherFont;
	int highscore;
	int winner ;
	
	// Update is called once per framed
	void Update () 
	{

	}
	
	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		myStyle.fontSize = 35;
		GUI.color = Color.white;
		GUI.Label(new Rect(30, 13 ,15, 20), "<color=cyan>"+MPScore.plyr1score.ToString()+"</color>", myStyle);
		GUI.Label(new Rect(1260, 13 ,15, 20), "<color=magenta>"+MPScore.plyr2score.ToString()+"</color>", myStyle);


		
		GUIStyle otherStyle = new GUIStyle();
		otherStyle.font = otherFont;
		GUI.color = Color.white;
		highscore = PlayerPrefs.GetInt("High Score");
		if(MPScore.plyr1score > highscore)
		{
			highscore = MPScore.plyr1score;
			PlayerPrefs.SetInt("High Score", highscore);
		}	
		else if( MPScore.plyr2score > highscore)
		{
			highscore = MPScore.plyr2score;
			PlayerPrefs.SetInt("High Score", highscore);
		}
		else
		{
		}

		if(endGame == true)
		{
			Time.timeScale = 0;
			GUI.Box (new Rect (Screen.width/2-80,Screen.height/2-80,170,250), "Fin.");
			if(MPScore.plyr1score > MPScore.plyr2score)
			{
				winner = 1;
			}
			else
			{
				winner = 2;
			}
			GUI.Label(new Rect(Screen.width/2-30, Screen.height/2-30, 126, 80), "Player 1: " + MPScore.plyr1score.ToString() + "\n\n" + "Player 2: " + MPScore.plyr2score.ToString() + "\n\n" + "Player " + winner + " wins!");
			 
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Play again") || Input.GetKeyDown("return"))
			{
				winner = 0;
				MPScore.plyr1score = 0;
				MPScore.plyr2score = 0;
				Application.LoadLevel("DolphinLevelMultiplayer");
				Time.timeScale = 1;
				endGame = false;
				Spawner.difficulty = 3;
				Plyr1Dead = false;
				Plyr2Dead = false;
			}
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+100, 150, 40), "Main Menu"))
			{
				Application.LoadLevel("Menu");
			} 
		}
	/*	while(pauseGame == true)
		{
			Time.timeScale = 0;
			GUI.Box ( new Rect (Screen.width/2-80,Screen.height/2-100,170,250),"Paused.");
			
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Resume") || Input.GetKeyDown("return"))
			{
				Time.timeScale = 1;
				pauseGame = false;
			}
		} *///possibly causing crashes 
	}
}
	