using UnityEngine;
using System.Collections;

public class GravityFieldController : MonoBehaviour {
	public bool startOff = false;
	GameObject gravityField;
	Light l1;
	Light l2;
	ParticleSystem[] panelParts;
	// Use this for initialization
	void Start () {
		gravityField = transform.GetChild(0).gameObject;
		l1 = transform.GetChild(1).GetComponent<Light>();
		if (transform.GetChild(2).GetComponent<Light>() != null)
		{
			l2 = transform.GetChild(2).GetComponent<Light>();
		}
		panelParts = gameObject.GetComponentsInChildren<ParticleSystem>();
		if (startOff)
		{
			OnTerminalDeactivate();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTerminalActivate()
	{
		gravityField.SetActive(true);
		l1.enabled = true;
		if (l2 != null)
		{
			l2.enabled = true;
		}
		foreach (ParticleSystem p in panelParts)
		{
			p.enableEmission = true;
		}
	}

	void OnTerminalDeactivate()
	{
		gravityField.SetActive(false);
		l1.enabled = false;
		if (l2 != null)
		{
			l2.enabled = false;
		}
		foreach (ParticleSystem p in panelParts)
		{
			p.enableEmission = false;
		}
	}
}
