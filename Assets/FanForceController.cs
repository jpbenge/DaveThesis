using UnityEngine;
using System.Collections;

public class FanForceController : MonoBehaviour {

	public GameObject[] fans;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTerminalActivate()
	{
		collider.enabled = true;
		foreach (GameObject fan in fans)
		{
			fan.GetComponent<Animation>().Play();
			if (fan.audio != null)
				fan.audio.Play();
			fan.transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = true;
		}
	}

	void OnTerminalDeactivate()
	{
		collider.enabled = false;
		foreach (GameObject fan in fans)
		{
			fan.GetComponent<Animation>().Stop();
			if (fan.audio != null)
				fan.audio.Stop();
			fan.transform.GetChild(0).GetComponent<ParticleSystem>().enableEmission = false;
		}
	}
}
