using UnityEngine;
using System.Collections;

public class ForceFieldGenerator : MonoBehaviour {

	bool on;
	public AudioClip turnOffSound;
	public AudioClip turnOnSound;
	public GameObject forceField;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void TurnOn()
	{
		forceField.SetActive(true);
		if (turnOnSound != null)
		{
			AudioSource.PlayClipAtPoint(turnOnSound, transform.position);
		}
		on = true;
	}

	void TurnOff()
	{
		forceField.SetActive(false);
		if (turnOffSound != null)
		{
			AudioSource.PlayClipAtPoint(turnOffSound, transform.position);
		}
		on = false;
	}
	

	void OnEMP()
	{
		TurnOff();
	}

	void OnShock()
	{
		CancelInvoke();
		TurnOn();
	}
}
