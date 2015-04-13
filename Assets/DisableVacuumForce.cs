using UnityEngine;
using System.Collections;

public class DisableVacuumForce : MonoBehaviour {
	public airconForce vacuumForceScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player")
		{
			vacuumForceScript.SetMagnet(true);
		}
	}
	void OnTriggerExit(Collider other){
		if (other.gameObject.tag == "Player")
		{
			vacuumForceScript.SetMagnet(false);
		}
	}
}
