using UnityEngine;
using System.Collections;
public class Credits : MonoBehaviour 
{
	public Font myFont;
	public Texture2D button;
	public Texture2D bath;
	
	void OnGUI ()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		myStyle.fontSize = 60;
		GUI.color = Color.red;
		GUI.Label(new Rect(235, 30 ,200, 400), "<color=white>"+ "DON'T PANIC:"+"</color>", myStyle);
		myStyle.fontSize = 25;
		GUI.Label(new Rect(250, 80 ,200, 400), "<color=white>"+ "An anthology in suffering"+"</color>", myStyle);
		myStyle.fontSize = 10;
		
		GUI.Label(new Rect(235, 30 ,200, 400), "<color=white>"+ "Sean Hartnett"+"</color>", myStyle);
		myStyle.fontSize = 25;
		GUI.Label(new Rect(235, 30 ,200, 400), "<color=white>"+ "Shane Fanning"+"</color>", myStyle);
		myStyle.fontSize = 25;
		GUI.Label(new Rect(235, 30 ,200, 400), "<color=white>"+ "Cormac Chisholm"+"</color>", myStyle);
		myStyle.fontSize = 25;
		
		GUI.Label(new Rect(250, 80 ,200, 400), "<color=white>"+ "With Special Thanks to:"+"</color>", myStyle);
		myStyle.fontSize = 10;
		GUI.Label(new Rect(235, 30 ,200, 400), "<color=white>"+ "Bryan Duggan"+"</color>", myStyle);
		myStyle.fontSize = 25;
		
		
		
		if(GUI.Button (new Rect (Screen.width / 2-105, Screen.height - 150, 240, 80), "A Bubble Bath Production"))
		{
			Application.LoadLevel("Menu");
		}
		//GUIContent
	}
}
