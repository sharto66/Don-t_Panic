using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour 
{ 
	public static bool endGame = false;
	public static bool pauseGame = false;
	public Font myFont;
	int highscore ;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		myStyle.fontSize = 25;
		GUI.color = Color.white;
		GUI.Label(new Rect(30, 13 ,15, 20), "<color=white>"+Score.score.ToString()+"</color>", myStyle);

		GUIStyle Style = new GUIStyle();
		Style.font = myFont;
		GUI.color = Color.white;
		highscore = PlayerPrefs.GetInt("High Score");
		if(Score.score > highscore)
		{
			highscore = Score.score;
			PlayerPrefs.SetInt("High Score", highscore);
		}	




		if(endGame == true)
		{
			Time.timeScale = 0;
			GUI.Box (new Rect (Screen.width/2-80,Screen.height/2-100,170,250), "Fin.");
		
			GUI.Label(new Rect(Screen.width/2-30, Screen.height/2-30, 126, 80), "Score: " + Score.score.ToString() + "\n\n" + "High Score: " + highscore);
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Play again") || Input.GetKeyDown("return"))
			{
				Score.score = 0;
				Application.LoadLevel("DolphinLevel");
				Time.timeScale = 1;
				endGame = false;
				Spawner.difficulty = 3;
			}
			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+100, 150, 40), "Main Menu"))
			{
				Application.LoadLevel("Menu");
				Time.timeScale =1;
			}
		}
		while(pauseGame == true)
		{
			Time.timeScale = 0;
			GUI.Box ( new Rect (Screen.width/2-80,Screen.height/2-100,170,250),"Paused.");

			if(GUI.Button(new Rect(Screen.width/2-69, Screen.height/2+55, 150, 40), "Resume") || Input.GetKeyDown("return"))
			{
				Time.timeScale = 1;
				pauseGame = false;
			}
		}
	}
}