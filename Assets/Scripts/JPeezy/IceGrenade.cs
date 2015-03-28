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
			col.gameObject.BroadcastMessage("Freeze", SendMessageOptions.DontRequireReceiver);
	}

	void OnTriggerEnter(Collider other){
			other.gameObject.BroadcastMessage("Freeze", SendMessageOptions.DontRequireReceiver);

	}
}
