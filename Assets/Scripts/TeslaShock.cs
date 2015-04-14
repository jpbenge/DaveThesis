using UnityEngine;
using System.Collections;

public class TeslaShock : MonoBehaviour {
	float startTime = 0;
	public float pulseTime = 2f;
	public bool pulsed = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (!pulsed && Time.time >= startTime + pulseTime)
		{
			Pulse();
		}
	}

	void Pulse()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 3f);
		
		int i = 0;
		while (i < hitColliders.Length)
        {
        	print(hitColliders[i].name);
        	if (hitColliders[i].transform.parent != null)
            	hitColliders[i].transform.parent.gameObject.SendMessage("OnShock",SendMessageOptions.DontRequireReceiver);
            	hitColliders[i].gameObject.SendMessage("OnShock",SendMessageOptions.DontRequireReceiver);
           	i++;
        }
        pulsed = true;
	}
}
