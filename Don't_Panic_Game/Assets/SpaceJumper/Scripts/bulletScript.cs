using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {
	public float speed = 8.0f;
	
	void Start ()
	{
		rigidbody2D.AddForce(transform.up * speed * 100);
	}

	void Update () {
		if(!renderer.isVisible)
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D()
	{
		Destroy (gameObject);
	}
}
