using UnityEngine;
using System.Collections;

public class DoneLaserPlayerDetection : MonoBehaviour
{
    private GameObject player;								// Reference to the player.
    private DoneLastPlayerSighting lastPlayerSighting;		// Reference to the global last sighting of the player.
    public AudioClip sound;
    public float soundVolume = 1f;
    public AudioClip empSound;
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

    void OnEMP()
    {
        if (renderer.enabled && !IsInvoking("EMP1") && !IsInvoking("EMP2") && !IsInvoking("EMP3") && !IsInvoking("EMP4") && !IsInvoking("EMP5"))
        {
            if (empSound)
            {
                AudioSource.PlayClipAtPoint(empSound, transform.position, soundVolume);
            }
            renderer.enabled = false;
            Invoke("EMP1",0.2f);
        }
        print("EMP");
    }

    void EMP1()
    {
        renderer.enabled = true;
        Invoke("EMP2",0.1f);
    }

    void EMP2()
    {
        renderer.enabled = false;
        Invoke("EMP3",0.1f);
    }

    void EMP3()
    {
        renderer.enabled = true;
        Invoke("EMP4",0.1f);
    }

    void EMP4()
    {
        renderer.enabled = false;
        Invoke("EMP5",5f);
    }

    void EMP5()
    {
        renderer.enabled = true;
        CancelInvoke();
    }
}