using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SolarSystem : MonoBehaviour
{

	public GameObject planet;


	public GameObject spikes;



	public Material line_mat;
	
	// Use this for initialization
	void Start ()
	{







		GameObject orbital = new GameObject ();
		orbital.name = "orbital1";
		orbital.transform.parent = transform;
		Rigidbody2D rb = orbital.AddComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		rb.angularVelocity = 5f;
		float radius = 4f;
		List<float> angles = new List<float> ();
		int count = 15;
		for (int i = 0; i < count; i++) {
			float this_angle = Mathf.Lerp (0f, 360f, i * 1f / count * 1f);
			Debug.Log (this_angle);
			angles.Add (this_angle);
		}
		foreach (float angle in angles) {
			float radians = angle * Mathf.PI / 180;
			Vector2 loc = new Vector2 (Mathf.Cos (radians) * radius, Mathf.Sin (radians) * radius);
			GameObject go = Instantiate (planet, loc, Quaternion.identity) as GameObject;
			go.transform.localScale = Vector3.one * Random.Range (0.5f, 1.0f);
			go.transform.parent = orbital.transform;
			go.SendMessage ("Init", Random.Range (-50f, 50f));
		}

		// create orbital outline
		LineRenderer lr = orbital.AddComponent<LineRenderer> ();
		lr.material = line_mat;
		lr.material.SetColor (0, new Color (1f, 1f, 1f, 0.5f));
		int vertex_count = 90;
		lr.SetWidth (0.02f, 0.02f);
		lr.SetVertexCount (vertex_count + 1);
		for (int i = 0; i < vertex_count+1; i++) {
			float angle = Mathf.Lerp (0f, 360f, i * 1f / vertex_count * 1f);
			float radians = angle * Mathf.PI / 180;
			Vector2 v = new Vector2 (Mathf.Cos (radians) * radius, Mathf.Sin (radians) * radius);
			lr.SetPosition (i, v);
		} 






		orbital = new GameObject ();
		orbital.name = "orbital1";
		orbital.transform.parent = transform;
		rb = orbital.AddComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		rb.angularVelocity = -5f;
		radius = 6f;
		angles = new List<float> ();
		count = 10;
		for (int i = 0; i < count; i++) {
			float this_angle = Mathf.Lerp (0f, 360f, i * 1f / count * 1f);
			angles.Add (this_angle);
		}
		foreach (float angle in angles) {
			float radians = angle * Mathf.PI / 180;
			Vector2 loc = new Vector2 (Mathf.Cos (radians) * radius, Mathf.Sin (radians) * radius);
			GameObject go = Instantiate (spikes, loc, Quaternion.identity) as GameObject;
			go.transform.localScale = Vector3.one * Random.Range (0.5f, 0.6f);
			go.transform.parent = orbital.transform;
			go.SendMessage ("Init", Random.Range (-50f, 50f));
		}
		
		// create orbital outline
		lr = orbital.AddComponent<LineRenderer> ();
		lr.material = line_mat;
		lr.material.SetColor (0, new Color (1f, 1f, 1f, 0.5f));
		vertex_count = 90;
		lr.SetWidth (0.02f, 0.02f);
		lr.SetVertexCount (vertex_count + 1);
		for (int i = 0; i < vertex_count+1; i++) {
			float angle = Mathf.Lerp (0f, 360f, i * 1f / vertex_count * 1f);
			float radians = angle * Mathf.PI / 180;
			Vector2 v = new Vector2 (Mathf.Cos (radians) * radius, Mathf.Sin (radians) * radius);
			lr.SetPosition (i, v);
		} 








		orbital = new GameObject ();
		orbital.name = "orbital1";
		orbital.transform.parent = transform;
		rb = orbital.AddComponent<Rigidbody2D> ();
		rb.isKinematic = true;
		rb.angularVelocity = -5f;
		radius = 8f;
		angles = new List<float> ();
		count = 20;
		for (int i = 0; i < count; i++) {
			float this_angle = Mathf.Lerp (0f, 360f, i * 1f / count * 1f);
			angles.Add (this_angle);
		}
		foreach (float angle in angles) {
			float radians = angle * Mathf.PI / 180;
			Vector2 loc = new Vector2 (Mathf.Cos (radians) * radius, Mathf.Sin (radians) * radius);
			GameObject go = Instantiate (planet, loc, Quaternion.identity) as GameObject;
			go.transform.localScale = Vector3.one * Random.Range (0.5f, 2.0f);
			go.transform.parent = orbital.transform;
			go.SendMessage ("Init", Random.Range (-50f, 50f));
		}
		
		// create orbital outline
		lr = orbital.AddComponent<LineRenderer> ();
		lr.material = line_mat;
		lr.material.SetColor (0, new Color (1f, 1f, 1f, 0.5f));
		vertex_count = 90;
		lr.SetWidth (0.02f, 0.02f);
		lr.SetVertexCount (vertex_count + 1);
		for (int i = 0; i < vertex_count+1; i++) {
			float angle = Mathf.Lerp (0f, 360f, i * 1f / vertex_count * 1f);
			float radians = angle * Mathf.PI / 180;
			Vector2 v = new Vector2 (Mathf.Cos (radians) * radius, Mathf.Sin (radians) * radius);
			lr.SetPosition (i, v);
		} 







	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
