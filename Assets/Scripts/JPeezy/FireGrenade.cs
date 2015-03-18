﻿using UnityEngine;
using System.Collections;

public class FireGrenade : MonoBehaviour {

	float startTime = 0;
	//can't be longer than 0.5 for some reason !!!!
	public float endTime = 0.5f;
	public bool ended = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		ended = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startTime + endTime)
		{
			if (!ended)
			{
				Fire();
				ended = true;
			}
		}
	}

	void Fire()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.2f);
		
		int i = 0;
		while (i < hitColliders.Length)
        {
        	if (hitColliders[i].transform.parent != null)
            	hitColliders[i].transform.parent.gameObject.SendMessage("OnFire",SendMessageOptions.DontRequireReceiver);
            else
            	hitColliders[i].gameObject.SendMessage("OnFire",SendMessageOptions.DontRequireReceiver);
           	i++;
        }
	}
}
