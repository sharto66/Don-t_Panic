using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	void OnCollisionEnter2D()
	{
		Destroy(gameObject);
	}
}
