using UnityEngine;
using System.Collections;

public class level : MonoBehaviour
{

	public Material line_mat;
	private float line_width = 0.1f;

	public GameObject level_bg;
	private Vector2 corner_pos;

	public float time = 0f;

	// Use this for initialization
	void Start ()
	{

		// global settings
		QualitySettings.antiAliasing = 8;
		Application.targetFrameRate = 120;


		// draw level outline
		corner_pos = new Vector2 (level_bg.transform.localScale.x / 2f, level_bg.transform.localScale.y / 2f);
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

	}
	
	// Update is called once per frame
	void Update ()
	{
		time += Time.deltaTime;
	}
}
