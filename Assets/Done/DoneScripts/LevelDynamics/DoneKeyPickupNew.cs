 using UnityEngine;
using System.Collections;

public class DoneKeyPickupNew : MonoBehaviour
{
	public AudioClip keyGrab;							// Audioclip to play when the key is picked up.
	
	
	private GameObject player;							// Reference to the player.

	
	
	void Awake ()
	{
		// Setting up the references.
		player = GameObject.FindGameObjectWithTag(DoneTags.player);

	}
	
	
    void OnTriggerEnter (Collider other)
    {
		// If the colliding gameobject is the player...
		if(other.gameObject == player)
		{
			// ... play the clip at the position of the key...
			AudioSource.PlayClipAtPoint(keyGrab, transform.position);
			
			// ... and destroy this gameobject.
        	Destroy(gameObject);
		}
    }
}
