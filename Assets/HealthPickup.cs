using UnityEngine;
using System.Collections;

public class HealthPickup : MonoBehaviour {

	public AudioClip sound;
	public float soundVolume = 1f;
	public int HealthAmount = 50;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player")
		{
			if (sound)
			{
				AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
			}
			other.gameObject.SendMessage("OnHealthPickup",HealthAmount,SendMessageOptions.RequireReceiver);
			Destroy(gameObject);
		}
	}
}
