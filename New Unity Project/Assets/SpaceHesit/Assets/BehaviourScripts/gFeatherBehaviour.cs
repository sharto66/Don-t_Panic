using UnityEngine;
using System.Collections;

public class gFeatherBehaviour : MonoBehaviour 
{
	public AudioClip pop;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Scoreboard.gPaper == true)
			{
				Scoreboard.gComplete = true;
				AudioSource.PlayClipAtPoint(pop, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
