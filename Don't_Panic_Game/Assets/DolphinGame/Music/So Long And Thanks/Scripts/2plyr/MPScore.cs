using UnityEngine;
using System.Collections;

public class MPScore : MonoBehaviour 
{
	public static int plyr1score = 1;
	public static int plyr2score = 1;
	public static int multiplier1 = 2;
	public static int multiplier2 = 4;
	public static int dolphinMultiplier = 0;

	// Use this for initialization
	void Start()
	{
		MPMenu.endGame = false;
		plyr1score = 1;
		plyr2score = 2;
		multiplier1 = 2;
		multiplier2 = 4;
		dolphinMultiplier = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (MPMenu.endGame == false && MPMenu.pauseGame != true)
		{
			if(MPMenu.Plyr1Dead == false)
			{
				plyr1score++;
			}
			if(MPMenu.Plyr2Dead == false)
			{
				plyr2score++;
			}
		}	
		
	}
}
