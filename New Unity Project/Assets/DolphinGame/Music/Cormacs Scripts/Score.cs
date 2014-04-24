using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public static int score = 1;
	public static int multiplier1 = 2;
	public static int multiplier2 = 4;
	public static int dolphinMultiplier = 5;
	//int one = 1;
	// Use this for initialization
	void Start()
	{
		score = 1;
		multiplier1 = 2;
		multiplier2 = 4;
		dolphinMultiplier = 5;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Menu2.endGame == false && Menu2.pauseGame != true)
		{
			if(dolphinMultiplier == 0)
			{
				score++;
			}
			else
			{
				//score = ( one += 1)*(dolphinMultiplier);
				score = score + (1)*(dolphinMultiplier);
			}
		}	

	}


}

