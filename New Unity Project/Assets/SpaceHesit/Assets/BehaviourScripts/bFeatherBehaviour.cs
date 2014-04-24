using UnityEngine;
using System.Collections;

public class bFeatherBehaviour : MonoBehaviour 
{
	public AudioClip pop;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Scoreboard.bPaper == true)
			{
				Scoreboard.bComplete = true;
				AudioSource.PlayClipAtPoint(pop, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
