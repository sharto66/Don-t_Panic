using UnityEngine;
using System.Collections;

public class Deliver : MonoBehaviour 
{
	public Font myFont;
	public static bool curMission = false;
	public static int pick = 5;
	public AudioClip slap;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (curMission == false)
			{
				curMission = true;
				PickMission();
				AudioSource.PlayClipAtPoint(slap, transform.position);
			}
		}
	}

	void PickMission()
	{
		pick = Random.Range (0, 4);
		if (pick == 0 && Scoreboard.rComplete == true) 
		{
			pick = 1;
		}

		if (pick == 1 && Scoreboard.gComplete == true) 
		{
			pick = 2;
		}

		if (pick == 2 && Scoreboard.bComplete == true) 
		{
			pick = 3;
		}

		if (pick == 3 && Scoreboard.wComplete == true) 
		{
			pick = 0;
		}
	}

	void OnGUI ()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		if (curMission == true)
		{
			if (pick == 0)
			{
				GUI.Label (new Rect((Screen.width/4)-250, Screen.height/3-60, 300, 400), "<color=red>"+"Get Red Documents\nand then the Quill" + "</color>", myStyle);
				if(Scoreboard.rComplete == true)
				{
					curMission = false;
					Scoreboard.rPaper = false;
				}
			}

			else if (pick == 1)
			{
				GUI.Label (new Rect((Screen.width/4)-250, Screen.height/3-60, 300, 400), "<color=green>"+"Get Green Documents\nand then the and Quill" + "</color>", myStyle);
				if(Scoreboard.gComplete == true)
				{
					curMission = false;
					Scoreboard.gPaper = false;
				}
			}

			else if (pick == 2)
			{
				GUI.Label (new Rect((Screen.width/4)-250, Screen.height/3-60, 300, 400), "<color=cyan>"+"Get Blue Documents\nand then the Quill" + "</color>", myStyle);
				if(Scoreboard.bComplete == true)
				{
					curMission = false;
					Scoreboard.bPaper = false;
				}
			}

			else if (pick == 3)
			{
				GUI.Label (new Rect((Screen.width/4)-250, Screen.height/3-60, 300, 400), "<color=white>"+"Get White Documents\nand then the Quill" + "</color>", myStyle);
				if(Scoreboard.wComplete == true)
				{
					curMission = false;
					Scoreboard.wPaper = false;
				}
			}
		}
	}
}
