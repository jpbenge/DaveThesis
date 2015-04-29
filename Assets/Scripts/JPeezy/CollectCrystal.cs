using UnityEngine;
using System.Collections;

public class CollectCrystal : MonoBehaviour {
	public AudioClip pickupSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player")
		{
			if (pickupSound)
			{
				AudioSource.PlayClipAtPoint(pickupSound, transform.position);
			}

			other.gameObject.SendMessage("OnVictory", SendMessageOptions.RequireReceiver);
			Destroy(gameObject);
			//Show Victory Screen
		}
	}
}
