using UnityEngine;
using System.Collections;

public class MenuGUI : MonoBehaviour {
	public Font myFont;
	public Texture2D logo;

	void Start () {
	
	}

	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		myStyle.fontSize = 60;
		GUI.color = Color.red;
		GUI.Label(new Rect(400, 30 ,200, 400), "<color=white>"+ "DON'T PANIC:"+"</color>", myStyle);
		myStyle.fontSize = 25;
		GUI.Label(new Rect(410, 80 ,200, 400), "<color=white>"+ "An anthology in suffering"+"</color>", myStyle);
		myStyle.fontSize = 20;
		GUI.Label (new Rect (Screen.width/2-270, Screen.height-20, 50, 200), "<color=white>A Team BubbleBath production</color>", myStyle);
		myStyle.fontSize = 10;
		if(GUI.Button (new Rect (Screen.width / 2-105, Screen.height / 2-100, 240, 80), "Space Jumper 2: Jump Harder"))
		{
			Application.LoadLevel("MainScene");
		}
		GUI.color = Color.cyan;
		if(GUI.Button (new Rect (Screen.width / 2-105, Screen.height / 2, 240, 80), "So Long And Thanks"))
		{
			Application.LoadLevel("DolphinLevel");
		}
		GUI.color = Color.magenta;
		if(GUI.Button (new Rect (Screen.width / 2-105, Screen.height / 2+100, 240, 80), "Space Heist 4: Tax Deductable"))
		{
			Application.LoadLevel("Scene1");
		}


	}
}
