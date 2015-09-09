using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class time : MonoBehaviour
{


	public level l;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		GetComponent<Text> ().text = l.time.ToString ("0.0");
	}
}
