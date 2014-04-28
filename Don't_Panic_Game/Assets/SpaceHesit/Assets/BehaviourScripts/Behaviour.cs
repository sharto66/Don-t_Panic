using UnityEngine;
using System.Collections;

public class Behaviour : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.name == "HeartOfGold")
		{
			Debug.Log("Hit");
			//Destroy (this.gameObject);
			DestroyObject(this.gameObject);
		}
	}
}
