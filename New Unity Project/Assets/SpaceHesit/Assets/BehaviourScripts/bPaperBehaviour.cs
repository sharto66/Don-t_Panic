using UnityEngine;
using System.Collections;

public class bPaperBehaviour : MonoBehaviour 
{
	public AudioClip holePunch;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Deliver.pick == 2)
			{
				Scoreboard.bPaper = true;
				AudioSource.PlayClipAtPoint(holePunch, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
