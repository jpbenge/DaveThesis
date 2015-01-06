using UnityEngine;
using System.Collections;

public class IceGrenade : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.transform.parent != null)
			col.transform.parent.gameObject.BroadcastMessage("Freeze", SendMessageOptions.DontRequireReceiver);
		else
			col.gameObject.BroadcastMessage("Freeze", SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerEnter(Collider other){
		if (other.transform.parent != null)
			other.transform.parent.gameObject.BroadcastMessage("Freeze", SendMessageOptions.DontRequireReceiver);
		else
			other.gameObject.BroadcastMessage("Freeze", SendMessageOptions.DontRequireReceiver);
	}
}
