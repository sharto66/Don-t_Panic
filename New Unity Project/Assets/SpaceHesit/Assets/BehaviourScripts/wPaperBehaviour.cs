using UnityEngine;
using System.Collections;

public class wPaperBehaviour : MonoBehaviour 
{
	public AudioClip holePunch;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Deliver.pick == 3)
			{
				Scoreboard.wPaper = true;
				AudioSource.PlayClipAtPoint(holePunch, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
