using UnityEngine;
using System.Collections;

public class level : MonoBehaviour
{

	public Material line_mat;
	private float line_width = 0.1f;

	public GameObject level_bg;
	private Vector2 corner_pos;

	public float time = 0f;
	
	public GameObject spikes;

	// Use this for initialization
	void Start ()
	{

		// global settings
		QualitySettings.antiAliasing = 8;
		Application.targetFrameRate = 120;

		// draw level outline
		corner_pos = new Vector2 (level_bg.transform.localScale.x / 2f, level_bg.transform.localScale.y / 2f);
		/*
		LineRenderer lr = gameObject.AddComponent<LineRenderer> ();
		lr.material = line_mat;
		Color c1 = new Color (1f, 1f, 1f);
		Color c2 = new Color (1f, 1f, 1f);
		lr.SetColors (c1, c2);
		lr.SetWidth (line_width, line_width);
		lr.useWorldSpace = false;
		lr.SetVertexCount (5);

		Vector3 v1 = new Vector3 (-corner_pos.x, corner_pos.y, 0f);
		lr.SetPosition (0, v1);

		Vector3 v2 = new Vector3 (corner_pos.x, corner_pos.y, 0f);
		lr.SetPosition (1, v2);

		Vector3 v3 = new Vector3 (corner_pos.x, -corner_pos.y, 0f);
		lr.SetPosition (2, v3);

		Vector3 v4 = new Vector3 (-corner_pos.x, -corner_pos.y, 0f);
		lr.SetPosition (3, v4);

		Vector3 v5 = new Vector3 (-corner_pos.x, corner_pos.y, 0f);
		lr.SetPosition (4, v5);
		*/

		// right
		for (int i = (int) -corner_pos.y * 2; i <= (int) corner_pos.y * 2; i++) {
			GameObject temp_go = Instantiate (spikes, new Vector3 (corner_pos.x, i * 0.5f, 0f), Quaternion.identity) as GameObject;
			temp_go.GetComponent<Rigidbody2D> ().angularVelocity = RandRange2 (75f, 200f);
		}
		// left
		for (int i = (int) -corner_pos.y * 2; i < (int) corner_pos.y * 2; i++) {
			GameObject temp_go = Instantiate (spikes, new Vector3 (-corner_pos.x, i * 0.5f, 0f), Quaternion.identity)  as GameObject;
			temp_go.GetComponent<Rigidbody2D> ().angularVelocity = RandRange2 (75f, 200f);
		}

		// 
		for (int i = (int) -corner_pos.x * 2; i < (int) corner_pos.x * 2; i++) {
			GameObject temp_go = Instantiate (spikes, new Vector3 (i * 0.5f, corner_pos.y, 0f), Quaternion.identity)  as GameObject;
			temp_go.GetComponent<Rigidbody2D> ().angularVelocity = RandRange2 (75f, 200f);
		}
		// 
		for (int i = (int) -corner_pos.x * 2; i < (int) corner_pos.x * 2; i++) {
			GameObject temp_go = Instantiate (spikes, new Vector3 (i * 0.5f, -corner_pos.y, 0f), Quaternion.identity)  as GameObject;
			temp_go.GetComponent<Rigidbody2D> ().angularVelocity = RandRange2 (75f, 200f);
		}




	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
	}


	float RandBool ()
	{
		if (Random.value > 0.5f) {
			return 1f;
		} else {
			return -1f;
		}
	}

	float RandRange2 (float _min, float _max)
	{
		float bool_gen = Random.value;
		float orbital_dir = 0f;
		if (bool_gen > 0.5f) {
			orbital_dir = 1f;
		} else {
			orbital_dir = -1f;
		}
		return Random.Range (_min, _max) * orbital_dir;
	}


}
