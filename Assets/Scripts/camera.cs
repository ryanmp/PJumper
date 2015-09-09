using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour
{
	
	public GameObject player;
	private Vector3 init_pos;

	private float cam_y_offset = 2f;

	// Use this for initialization
	void Start ()
	{
		init_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//transform.position = new Vector3 (init_pos.x, player.transform.position.y + cam_y_offset, init_pos.z);
		transform.position = new Vector3 (player.transform.position.x, player.transform.position.y + cam_y_offset, init_pos.z);
	}
}
