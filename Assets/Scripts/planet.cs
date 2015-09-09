using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour
{

	public float PlANET_ANGULAR_VELOCITY;

	public float[] ORBITALS_ANGULAR_VELOCITIES;
	
	// Use this for initialization
	void Start ()
	{
		gameObject.transform.GetChild (0).GetComponent<Rigidbody2D> ().angularVelocity = PlANET_ANGULAR_VELOCITY;

		for (int i = 1; i < gameObject.transform.childCount; i++) {
			gameObject.transform.GetChild (i).GetComponent<Rigidbody2D> ().angularVelocity = ORBITALS_ANGULAR_VELOCITIES [i - 1];
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}
