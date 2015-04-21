using UnityEngine;
using System.Collections;

public class airconForce : MonoBehaviour {
	bool enabled = true;
	bool magnet = false;
	CharacterController controller;
	public Vector3 forceVector = new Vector3(0, 0, -20f);
	// Use this for initialization
	void Start () {
		enabled = true;
		magnet = false;
		controller = GameObject.Find("Player").GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider other){
		if (enabled && !magnet)
		{
			if (other.gameObject.tag == "Player")
			{
				controller.Move((Time.deltaTime*forceVector/(3f*Vector3.Distance(transform.position,other.transform.position))));
			}
			if (other.rigidbody != null)
			{
				other.rigidbody.AddForce((forceVector/Vector3.Distance(transform.position,other.transform.position)));
			}
		}
	}

	void OnTerminalActivate() {
		enabled = true;
		if (transform.childCount > 0)
		{
			foreach (Transform child in transform)
			{
				if (child.GetComponent<ParticleSystem>() != null)
				{
					child.GetComponent<ParticleSystem>().enableEmission = true;
				}
				else if (child.GetComponent<ParticleEmitter>()!= null)
				{
					child.GetComponent<ParticleEmitter>().emit = true;
				}
			}
		}
	}

	void OnTerminalDeactivate() {
		enabled = false;
		if (transform.childCount > 0)
		{
			foreach (Transform child in transform)
			{
				if (child.GetComponent<ParticleSystem>() != null)
				{
					child.GetComponent<ParticleSystem>().enableEmission = false;
				}
				else if (child.GetComponent<ParticleEmitter>()!= null)
				{
					child.GetComponent<ParticleEmitter>().emit = false;
				}
			}
		}
	}
	public void SetMagnet(bool val)
	{
		magnet = val;
	}
}
