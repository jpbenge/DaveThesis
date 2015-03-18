using UnityEngine;
using System.Collections;

public class WindGrenade : MonoBehaviour {

	float startTime = 0;
	public float endTime = 1f;
	public bool ended = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
		ended = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time >= startTime + endTime)
		{
			if (!ended)
			{
				Wind();
				ended = true;
			}
		}
	}

	void Wind()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.2f);
		
		int i = 0;
		while (i < hitColliders.Length)
        {
        	if (hitColliders[i].transform.parent != null)
        	{
            	hitColliders[i].transform.parent.gameObject.SendMessage("OnWind",SendMessageOptions.DontRequireReceiver);
        	}
            	hitColliders[i].gameObject.SendMessage("OnWind",SendMessageOptions.DontRequireReceiver);
           	i++;
        }
	}
}
