using UnityEngine;
using System.Collections;

public class KeyCardPanel : MonoBehaviour {
	bool isUsed = false;
	bool inTrigger = false;
	public AudioClip useSound;
	public Material usedMat;
	GameObject player;
	public GameObject keyCardShield;
	// Use this for initialization
	void Start () {
		isUsed = false;
		inTrigger = false;
		player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (inTrigger && !isUsed)
		{
			if (Input.GetButtonDown("Activate"))
			{
				Debug.Log("Activate");
				UseKeyCard();
				isUsed = true;
				transform.GetChild(0).renderer.material = usedMat;
				if (useSound)
				{
					AudioSource.PlayClipAtPoint(useSound, transform.position, 1);
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

	void UseKeyCard()
	{
		player.SendMessage("RemoveKeyCard", SendMessageOptions.RequireReceiver);
		keyCardShield.SendMessage("OnKeyCardEntered", SendMessageOptions.RequireReceiver);
	}

}
