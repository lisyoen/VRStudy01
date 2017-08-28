using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMaker : MonoBehaviour
{
	public GameObject prefab_bullet_;

	private float spawn_time_ = 0.0f;

    public int max_bullets_count_ = 50;
    public int bullets_count_ = 0;

	// Use this for initialization
	void Start ()
	{
#if UNITY_ANDROID
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
#elif UNITY_IOS
        iPhoneSettings.screenCanDarken = false;
#endif
        prefab_bullet_.SetActive(false);
    }

	Vector3 NewPosition()
	{
		return new Vector3 (Random.Range (-5.0f, 5.0f), Random.Range (-1.0f, 4.0f), 100.0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Spawn Bullets
		spawn_time_ += Time.deltaTime;

		if (spawn_time_ > 0.02f && max_bullets_count_ >= bullets_count_) {
			spawn_time_ = 0.0f;
			GameObject obj_bullet = GameObject.Instantiate (prefab_bullet_, this.transform) as GameObject;
            obj_bullet.SetActive(true);
			obj_bullet.transform.localPosition = NewPosition ();

            bullets_count_++;
		}

		// Move Bullets
		for (int i = 0; i < transform.childCount; i++) {
			Transform child_bullet = transform.GetChild (i);
            if (child_bullet.localPosition.z > 10.0f)
            {
                child_bullet.Translate(new Vector3(0, 0, 1));
            } /* else if (child_bullet.localPosition.z > 9.0f)
            {
                child_bullet.Translate(new Vector3(0, 0, 0.02f));
            } */ else
            {
                child_bullet.Translate(new Vector3(0, 0, 0.02f));
            }

            if (child_bullet.localPosition.z < -30.0f)
            {
				child_bullet.transform.localPosition = NewPosition ();
            }
		}
	}
}
