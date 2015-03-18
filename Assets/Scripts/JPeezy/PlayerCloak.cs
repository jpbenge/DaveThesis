using UnityEngine;
using System.Collections;

public class PlayerCloak : MonoBehaviour {

	public Material cloakMat;
	Material regularMat;
	public AudioClip cloakClip;
	public float cloakDuration = 10f;
	float cloakTime;
	bool cloaked;
	public GameObject lerpz;

	// Use this for initialization
	void Start () {
		regularMat = lerpz.renderer.material;
		cloaked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (cloaked && Time.time > cloakTime + cloakDuration)
		{
			cloaked = false;
			lerpz.renderer.material = regularMat;
		}
	}

	void OnCloak() {
		if (cloakClip)
		{
			audio.PlayOneShot(cloakClip, 1f);
		}
		lerpz.renderer.material = cloakMat;
		cloakTime = Time.time;		
		cloaked = true;
	}
}
