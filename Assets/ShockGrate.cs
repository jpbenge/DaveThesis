using UnityEngine;
using System.Collections;

public class ShockGrate : MonoBehaviour {
	public int damage = 10;
	float lastHitTime = -10;
	public AudioClip hitSound;
	public AudioClip offSound;
	public AudioClip onSound;
	bool enabled = true;
	// Use this for initialization
	void Start () {
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider hit) {
		if (enabled && Time.time > lastHitTime + 0.25 && hit.gameObject.tag == "Player")
		{
			if (hitSound)
			{
				AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);
			}
			hit.gameObject.SendMessage("OnHit", damage, SendMessageOptions.DontRequireReceiver);
			hit.gameObject.SendMessage("Slam", -2f*hit.transform.forward, SendMessageOptions.DontRequireReceiver);
			lastHitTime = Time.time;
		}
	}

	void OnTerminalActivate()
	{
		enabled = true;
		if (onSound)
		{
			AudioSource.PlayClipAtPoint(onSound, transform.position, 1f);
		}
		foreach (Transform t in transform)
		{
			if (t.GetComponent<ParticleEmitter>() != null)
			{
				t.GetComponent<ParticleEmitter>().emit = true;
			}
		}
	}

	void OnTerminalDeactivate()
	{
		enabled = false;
		if (offSound)
		{
			AudioSource.PlayClipAtPoint(offSound, transform.position, 1f);
		}
		foreach (Transform t in transform)
		{
			if (t.GetComponent<ParticleEmitter>() != null)
			{
				t.GetComponent<ParticleEmitter>().emit = false;
			}
		}
	}

	void OnEMP()
	{
		OnTerminalDeactivate();
	}

	void OnShock()
	{
		OnTerminalActivate();
	}
}
