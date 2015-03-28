using UnityEngine;
using System.Collections;

public class FrictionGrenade : MonoBehaviour {

	float startTime = 0;
	//can't be longer than 0.5 for some reason !!!!
	public float endTime = 0.5f;
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
				Friction();
				ended = true;
			}
		}
	}

	void Friction()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2.2f);
		
		int i = 0;
		while (i < hitColliders.Length)
        {
        	if (hitColliders[i].transform.parent != null)
        	{
            	hitColliders[i].transform.parent.gameObject.SendMessage("OnFriction",SendMessageOptions.DontRequireReceiver);
            }
            hitColliders[i].gameObject.SendMessage("OnFriction",SendMessageOptions.DontRequireReceiver);
           	i++;
        }
	}
}
