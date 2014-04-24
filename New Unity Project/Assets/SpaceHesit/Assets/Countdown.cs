using UnityEngine;
using System.Collections;

public class Countdown : MonoBehaviour 
{
	public Font myFont;
	public static float time = 120;
	public int mins, secs;
	public AudioClip missionImpossible;

	void Start ()
	{
		AudioSource.PlayClipAtPoint(missionImpossible, transform.position);
	}

	void Update()
	{
		time -= Time.deltaTime;
	}

	void OnGUI()
	{
		GUIStyle myStyle = new GUIStyle();
		myStyle.font = myFont;
		GUI.color = Color.white;
		GUI.Box ( new Rect(((Screen.width/4)*3), Screen.height/3-60, 50, 50), "<color=white>" + "Time" + "</color>", myStyle);
		GUI.Label (new Rect(((Screen.width/4)*3), Screen.height/3-45, 50, 50), "<color=white>" + time.ToString("#") + "</color>", myStyle);

		if (time <= 0) 
		{
			Time.timeScale = 0.0f;
			//GUI.Label ();
		}
	}	
}
