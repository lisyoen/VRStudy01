using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker : MonoBehaviour
{
	public GameObject prefab_bullet_;

	private float spawn_time_ = 0.0f;

	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Spawn Bullets
		spawn_time_ += Time.deltaTime;
		if (spawn_time_ > 1.0f) {
			spawn_time_ = 0.0f;
			GameObject obj_bullet = GameObject.Instantiate (prefab_bullet_, this.transform) as GameObject;
			obj_bullet.transform.localPosition = new Vector3 (Random.Range (-2.0f, 2.0f), Random.Range (0.5f, 3.0f), 30.0f);
		}

		// Move Bullets
		for (int i = 0; i < transform.childCount; i++) {
			Transform child_bullet = transform.GetChild (i);
			child_bullet.Translate (new Vector3 (0, 0, 1));
		}
	}
}
