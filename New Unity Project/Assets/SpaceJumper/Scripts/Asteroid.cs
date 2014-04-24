using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {
	void Update () {
		Invoke ("VisibityCheck", 1.0f);
	}

	void VisibityCheck()
	{
		if (!renderer.isVisible)
		{
			Destroy (gameObject);
		}
	}
}
