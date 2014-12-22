using UnityEngine;
using System.Collections;

public class DoneLaserPlayerDetection : MonoBehaviour
{
    private GameObject player;								// Reference to the player.
    private DoneLastPlayerSighting lastPlayerSighting;		// Reference to the global last sighting of the player.
    public AudioClip sound;
    public float soundVolume = 1f;

    void Awake ()
    {
		// Setting up references.
		player = GameObject.FindGameObjectWithTag("Player");
		//lastPlayerSighting = GameObject.FindGameObjectWithTag(DoneTags.gameController).GetComponent<DoneLastPlayerSighting>();
    }


    void OnTriggerEnter(Collider other)
    {
		// If the beam is on...
        if(renderer.enabled)
			// ... and if the colliding gameObject is the player...
            if(other.gameObject == player)
            {
                other.gameObject.SendMessage("Slam", -2f*other.transform.forward, SendMessageOptions.RequireReceiver);
                other.gameObject.SendMessage("OnHit", 20, SendMessageOptions.RequireReceiver);
                if (sound)
                    AudioSource.PlayClipAtPoint(sound, transform.position, soundVolume);
            }
    }
}