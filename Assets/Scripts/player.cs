using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{






	public float jump_velocity;

	private bool gravity_on = true;
	private float gravity_mag = 20f;
	
	private Vector3 starting_pos;
	private float reset_start_time;
	private Vector3 reset_start_pos;
	private float reset_duration = 0.3f;
	private bool reset = false;

	public GameObject start_obj;
	public GameObject end_obj;

	public GameObject death_bounds;

	private GameObject on_this_object;

	public level level;
	
	public AudioClip jump_sound;
	public AudioClip landing_sound;

	private bool is_jumping = false;

	public camera c;


	// Use this for initialization
	void Start ()
	{
		on_this_object = start_obj;
		starting_pos = gameObject.transform.position;
		gameObject.GetComponent<ParticleSystem> ().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update ()
	{


		if (!reset) {
			GetInput ();
			if (gravity_on) {
				Vector3 gravity_dir = (on_this_object.transform.position - gameObject.transform.position).normalized;
				gameObject.GetComponent<Rigidbody2D> ().AddForce (gravity_dir * gravity_mag);
			}
		} else { // resetting!
			float t = (Time.time - reset_start_time) / reset_duration;
			//Debug.Log (t);
			if (t > 1f) {
				gameObject.transform.position = starting_pos;
				gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
				gameObject.GetComponent<MeshRenderer> ().enabled = true;
				on_this_object = start_obj;
				reset = false; // done with reset;
			} else { // apply reset stuff!
				gameObject.transform.position = Vector3.Lerp (reset_start_pos, starting_pos, t);
			}

		}

		CheckBounds ();
	}

	void CheckBounds ()
	{
		/*
		float my_radius = gameObject.transform.localScale.x / 2f;

		if (Mathf.Abs (gameObject.transform.position.x) > (death_bounds.transform.localScale.x / 2f) - my_radius) {
			Reset ();
		} else if (Mathf.Abs (gameObject.transform.position.y) > (death_bounds.transform.localScale.y / 2f) - my_radius) {
			Reset ();
		}*/
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

		if (!is_jumping) {

			gameObject.GetComponent<ParticleSystem> ().enableEmission = true;

			AudioSource audio_source = GetComponent<AudioSource> ();
			AudioClip clip = jump_sound;
			audio_source.clip = clip;
			audio_source.volume = 0.2f;
			audio_source.Play ();
			gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
			Vector3 dir = (gameObject.transform.position - on_this_object.transform.position).normalized;
			Vector2 j = dir * jump_velocity;
			gravity_on = false;
			gameObject.transform.parent = null;
			gameObject.GetComponent<Rigidbody2D> ().velocity = j;
		}

		is_jumping = true;
	}


	void OnCollisionEnter2D (Collision2D c)
	{
		is_jumping = false;
		gameObject.GetComponent<ParticleSystem> ().enableEmission = false;
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		Debug.Log (c.gameObject.name);
		if (c.gameObject.tag == "jumpable") {
			on_this_object = c.gameObject;
			gameObject.transform.parent = c.gameObject.transform;
			gravity_on = true;

			AudioSource audio_source = GetComponent<AudioSource> ();
			AudioClip clip = landing_sound;
			audio_source.clip = clip;
			audio_source.volume = 0.05f;
			audio_source.Play ();


		} else if (c.gameObject.tag == "death") {
			Reset ();
		}

	}


	void Reset ()
	{
		Debug.Log ("reset!");
		//c.shake = 2f;
		reset = true;
		reset_start_time = Time.time;
		reset_start_pos = gameObject.transform.position;
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		gameObject.GetComponent<MeshRenderer> ().enabled = false;
		level.time = 0f;
	}
	
}
