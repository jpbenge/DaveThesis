using UnityEngine;
using System.Collections;

public class ConsoleToggleControl : MonoBehaviour {
	public bool isActive = false;
	private bool inTrigger = false;
	private bool disabled = false;
	public GameObject[] linkedObjects;
	public AudioClip toggleSound;
	public AudioClip PowerOffSound;
	public AudioClip PowerOnSound;
	public float soundVolume = 1;
	public Material blackMat;
	Material screenMat;
 	// Use this for initialization
	void Start () {
		disabled = false;
		inTrigger = false;
		screenMat = transform.GetChild(0).renderer.sharedMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		if (inTrigger && !disabled)
		{
			if (Input.GetButtonDown("Activate"))
			{
				if (!isActive)
				{
					Debug.Log("Activate");
					SendActivateMessage();
					isActive = true;
				}
				else
				{
					Debug.Log("Deactivate");
					SendDeactivateMessage();
					isActive = false;
				}
				if (toggleSound)
				{
					AudioSource.PlayClipAtPoint(toggleSound, transform.position, soundVolume);
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		inTrigger = true;
	}

	void OnTriggerExit(Collider other){
		inTrigger = false;
	}


	void SendActivateMessage()
	{
		foreach (GameObject linkedRef in linkedObjects)
		{
			linkedRef.SendMessage("OnTerminalActivate", SendMessageOptions.DontRequireReceiver);
		}
	}

	void SendDeactivateMessage()
	{
		foreach (GameObject linkedRef in linkedObjects)
		{
			linkedRef.SendMessage("OnTerminalDeactivate", SendMessageOptions.DontRequireReceiver);
		}
	}

	void OnEMP() {
		if (PowerOffSound)
		{
			AudioSource.PlayClipAtPoint(PowerOffSound, transform.position, soundVolume);
		}
		disabled = true;
		foreach (Transform child in transform) {
            child.renderer.material = blackMat;
        }
	}

	void OnShock() {
		if (PowerOnSound)
		{
			AudioSource.PlayClipAtPoint(PowerOnSound, transform.position, soundVolume);
		}
		disabled = false;
		foreach (Transform child in transform) {
            child.renderer.material = screenMat;
        }
	}

	void OnTerminalActivate() {
		isActive = true;
	}

	void OnTerminalDeactivate() {
		isActive = false;
	}
}
