using UnityEngine;
using System;
using System.Collections;

public class CameraFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		iTween.CameraFadeAdd();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDeath() 
	{
		Hashtable hash = new Hashtable();
		hash.Add("amount",1f);
		hash.Add("time",1f);
		hash.Add("oncomplete","FadeIn");
		hash.Add("oncompletetarget",gameObject);
		iTween.CameraFadeTo(hash);
	}

	void FadeIn()
	{
		iTween.CameraFadeTo(0,1f);
	}
}
