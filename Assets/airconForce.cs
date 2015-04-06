using UnityEngine;
using System.Collections;

public class airconForce : MonoBehaviour {
	bool enabled = true;
	public Vector3 forceVector = new Vector3(0, 0, -20f);
	// Use this for initialization
	void Start () {
		enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if (enabled)
		{
			if (other.gameObject.tag == "Player")
			{
				other.gameObject.SendMessage("ExternalForce",((0.2f*forceVector)/Vector3.Distance(transform.position,other.transform.position)));
			}
			if (other.rigidbody != null)
			{
				other.rigidbody.AddForce((forceVector/Vector3.Distance(transform.position,other.transform.position)));
			}
		}
	}

	void OnTerminalActivate() {
		enabled = true;
		transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = true;
	}

	void OnTerminalDeactivate() {
		enabled = false;
		transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = false;
	}
}
