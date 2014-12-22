using UnityEngine;
using System.Collections;

public class DestroyAfterSeconds : MonoBehaviour {
	float seconds = 2f;
	float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startTime+seconds)
		{
			Destroy(gameObject);
		}
	}
}
