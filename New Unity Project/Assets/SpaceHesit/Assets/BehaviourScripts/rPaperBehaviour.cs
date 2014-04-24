using UnityEngine;
using System.Collections;

public class rPaperBehaviour : MonoBehaviour 
{
	public AudioClip holePunch;

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			if (Deliver.pick == 0)
			{
				Scoreboard.rPaper = true;
				AudioSource.PlayClipAtPoint(holePunch, transform.position);
				DestroyObject(this.gameObject);
			}
		}
	}
}
