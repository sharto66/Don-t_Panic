using UnityEngine;
using System.Collections;

public class wFeatherBehaviour : MonoBehaviour 
{
	public AudioClip pop;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Scoreboard.wPaper == true)
			{
				Scoreboard.wComplete = true;
				AudioSource.PlayClipAtPoint(pop, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
