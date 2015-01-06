using UnityEngine;
using System.Collections;

public class Ice_Freeze : MonoBehaviour {
	GameObject iceSheet;
	float op = 0f;
	float freezeTime = 0;
	public float freezeDuration = 10f;
	public AudioClip freezeSound;
	public AudioClip thawSound;
	public float soundVolume = 1f;
	bool frozen = false;
	bool thawing = false;
	// Use this for initialization
	void Start () {
		frozen = false;
		thawing = false;
		op = 0f;
		iceSheet = transform.GetChild(0).gameObject;
		iceSheet.renderer.material.SetFloat("_Opacity",op);
	}
	
	// Update is called once per frame
	void Update () {
		if (frozen && Time.time > freezeTime + freezeDuration)
		{
			Thaw();
		}
	}

	void Freeze () {
		if (freezeSound)
			AudioSource.PlayClipAtPoint(freezeSound, transform.position, soundVolume);
		if (frozen)
		{
			if (thawing)
			{
				thawing = false;
			}
			//print("refreeze");
			freezeTime = Time.time;
			frozen = true;
			collider.isTrigger = false;
		}
		else
		{
			//print("freeze");
			freezeTime = Time.time;
			collider.isTrigger = false;
			frozen = true;
			Hashtable hash = new Hashtable();
			hash.Add("from", op);
			hash.Add("to", 1f);
			hash.Add("time", 1f);
			hash.Add("onupdate", "FreezeUpdate");
			hash.Add("onupdatetarget",gameObject);
			iTween.ValueTo(gameObject,hash);
		}
	}

	void FreezeUpdate(float f) {
		//print("freezing or thawing");
		op = f;
		iceSheet.renderer.material.SetFloat("_Opacity",op);
	}

	void ThawDone () {
		if (thawing)
		{
			//print("thawDone");
			collider.isTrigger = true;
			thawing = false;
		}
	}

	void Thaw () {
		if (thawSound)
			AudioSource.PlayClipAtPoint(thawSound, transform.position, soundVolume);
		//print("thaw");
		frozen = false;
		thawing = true;
		Hashtable hash = new Hashtable();
		hash.Add("from", op);
		hash.Add("to", 0f);
		hash.Add("time", 1f);
		hash.Add("onupdate", "FreezeUpdate");
		hash.Add("onupdatetarget",gameObject);
		hash.Add("oncomplete","ThawDone");
		hash.Add("oncompletetarget",gameObject);
		iTween.ValueTo(gameObject,hash);
	}
}
