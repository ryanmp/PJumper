using UnityEngine;
using System.Collections;

public class planet : MonoBehaviour
{

	public float ANGULAR_VELOCITY;

	// Use this for initialization
	void Start ()
	{
		Application.targetFrameRate = 120;
	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Rigidbody2D> ().angularVelocity = ANGULAR_VELOCITY;
	}
}
