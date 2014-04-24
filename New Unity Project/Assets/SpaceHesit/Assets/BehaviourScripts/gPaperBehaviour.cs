using UnityEngine;
using System.Collections;

public class gPaperBehaviour : MonoBehaviour 
{
	public AudioClip holePunch;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Deliver.pick == 1)
			{
				Scoreboard.gPaper = true;
				AudioSource.PlayClipAtPoint(holePunch, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
