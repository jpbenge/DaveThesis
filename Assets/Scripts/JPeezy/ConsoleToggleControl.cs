using UnityEngine;
using System.Collections;

public class ConsoleToggleControl : MonoBehaviour {
	public bool isActive = false;
	private bool inTrigger = false;
	private bool disabled = false;
	public GameObject[] linkedObjects;
	public AudioClip toggleSound;
	public float soundVolume = 1;
 	// Use this for initialization
	void Start () {
		disabled = false;
		inTrigger = false;
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
		disabled = true;
	}

	void OnTesla() {
		disabled = false;
	}

	void OnTerminalActivate() {
		isActive = true;
	}

	void OnTerminalDeactivate() {
		isActive = false;
	}
}
