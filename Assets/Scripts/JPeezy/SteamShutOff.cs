﻿using UnityEngine;
using System.Collections;

public class SteamShutOff : MonoBehaviour {

	bool on;
	public int damage = 10;
	ParticleEmitter steam;
	float lastHitTime = 0f;
	public AudioClip hitSound;
	public float reEnableTime = 6f;
	public float rigidForce = 40f;
	// Use this for initialization
	void Start () {
		lastHitTime = 0f;
		steam = GetComponent<ParticleEmitter>();
		on = steam.emit;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTerminalActivate()
	{
		TurnOn();
	}
	void TurnOn()
	{
		steam.emit = true;
		on = true;
	}

	void TurnOff()
	{
		steam.emit = false;
		on = false;
	}
	void OnTerminalDeactivate()
	{
		TurnOff();
	}

	void OnTriggerEnter(Collider hit)
	{
		if (on)
		{
			if (hit.gameObject.tag == "Player" && Time.time > lastHitTime + 0.25 && hit.collider.tag == "Player")
			{
				if (hitSound)
				{
					AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);
				}
				hit.collider.SendMessage("OnHit", damage, SendMessageOptions.DontRequireReceiver);
				hit.collider.SendMessage("Slam", -2f*hit.transform.forward, SendMessageOptions.DontRequireReceiver);
				lastHitTime = Time.time;
			}
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.rigidbody != null)
			{
				other.rigidbody.AddForce(((transform.up*rigidForce)/Vector3.Distance(transform.position,other.transform.position)));
			}	
	}

	void OnWind()
	{
		print("On Wind");
		TurnOff();
		Invoke("TurnOn",reEnableTime);
	}
}
