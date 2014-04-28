using UnityEngine;
using System.Collections;

public class rFeatherBehaviour : MonoBehaviour 
{
	public AudioClip pop;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Scoreboard.rPaper == true)
			{
				Scoreboard.rComplete = true;
				AudioSource.PlayClipAtPoint(pop, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
