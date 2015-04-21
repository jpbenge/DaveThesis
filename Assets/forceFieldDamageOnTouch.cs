using UnityEngine;
using System.Collections;

public class forceFieldDamageOnTouch : MonoBehaviour {
	float lastHitTime = 0;
	public int damage = 10;
	public AudioClip damageSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player" && Time.time > lastHitTime + 0.25)
		{
			if (damageSound)
			{
				AudioSource.PlayClipAtPoint(damageSound, transform.position);
			}
			other.gameObject.SendMessage("OnHit", damage, SendMessageOptions.DontRequireReceiver);
			other.gameObject.SendMessage("Slam", -2f*other.transform.forward, SendMessageOptions.DontRequireReceiver);
			lastHitTime = Time.time;
		}
	}
}
