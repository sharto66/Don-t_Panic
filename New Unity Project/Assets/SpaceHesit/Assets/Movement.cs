using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	float speed = 8f;
	float rotate = 5f;
	public static bool endGame = false;
	public AudioClip bang;

	// Update is called once per frame
	void Update () 
	{
		if (endGame == false)
		{
			Move ();
		}
	}

	void Move ()
	{
		if(Input.GetKey (KeyCode.D))			
		{
			transform.Rotate(0.0f, 0.0f, -rotate);
		}

		if(Input.GetKey (KeyCode.A))
		{
			transform.Rotate(0.0f, 0.0f, rotate);
		}

		if(Input.GetKey (KeyCode.W))
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}

	}

	void OnGUI()
	{
		if(GUI.RepeatButton(new Rect(50, Screen.height-100, 90, 90), "Go"))
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}
		if(GUI.RepeatButton(new Rect(Screen.width - 100, Screen.height-100, 90, 90), ">"))
		{
			transform.Rotate(0.0f, 0.0f, -rotate);
		}
		if(GUI.RepeatButton(new Rect(Screen.width - 200, Screen.height-100, 90, 90), "<"))
		{
			transform.Rotate(0.0f, 0.0f, rotate);
		}

	}

	void OnTriggerEnter2D(Collider2D collinfo)
	{
		if (collinfo.tag == "VogonFleet")
		{
			AudioSource.PlayClipAtPoint(bang, transform.position);
			endGame = true;
			//DestroyObject(this.gameObject);
		}
		if (collinfo.tag == "barrier")
		{

		}

	}
}