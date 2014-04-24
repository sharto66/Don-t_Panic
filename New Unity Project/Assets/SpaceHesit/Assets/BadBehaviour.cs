using UnityEngine;
using System.Collections;

public class BadBehaviour : MonoBehaviour 
{
	float speed = 4f;

	void Update () 
	{
		Move ();
		Invoke ("Check", 1.5f);
	}
	
	void Move ()
	{
		transform.Translate(Vector3.up * speed * Time.deltaTime);
	}

	void Check()
	{
		if(!renderer.isVisible)
		{
			Destroy(gameObject);
		}

	}
}
