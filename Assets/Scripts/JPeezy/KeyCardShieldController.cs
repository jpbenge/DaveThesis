using UnityEngine;
using System.Collections;

public class KeyCardShieldController : MonoBehaviour {

	public int requiredNumKeycards = 10;
	public AudioClip deactivateShieldSound;
	public GameObject crystalPlatform;
	int curKeyCards = 0;
	// Use this for initialization
	void Start () {
		curKeyCards = 0;
	}
	
	void OnKeyCardEntered()
	{
		curKeyCards += 1;
		if (curKeyCards >= requiredNumKeycards)
		{
			AllKeysEntered();
		}
	}

	void AllKeysEntered()
	{
		if (deactivateShieldSound)
		{
			AudioSource.PlayClipAtPoint(deactivateShieldSound, transform.position);
		}
		audio.Stop();
		foreach (Transform child in transform)
		{
			child.gameObject.SetActive(false);
		}
		collider.enabled = false;
		crystalPlatform.SendMessage("LowerPlatform");
	}
}
