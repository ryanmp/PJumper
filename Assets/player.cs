using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

	public GameObject on_this_object;
	public float jump_velocity;

	private bool gravity_on = true;
	private float gravity_mag = 20f;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetInput ();

		if (gravity_on) {
			Vector3 gravity_dir = (on_this_object.transform.position - gameObject.transform.position).normalized;
			gameObject.GetComponent<Rigidbody2D> ().AddForce (gravity_dir * gravity_mag);
		}
	}
	
	void GetInput ()
	{
		/// touch input logic
		if (Input.touchCount > 0) {
			foreach (Touch touch in Input.touches) {
				switch (touch.phase) {
				case TouchPhase.Began:
					Jump ();
					break;
				case TouchPhase.Canceled:
					break;
				case TouchPhase.Ended:
					break;
				}
			}
		}
		/// keyboard in put logic
		if (Input.GetKey (KeyCode.Space)) {
			Jump ();
		}
	}


	void Jump ()
	{
		Debug.Log ("jumped?");

		Vector3 dir = (gameObject.transform.position - on_this_object.transform.position).normalized;
		Vector2 j = dir * jump_velocity;
		gravity_on = false;
		gameObject.GetComponent<Rigidbody2D> ().velocity = j;

	}


	void OnCollisionEnter2D (Collision2D c)
	{
		Debug.Log (c.gameObject.name);
		on_this_object = c.gameObject;
		gravity_on = true;

	}

}
