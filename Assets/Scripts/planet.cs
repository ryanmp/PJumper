using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour
{

	public float PlANET_ANGULAR_VELOCITY = 0f;


	void Init (float _PlANET_ANGULAR_VELOCITY)
	{
		PlANET_ANGULAR_VELOCITY = _PlANET_ANGULAR_VELOCITY;
	}

	// Use this for initialization
	void Start ()
	{
		//gameObject.transform.Find ("_planet").GetComponent<Rigidbody2D> ().angularVelocity = PlANET_ANGULAR_VELOCITY;

		/*
		for (int i = 1; i < gameObject.transform.childCount; i++) {
			gameObject.transform.GetChild (i).GetComponent<Rigidbody2D> ().angularVelocity = ORBITALS_ANGULAR_VELOCITIES [i - 1];
		}*/

	}
	
	// Update is called once per frame
	void Update ()
	{
		//gameObject.transform.rotation = Quaternion.Euler (0f, 0f, Mathf.Cos (Time.time) * 360f);
		gameObject.transform.Find ("_planet").transform.Rotate (new Vector3 (0f, 0f, 1f), PlANET_ANGULAR_VELOCITY / 10f);
	}
}
