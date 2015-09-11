using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
	
	public GameObject player;
	private Vector3 init_pos;
	private float cam_y_offset = 2f;

	public float shake = 0f;
	public float shakeAmount = 0.05f;
	public float decreaseFactor = 1.0f;

	// Use this for initialization
	void Start ()
	{
		init_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{


		//// just updates y
		//transform.position = new Vector3 (init_pos.x, player.transform.position.y + cam_y_offset, init_pos.z);


		//// updates both x and y
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + cam_y_offset, init_pos.z);
	
		if (shake > 0f) {
			transform.localPosition += Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		}
	}
}
